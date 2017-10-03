create procedure [ASInternal_PurgeEventData]
  @purgeMode int, -- 1:instance base, 2:time base
  @cutoffUtcDateTime datetime2,		
  @archive bit,
  @operationReference nvarchar(64) = null,
  @doLog bit = 1, -- 1: should log operation
  @eventType nvarchar(12) = N'ALL' -- ALL: All ASEvents, WF: Only WF ASEvents + instances, WCF: Only WCF ASEvents, TRANSFER: Only Transfer ASEvents
as
begin	   
  declare @log nvarchar(max);
  declare @batchSize int;
  declare @result int;
  declare @defaultSchema sysname;
  
  set @log = N'';
  set @batchSize = 8192;
  set @result = 0;
  set @defaultSchema = (select quotename(default_schema_name) from sys.database_principals where name = current_user);
        
  -- we are archiving read only data, this will prevent adquiring share locks and increase performance
  set transaction isolation level read uncommitted
               
  -- Ensure that the cut off date time is not future
  if @cutoffUtcDateTime is null or @cutoffUtcDateTime > getutcdate()
      set @cutoffUtcDateTime = getutcdate();
      
  begin try            
    declare @archiveTableName nvarchar(max);
    declare @useTransaction bit;    
    declare @parameters nvarchar(max);
    declare @operationHistoryId bigint;
    declare @recordCount bigint;
    declare @totalCount bigint;
    declare @archiveSql nvarchar(max);
    declare @deleteSql nvarchar(300);
    declare @getBatchSql nvarchar(max);
    declare @importEventsSproc nvarchar(max);
    
    -- Start operation
    if (@doLog = 1)
    begin
      set @parameters = N'@purgeMode=' + cast(@purgeMode as nchar(1))+ N';@cutoffUtcDateTime=' + 
        convert(nvarchar, @cutoffUtcDateTime, 126) + N';@archive=' + cast (@archive as nchar(1)) + 
        N';@operationReference=' + isNull(@operationReference, '');
      
      insert into [ASOperationsHistoryTable]([OperationId], [StartTime], [Parameters],
       [Status], [UserLogin], [Log])
      values (2, current_timestamp, @parameters,  0, system_user, null);
      
      set @operationHistoryId = scope_identity();
      
      -- Calculate record counts for progress
      set @recordCount = 0;
      set @totalCount = 0;
      
      -- Logging only supported when purging with 'ALL' 
      if (@eventType = N'ALL') 
      begin
        set @totalCount = 
          (select count(*) from [ASTransferEventsTable]
           where [TimeCreated] < @cutoffUtcDateTime) + 
          (select count(*) from [ASWcfEventsTable]
           where [TimeCreated] < @cutoffUtcDateTime) + 
          (select count(*) from [ASWfEventsTable]
           where [TimeCreated] < @cutoffUtcDateTime) + 
          (select count(*) from [ASWfInstancesTable]
           where [LastModifiedTime] < @cutoffUtcDateTime);
      end      
    end
            
    -- Get the archive settings and validate them
    if @archive = 1
      exec [ASInternal_GetArchiveSettings] @archiveTableName out, @useTransaction out, @importEventsSproc out;
    else
      set @useTransaction = 1; 
                   
    if (@eventType = N'ALL' or @eventType = N'TRANSFER')
    begin      
      -- Purge Transfer    
      if @archive = 1
        set @archiveSql = N'insert into ' + @archiveTableName + N'([ArchiveId], [EventTypeId], [Computer], 
            [EventSource], [ProcessId], [TraceLevelId], [E2EActivityId], [TimeCreated], [Data1UniqueId])
          select ET.[Id], [EventTypeId], ES.[Computer], ' +
            @defaultSchema + N'.[ASInternal_GetEventSource](ES.[Name], ES.[Site], ES.[VirtualPath], ES.[ApplicationVirtualPath], ES.[ServiceVirtualPath]),
            [ProcessId], [TraceLevelId], [E2EActivityId], [TimeCreated], [ToE2EActivityId]
          from [ASTransferEventsTable] ET LEFT JOIN 
               [ASEventSourcesTable] ES ON ET.[EventSourceId] = ES.[Id]
          where [TimeCreated] between @batchStartTime and @batchEndTime';     
      
      exec [ASInternal_ArchivePurgeTable] N'ASTransferEventsTable', 
        @cutoffUtcDateTime, @useTransaction, @operationHistoryId, @batchSize, @totalCount, @recordCount out, @log out, @archiveSql, @importEventsSproc; 
    end
          
    if (@eventType = N'ALL' or @eventType = N'WCF')
    begin          
      -- Purge WCF        
      if @archive = 1
        set @archiveSql = N'insert into ' + @archiveTableName + N'([ArchiveId], [EventTypeId], [Computer], [EventSource], 
            [ProcessId], [TraceLevelId], [E2EActivityId], [TimeCreated], [Data1UniqueId], 
            [Data1Str], [Data2Str], [Data3Str], [Data4Str], [Data1MaxStr], [Data1Int], [Data2Int], [Data3Int])
          select ET.[Id], [EventTypeId], ES.[Computer], ' +
            @defaultSchema + N'.[ASInternal_GetEventSource](ES.[Name], ES.[Site], ES.[VirtualPath], ES.[ApplicationVirtualPath], ES.[ServiceVirtualPath]),
            [ProcessId], [TraceLevelId], [E2EActivityId], [TimeCreated], [Data1UniqueIdentifier], 
            [Data1Str], [Data2Str], [Data3Str], [Data4Str], [Data1MaxStr], [Data1Int], [Data2Int], [Data3Int]
          from [ASWcfEventsTable] ET LEFT JOIN 
               [ASEventSourcesTable] ES ON ET.[EventSourceId] = ES.Id
          where [TimeCreated] between @batchStartTime and @batchEndTime';        
      
      exec [ASInternal_ArchivePurgeTable] N'ASWcfEventsTable', 
        @cutoffUtcDateTime, @useTransaction, @operationHistoryId, @batchSize, @totalCount, @recordCount out, @log out, @archiveSql, @importEventsSproc;
    end
              
    if (@eventType = N'ALL' or @eventType = N'WF')
    begin               
      -- Purge WF 
      if @archive = 1
        set @archiveSql = N'insert into ' + @archiveTableName + N'(
            [ArchiveId], [EventTypeId], [Computer], [EventSource], 
            [ProcessId], [TraceLevelId], [Data1UniqueId], [Data1BigInt], [Data1Str], [TimeCreated], 
            [Data2Str], [Data3Str], [Data4Str], [Data5Str], [Data6Str], [Data7Str], [Data8Str], [Data9Str], [Data1MaxStr], [Data1Int], 
            [CustomAnnotations], [CustomProperties], [CustomArguments])
          select ET.[Id], [EventTypeId], ES.[Computer], ' +
            @defaultSchema + N'.[ASInternal_GetEventSource](ES.[Name], ES.[Site], ES.[VirtualPath], ES.[ApplicationVirtualPath], ES.[ServiceVirtualPath]),
            [ProcessId], [TraceLevelId], [WorkflowInstanceId], [RecordNumber], TPT.[Name], [TimeCreated],
            [Data1Str], [Data2Str], [Data3Str], [Data4Str], [Data5Str], [Data6Str], [Data7Str], [Data8Str], [Data1MaxStr], [Data1Int],' +
            @defaultSchema + N'.[ASInternal_GetCustomAnotations](ET.[Id]), ' +
            @defaultSchema + N'.[ASInternal_GetCustomProperties](ET.[Id]), ' +
            @defaultSchema + N'.[ASInternal_GetCustomArguments](ET.[Id])
          from [ASWfEventsTable] ET 
            LEFT JOIN [ASEventSourcesTable] ES ON ET.[EventSourceId] = ES.[Id]
            LEFT JOIN [ASWfTrackingProfiles] TPT ON ET.[TrackingProfileId] = TPT.[Id]';          
          
      if @purgeMode = 1 -- instance based
      begin     
        -- Purge WF completed instances ASEvents
        if @archive = 1
          set @archiveSql = @archiveSql + N' where ET.[WorkflowInstanceId] in 
            (select top(@batchSize) [WorkflowInstanceId] 
             from [ASWfInstancesTable]
             where [LastModifiedTime] < @cutoffUtcDateTime and
                ([LastEventStatus] = N''Completed'' or
                 [LastEventStatus] = N''Terminated'' or
                 [LastEventStatus] = N''Canceled'')           
             order by [LastModifiedTime])';
         
        exec [ASInternal_ArchivePurgeWFEvents] @cutoffUtcDateTime, 
          @archiveTableName, @useTransaction, @operationHistoryId, @batchSize, @totalCount, @recordCount out, @log out, @archiveSql, @importEventsSproc;
      end
      else -- time base
      begin
        -- Purge all wf ASEvents
        if (@archive = 1)
          set @archiveSql = @archiveSql + N' where [TimeCreated] between @batchStartTime and @batchEndTime;'

        set @deleteSql = N'delete from [ASWfEventPropertiesTable]
        where [TimeCreated] between @batchStartTime and @batchEndTime;
        delete from [ASWfEventsTable]
        where [TimeCreated] between @batchStartTime and @batchEndTime;';  

        exec [ASInternal_ArchivePurgeTable] 'ASWfEventsTable', @cutoffUtcDateTime, 
         @useTransaction, @operationHistoryId, @batchSize, @totalCount, @recordCount out, @log out, 
         @archiveSql, @importEventsSproc, @deleteSql;   

        -- In case the WfEventsTable/WfEventPropertiesTable get out of sync, we must ensure we still delete from the WfEventPropertiesTable. We never archive in this case.
        set @deleteSql = N'delete from [ASWfEventPropertiesTable]
        where [TimeCreated] between @batchStartTime and @batchEndTime;';  
        
        exec [ASInternal_ArchivePurgeTable] 'ASWfEventPropertiesTable', @cutoffUtcDateTime, 
         @useTransaction, @operationHistoryId, @batchSize, @totalCount, @recordCount out, @log out, 
         null, @importEventsSproc, @deleteSql;   
         
         -- Purge active instances    
        set @deleteSql = N'delete from [ASWfInstancesTable]
        where [LastModifiedTime] between @batchStartTime and @batchEndTime and
              [LastEventStatus] <> N''Completed'' and
              [LastEventStatus] <> N''Terminated'' and
              [LastEventStatus] <> N''Canceled'';';

        set @getBatchSql = N'select @batchStartTime = min([LastModifiedTime]), @batchEndTime = max ([LastModifiedTime])
           from (select top (@batchSize) [LastModifiedTime] 
                 from [ASWfInstancesTable] 
                 where [LastModifiedTime] < @cutoffUtcDateTime and
                       [LastEventStatus] <> N''Completed'' and
                       [LastEventStatus] <> N''Terminated'' and
                       [LastEventStatus] <> N''Canceled''               
                 order by [LastModifiedTime]) as Batch';
           
        exec [ASInternal_ArchivePurgeTable] 'ASWfInstancesTable', @cutoffUtcDateTime, 
        0, @operationHistoryId, @batchSize, @totalCount, @recordCount out, @log out, null, null, @deleteSql, @getBatchSql;                
      end
    
      -- Purge completed instances        
      set @deleteSql = N'delete from [ASWfInstancesTable]
        where [LastModifiedTime] between @batchStartTime and @batchEndTime and
            ([LastEventStatus] = N''Completed'' or
            [LastEventStatus] = N''Terminated'' or
            [LastEventStatus] = N''Canceled'');';
        
      set @getBatchSql = N'select @batchStartTime = min([LastModifiedTime]), @batchEndTime = max ([LastModifiedTime])
           from (select top (@batchSize) [LastModifiedTime] 
                 from [ASWfInstancesTable] 
                 where [LastModifiedTime] < @cutoffUtcDateTime and
                 ([LastEventStatus] = N''Completed'' or
                 [LastEventStatus] = N''Terminated'' or
                 [LastEventStatus] = N''Canceled'')               
                 order by [LastModifiedTime]) as Batch';
           
      exec [ASInternal_ArchivePurgeTable] 'ASWfInstancesTable', @cutoffUtcDateTime, 
       0, @operationHistoryId, @batchSize, @totalCount, @recordCount out, @log out, null, null, @deleteSql, @getBatchSql;  
    end;
                                     
    if (@doLog = 1)
    begin    
      exec [ASInternal_UpdatePurgeOperation] @operationHistoryId, 99, -1, @log;
    end
    
    -- Purge parent tables 
    
    -- Purge event sources              
    delete from [ASEventSourcesTable]
    from [ASEventSourcesTable] Est
    where not exists(
      select Id from [ASWcfEventsTable] Wcf
      where Wcf.[EventSourceId] = Est.[Id]
      union all
      select Id from [ASTransferEventsTable] Te
      where Te.[EventSourceId] = Est.[Id]
      union all
      select Id from [ASWfEventsTable] Wf
      where Wf.[EventSourceId] = Est.[Id]
    );
       
    if (@eventType = N'ALL' or @eventType = N'WF')
    begin
      -- Purge tracking profiles        
      delete from [ASWfTrackingProfilesTable]
      from [ASWfTrackingProfilesTable] PT
      where not exists(select * from [ASWfEventsTable] ET
      where ET.[TrackingProfileId] = PT.[Id]);
          
      -- Purge annotations    
      delete from [ASWfEventAnnotationSetsTable]
      from [ASWfEventAnnotationSetsTable] WAT
      where not exists(select * from [ASWfEventsTable] ET
      where ET.[AnnotationSetId] = WAT.[Id]);

      delete from [ASWfEventAnnotationsTable]
      from [ASWfEventAnnotationsTable] AT
      where not exists(select * from [ASWfEventAnnotationSetsTable] AST
      where AST.[Id] = AT.[AnnotationSetId]);
          
      -- Purge workflow property names	           
      delete from [ASWfPropertyNamesTable]
      from [ASWfPropertyNamesTable] PN 	    
      where not exists (
        select * from [ASEventSourcesTable] ES
        where PN.[EventSourceId] = ES.[Id]);
    end;
    
    if (@doLog = 1)
    begin      
      exec [ASInternal_UpdatePurgeOperation] @operationHistoryId, 100, -1, @log;
      
      -- Log success
      update [ASOperationsHistoryTable]
      set [EndTime] = current_timestamp, [Status] = 1
      where [Id] = @operationHistoryId;      
    end
         
  end try
  begin catch
    set @result = -1;
    
    if @@trancount > 0
      rollback;
      
    exec [ASInternal_RethrowError];
    
    if (@doLog = 1)
    begin      
      -- Log error
      update [ASOperationsHistoryTable]
      set [EndTime] = current_timestamp, [Status] = -1, [Message]= error_message()
      where [Id] = @operationHistoryId;
    end    
  end catch
  
  -- Restore transaction isolation level back to default  
  set transaction isolation level read committed;
  
  return @result;            
end