-- This internal sproc is used to move the WF ASEvents from ASStagingTable row by row
create procedure [ASInternal_ImportWfEventsRow]
(@stopId bigint,
@errorNumber int out,
@errorMessage nvarchar(2048) out)
as
  declare @result int;
  declare @autoPurgeLockName nvarchar(255);
  declare @hasAutoPurgeLock int;
  declare @autopurgeCheckCounter int;
  
  declare @originalId bigint;
  declare @id bigint;  
  declare @archiveId bigint;
  declare @eventTypeId int;
  declare @e2eActivityId nvarchar(36);	
  declare @computer nvarchar(450);
  declare @eventSource nvarchar(1024);
  declare @processId int;
  declare @traceLevelId tinyint;
  declare @timeCreated datetime2;

  declare @data1Str nvarchar(450);
  declare @data2Str nvarchar(450);
  declare @data3Str nvarchar(450);
  declare @data4Str nvarchar(450);
  declare @data5Str nvarchar(450);
  declare @data6Str nvarchar(450);
  declare @data7Str nvarchar(450);
  declare @data8Str nvarchar(450);
  declare @data9Str nvarchar(450);
  declare @data1MaxStr nvarchar(max);
  declare @data1Int int;	
  declare @data1BigInt bigint;
  declare @data1UniqueIdentifier nvarchar(36);
  declare @customProperties nvarchar(max);
  declare @customArguments nvarchar(max);
  declare @customAnnotations nvarchar(max);
  declare @customPropertiesXml xml;
  declare @annotationSetId int;
  
  declare @eventSourceId int;
  declare @trackingProfileId int;    
  
  set @result = 0;    
  set @autopurgeCheckCounter = 0;
  set @autoPurgeLockName = N'AutoPurgeThresholdLock';
  set @hasAutoPurgeLock = -1;
  
  if (@stopId is null)
    return @result;
        
  declare eventCursor cursor forward_only fast_forward for select
    Id,
    ArchiveId,
    EventTypeId,
    E2EActivityId,
    Computer,
    EventSource,
    ProcessId,
    TraceLevelId,
    TimeCreated,
    Data1Str,
    Data2Str,
    Data3Str,
    Data4Str,
    Data5Str,
    Data6Str,
    Data7Str,
    Data8Str,
    Data9Str,
    Data1MaxStr,
    Data1Int,
    Data1BigInt,
    Data1UniqueId,
    CustomProperties,    
    CustomAnnotations,
    CustomArguments
   from [ASStagingTable] 
   where 
    [EventTypeId] >= 100 and
    [EventTypeId] <= 199 and
    [Id] <= @stopId
   order by [Id];	
   
  open eventCursor;
  
  fetch next from eventCursor into 
    @id,
    @archiveId,
    @eventTypeId,
    @e2eActivityId,
    @computer,
    @eventSource,
    @processId,
    @traceLevelId,
    @timeCreated,
    @data1Str,
    @data2Str,
    @data3Str,
    @data4Str,
    @data5Str,
    @data6Str,
    @data7Str,
    @data8Str,
    @data9Str,
    @data1MaxStr,	
    @data1Int,
    @data1BigInt,
    @data1UniqueIdentifier,
    @customProperties,
    @customAnnotations,
    @customArguments;	
    
  while (@@fetch_status = 0)
  begin
    begin try    
      -- Check if we need to delete from ASStagingTable instead of import. 
      -- In this case, break out of the cursor and let another Import job perform the delete.
      if ((@autopurgeCheckCounter % 1000) = 0)
      begin
        if @hasAutoPurgeLock = 0
        begin          
          exec [sys].[sp_releaseapplock] @autoPurgeLockName, 'Session';
          set @hasAutoPurgeLock = -1;
        end
      
        exec @hasAutoPurgeLock = [sys].[sp_getapplock] @Resource=@autoPurgeLockName, @LockMode='Shared', @LockOwner='Session', @LockTimeout=100;
        if @hasAutoPurgeLock < 0
        begin
           break;
        end  
        set @autopurgeCheckCounter = 0;
      end;
      set @autopurgeCheckCounter = @autopurgeCheckCounter + 1;
      
      begin transaction;
    
      set @originalId = @id;
      if (@archiveId >= 1)
      begin
        -- This indicates the row was copied to Staging as a result of the archiving process
        -- Use the ArchiveId as the event Id.
        set @id = @archiveId;
      end;
      
      exec [ASInternal_GetEventSourceId]
        @computer,
        @eventSource,
        @eventSourceId output;

      exec [ASInternal_GetWfTrackingProfileId]
        @data1Str,
        @trackingProfileId output;

      set @annotationSetId = null;                    
      if (@customAnnotations is not null and
          @customAnnotations <> N'<items />' and
          @customAnnotations <> N'<items>...</items>')
      begin
        exec [ASInternal_GetAnnotationSetId]
          @customAnnotations,
          @annotationSetId output;
      end;              				
                    
      insert into [ASWfEventsTable] 
        ([Id], [EventTypeId], [EventSourceId], [ProcessId], [TraceLevelId], 
        [WorkflowInstanceId], [RecordNumber], [TrackingProfileId], [AnnotationSetId], [TimeCreated],
        [Data1Str], 
        [Data2Str],
        [Data3Str],
        [Data4Str],
        [Data5Str],
        [Data6Str],
        [Data7Str],
        [Data8Str],
        [Data1MaxStr],
        [Data1Int])
      values
        (@id, @eventTypeId, @eventSourceId, @processId, @traceLevelId, 
        @data1UniqueIdentifier, @data1BigInt, @trackingProfileId, @annotationSetId, @timeCreated,
        @data2Str,
        @data3Str,
        @data4Str,
        @data5Str,
        @data6Str,
        @data7Str,
        @data8Str,
        @data9Str,
        @data1MaxStr,
        @data1Int);
                      
      if (@customProperties is not null and
          @customProperties <> N'<items />' and
          @customProperties <> N'<items>...</items>')
      begin
        set @customPropertiesXml = cast(@customProperties as xml);
        insert into [ASWfEventPropertiesTable] 
          ([EventId], [WfDataSourceId], [Name], [Type], [Value], [ValueBlob], [TimeCreated]) 
          select 
            @id,
            0, -- 0 maps to Variable
            [Name],
            [Type],
            [Value],
            [ValueBlob],
            @timeCreated
            from [ASInternal_ExtractCustomPropertiesFromXml](@customPropertiesXml);

        if (@@ROWCOUNT > 0)
        begin
          merge [ASWfPropertyNamesTable] as [target]
            using (select
              @eventSourceId as [EventSourceId],
              [Name],
              [Type]
              from [ASInternal_ExtractCustomPropertiesFromXml](@customPropertiesXml)) as [source]
            on [target].[EventSourceId] = [source].[EventSourceId]
              and [target].[Name] = [source].[Name]
              and [target].[Type] = [source].[Type]
            when not matched then 
              insert ([EventSourceId], [Name], [Type]) values ([EventSourceId], [Name], [Type]);
        end;
      end;
                   
      if (@customArguments is not null and
          @customArguments <> N'<items />' and
          @customArguments <> N'<items>...</items>')
      begin
        set @customPropertiesXml = cast(@customArguments as xml);
        insert into [ASWfEventPropertiesTable] 
          ([EventId], [WfDataSourceId], [Name], [Type], [Value], [ValueBlob], [TimeCreated]) 
          select 
            @id,
            1, -- 1 maps to Argument
            [Name],
            [Type],
            [Value],
            [ValueBlob],
            @timeCreated
            from [ASInternal_ExtractCustomPropertiesFromXml](@customPropertiesXml);

        if (@@ROWCOUNT > 0)
        begin
          merge [ASWfPropertyNamesTable] as [target]
            using (select
              @eventSourceId as [EventSourceId],
              [Name],
              [Type]
              from [ASInternal_ExtractCustomPropertiesFromXml](@customPropertiesXml)) as [source]
            on [target].[EventSourceId] = [source].[EventSourceId]
              and [target].[Name] = [source].[Name]
              and [target].[Type] = [source].[Type]
            when not matched then 
              insert ([EventSourceId], [Name], [Type]) values ([EventSourceId], [Name], [Type]);
        end;
      end;
                          
      delete from [ASStagingTable] where [Id] = @originalId;
      
      commit transaction;
    end try
    begin catch
      set @result = -1;
    
      if (@@trancount > 0)
        rollback transaction;
            
      select @errorNumber = error_number();      
      select @errorMessage = error_message();
      
      -- When we are archiving and get SQL error 2627: Violation of primary key on (Id, TimeCreated), we must cleanup the staging table.  
      -- This is a duplicate row which can be safely deleted.
      if (@archiveId >= 1 and @errorNumber = 2627)
      begin
        delete from [ASStagingTable] where [Id] = @originalId;
      end
      else
      begin        
        exec [ASInternal_MoveEventToFailedStaging]
          @originalId,
          @errorNumber,
          @errorMessage;          
      end;  
    end catch;
    
    fetch next from eventCursor into 
      @id,
      @archiveId,
      @eventTypeId,
      @e2eActivityId,
      @computer,
      @eventSource,
      @processId,
      @traceLevelId,
      @timeCreated,
      @data1Str,
      @data2Str,
      @data3Str,
      @data4Str,
      @data5Str,
      @data6Str,
      @data7Str,
      @data8Str,
      @data9Str,      
      @data1MaxStr,	
      @data1Int,
      @data1BigInt,
      @data1UniqueIdentifier,
      @customProperties,
      @customAnnotations,
      @customArguments;	
  end;
  
  close eventCursor;
  deallocate eventCursor;    
  
  if @hasAutoPurgeLock = 0
  begin          
    exec [sys].[sp_releaseapplock] @autoPurgeLockName, 'Session';
    set @hasAutoPurgeLock = -1;
  end  

  return @result;