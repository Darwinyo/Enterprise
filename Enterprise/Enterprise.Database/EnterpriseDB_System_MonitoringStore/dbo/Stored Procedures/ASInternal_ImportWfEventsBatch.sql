-- This internal sproc is used to move the WF ASEvents from ASStagingTable that do not need to be shredded.
-- These are the ASEvents that can not contain custom tracked variables or custom annotations
create procedure [ASInternal_ImportWfEventsBatch]
(@stopId bigint,
@batchSize int,
@errorNumber int out,
@errorMessage nvarchar(2048) out)
as  
  declare @result int;
  declare @resultTemp int;
  declare @autoPurgeLockName nvarchar(255);
  declare @hasAutoPurgeLock int;
  declare @autopurgeCheckCounter int;
  
  declare @curId bigint;  
  declare @endId bigint;

  declare @eventSourceId int;
  declare @computer nvarchar(1024);
  declare @eventSource nvarchar(1024);
  
  declare @trackingProfileId int;
  declare @trackingProfile nvarchar(450);
  
  set @result = 0;  
  
  set @autopurgeCheckCounter = 0;
  set @autoPurgeLockName = N'AutoPurgeThresholdLock';
  set @hasAutoPurgeLock = -1;
      
  if (@stopId is null)
    return @result;
    
  -- Note that Data1Str is allocated to TrackingProfile
  select top 1 @curId=[Id], @computer=[Computer], @eventSource=[EventSource], @trackingProfile=[Data1Str] 
    from [ASStagingTable]
    where [EventTypeId] >= 100 and 
      [EventTypeId] <= 199 and
      ([CustomProperties] is null or [CustomProperties] = N'<items />') and
      ([CustomAnnotations] is null or [CustomAnnotations] = N'<items />') and
      ([CustomArguments] is null or [CustomArguments] = N'<items />')
      order by [Id] asc;              
          
  while (@curId is not null and @curId <= @stopId)
  begin
    -- Check if we need to delete from ASStagingTable because of ASAutoPurge.      
    if ((@autopurgeCheckCounter % 10) = 0)
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
  
    if (@eventSource is null)
      set @eventSource = N'';
        
    select top (@batchSize) @endId = [Id] from [ASStagingTable]
      where ([EventTypeId] >= 100 and [EventTypeId] <= 199) and
        ([CustomProperties] is null or [CustomProperties] = N'<items />') and
        ([CustomAnnotations] is null or [CustomAnnotations] = N'<items />') and
        ([CustomArguments] is null or [CustomArguments] = N'<items />') and
        [EventSource] = @eventSource and
        [Computer] = @computer and
        [Data1Str] = @trackingProfile
        order by [Id] asc;      

    begin try
    
      begin transaction;

      exec [ASInternal_GetEventSourceId]
        @computer,
        @eventSource,
        @eventSourceId output;
                       
      exec [ASInternal_GetWfTrackingProfileId]
        @trackingProfile,
        @trackingProfileId output;
        
      insert into [ASWfEventsTable] 
        ([Id], [EventTypeId], 
        [EventSourceId], [ProcessId], [TraceLevelId], 
        [WorkflowInstanceId], [RecordNumber], [TrackingProfileId], [TimeCreated],
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
      select 
        case 
          when [ArchiveId] = 0 then [Id]
          else [ArchiveId]
        end,
        [EventTypeId], 
        @eventSourceId, [ProcessId], [TraceLevelId], 
        [Data1UniqueId], [Data1BigInt], @trackingProfileId, [TimeCreated],
        [Data2Str],
        [Data3Str],
        [Data4Str],
        [Data5Str],
        [Data6Str],
        [Data7Str],
        [Data8Str],
        [Data9Str],
        [Data1MaxStr],
        [Data1Int]        
      from [ASStagingTable]                     
      where ([EventTypeId] >= 100 and [EventTypeId] <= 199) and
        ([CustomProperties] is null or [CustomProperties] = N'<items />') and
        ([CustomAnnotations] is null or [CustomAnnotations] = N'<items />') and
        ([CustomArguments] is null or [CustomArguments] = N'<items />') and
        [EventSource] = @eventSource and
        [Computer] = @computer and   
        [Data1Str] = @trackingProfile and                 
        [Id] <= @endId;              
                        
      delete from [ASStagingTable]
        where ([EventTypeId] >= 100 and [EventTypeId] <= 199) and
          ([CustomProperties] is null or [CustomProperties] = N'<items />') and
          ([CustomAnnotations] is null or [CustomAnnotations] = N'<items />') and
          ([CustomArguments] is null or [CustomArguments] = N'<items />') and
          [EventSource] = @eventSource and
          [Computer] = @computer and   
          [Data1Str] = @trackingProfile and                   
          [Id] <= @endId;              
      
      commit transaction;
    end try
    begin catch
      if (@@TRANCOUNT > 0)
        rollback transaction;

      -- If we fail to process the batch, we will try to process the batch row by row            
      exec @resultTemp = [ASInternal_ImportEvents]
        100,
        199,
        @curId,
        @endId,
        @errorNumber out,
        @errorMessage out;      
        
      -- Save the last error
      if (@resultTemp < 0)
        set @result = @resultTemp;

    end catch
        
    set @curId = null;        
    select top 1 @curId=[Id], @computer=[Computer], @eventSource=[EventSource], @trackingProfile=[Data1Str] 
      from [ASStagingTable]
      where [EventTypeId] >= 100 and 
        [EventTypeId] <= 199 and
        ([CustomProperties] is null or [CustomProperties] = N'<items />') and
        ([CustomAnnotations] is null or [CustomAnnotations] = N'<items />') and
        ([CustomArguments] is null or [CustomArguments] = N'<items />')
        order by [Id] asc;        
  end;    

  if @hasAutoPurgeLock = 0
  begin          
    exec [sys].[sp_releaseapplock] @autoPurgeLockName, 'Session';
    set @hasAutoPurgeLock = -1;
  end    
  
  return @result;