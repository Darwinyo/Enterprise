create procedure [ASInternal_AutoPurge]
as
begin
  declare @autoPurgeEnabled bit;
  declare @thresholdSizeDbMb int;
  declare @maxTimeStoreEventInDays float;
  declare @percentageAutoPurge int;

  declare @performPurge bit;
  declare @currentDbSizeMb float;    
  declare @purgeTimeBoundaryMaxTimeStoreEventPolicy datetime2;
                      
  declare @eventsRowCount bigint;
  declare @eventsRowDeleteCount bigint;

  declare @result int;    
  declare @lockName nvarchar(255);
                                                    
  set @autoPurgeEnabled = (select top 1 [APEnabled] from [ASConfigurationPropertiesTable]);
  set @thresholdSizeDbMb = (select top 1 [APThreshold] from [ASConfigurationPropertiesTable]);
  set @maxTimeStoreEventInDays = (select top 1 [APMaxEventAge] from [ASConfigurationPropertiesTable]);
  set @percentageAutoPurge = (select top 1 [APTrimPercentage] from [ASConfigurationPropertiesTable]);
  
  set @performPurge = 0;
  set @eventsRowDeleteCount = 0;
  set @purgeTimeBoundaryMaxTimeStoreEventPolicy = null;
              
  -- Check if auto purge is disabled
  if (@autoPurgeEnabled is null or @autoPurgeEnabled = 0)
  begin
    return 0;
  end;  
      
  -- Check if current size of the database has exceeded the threshold
  if (@thresholdSizeDbMb is not null)
  begin
  
    -- Gets size of the MonitoringDB 
    set @currentDbSizeMb = 
      (select 
        sum(reserved) / 1024
        from 
          (select
	          (a1.reserved + isnull(a4.reserved,0))* 8 as reserved
             from
              (select 
                ps.object_id,
	              sum (ps.reserved_page_count) as reserved
	              from sys.dm_db_partition_stats ps
	              group by ps.object_id) as a1
                left outer join
            	(select
		            it.parent_id,
		            sum(ps.reserved_page_count) as reserved
	              from sys.dm_db_partition_stats ps
	              inner join sys.internal_tables it on (it.object_id = ps.object_id)
	              where it.internal_type IN (202,204)
	              group by it.parent_id) as a4 on (a4.parent_id = a1.object_id)
                inner join sys.all_objects a2 on ( a1.object_id = a2.object_id ) 
                inner join sys.schemas a3 on (a2.schema_id = a3.schema_id)
                where a2.type <> N'S' 
                  and a2.type <> N'IT'
                  and (a2.name = N'ASStagingTable' 
                      or a2.name = N'ASWcfEventsTable' 
                      or a2.name = N'ASWfEventsTable' 
                      or a2.name = N'ASWfInstancesTable' 
                      or a2.name = N'ASWfEventPropertiesTable' 
                      or a2.name = N'ASTransferEventsTable')) as DiskByTables);
  
    if (@currentDbSizeMb >= @thresholdSizeDbMb)
    begin
      set @performPurge = 1;
              
      -- Gets number of rows in the Monitoring DB (only events + properties)
      set @eventsRowCount = 
        (select
	        sum(a1.rows) as row_count
          from
	          (select 
		          ps.object_id,
		          sum (
			          case
				          when (ps.index_id < 2) then row_count
				          else 0
			          end) as [rows],		
		          sum (ps.reserved_page_count) as reserved
	            from sys.dm_db_partition_stats ps
	            group by ps.object_id) as a1
              left outer join
	          (select 
        		  it.parent_id,
		          sum(ps.reserved_page_count) as reserved
	            from sys.dm_db_partition_stats ps
	            inner join sys.internal_tables it on (it.object_id = ps.object_id)
	            where it.internal_type in (202,204)
	            group by it.parent_id) as a4 on (a4.parent_id = a1.object_id)
              inner join sys.all_objects a2  on ( a1.object_id = a2.object_id ) 
              inner join sys.schemas a3 on (a2.schema_id = a3.schema_id)
              where a2.type <> N'S' and a2.type <> N'IT'
              and (a2.name = N'ASWcfEventsTable' 
                or a2.name = N'ASWfEventsTable' 
                or a2.name = N'ASTransferEventsTable'
                or a2.name = N'ASStagingTable'
                or a2.name = N'ASWfEventPropertiesTable'));

      -- Get the number of ASEvents we need to delete to satisfy the @percentageAutoPurge
      set @eventsRowDeleteCount = @eventsRowCount * cast(@percentageAutoPurge as float) / 100;      
    end;    
  end;    
  
  if (@maxTimeStoreEventInDays is not null)
  begin
    -- Convert @maxTimeStoreEventInDays to minutes before subtracting to determine the hard purge boundary 
    set @purgeTimeBoundaryMaxTimeStoreEventPolicy = dateadd(n, -1*@maxTimeStoreEventInDays*1440, getutcdate());
    set @performPurge = 1;    
  end;
  
  if (@performPurge = 0)
  begin
    return;
  end;
  
  -- Use same lock name as ASPurgeEventData.  We don't want two purges to be running at the same time
  set @lockName = N'[PurgeEventDataLock]';
  
  -- Try to acquire an application lock  
  exec @result = sp_getapplock @Resource=@lockName, @LockMode='Exclusive', @LockOwner='Session', @LockTimeout=100;
  if @result < 0
  begin
     return 1;
  end  
  
  declare @autoPurgeLockName nvarchar(255);
  
  declare @oldestWcfEventTime datetime2;
  declare @oldestWfEventTime datetime2;
  declare @oldestWfEventPropertyTime datetime2;
  declare @oldestTransferEventTime datetime2;
  declare @purgeWcfEventTime datetime2;
  declare @purgeWfEventTime datetime2;
  declare @purgeTransferEventTime datetime2;
  declare @oldestPurgeEventTime datetime2;
  declare @oldestWfEventId bigint;
  declare @oldestWcfEventId bigint;
  declare @oldestTransferEventId bigint;
  
  declare @eventsRowDeleteCounter bigint;
  declare @eventsRowMaxBatchSize int;  
  declare @eventsRowBatchSize int;  
  declare @rowsDeleted int;
  declare @deleteId bigint;
  
  declare @parameters nvarchar(max);
  declare @log nvarchar(max);
  declare @operationHistoryId bigint;

  set @eventsRowMaxBatchSize = 5000;  -- Internal batch size used when deleting ASEvents
  set @eventsRowDeleteCounter = 0;
  set @autoPurgeLockName = N'AutoPurgeThresholdLock';

  -- Implement the policy for @maxTimeStoreEventInDays
  if (@purgeTimeBoundaryMaxTimeStoreEventPolicy is not null)
  begin
    begin try
      set @parameters = N'APMaxEventAge=' + rtrim(ltrim(cast(@maxTimeStoreEventInDays as nchar))) + N',@cutoffUtcDateTime=' + convert(nvarchar, isnull(@purgeTimeBoundaryMaxTimeStoreEventPolicy, N''), 126);
      insert into [ASOperationsHistoryTable]
        ([OperationId], [StartTime], [Parameters], [Status], [UserLogin], [Log])
        values (3, current_timestamp, @parameters,  0, system_user, null);     
      set @operationHistoryId = scope_identity();
          
      exec @result = [ASInternal_PurgeEventData] 
        @purgeMode = 2,
        @cutoffUtcDateTime = @purgeTimeBoundaryMaxTimeStoreEventPolicy,
        @archive = 0,
        @doLog = 0;
        
      if (@result = 0)
      begin
        -- Log success
        update [ASOperationsHistoryTable]
          set [EndTime] = current_timestamp, 
            [Status] = 1
          where [Id] = @operationHistoryId;        
      end
      else
      begin
        -- Log error
        update [ASOperationsHistoryTable]
          set [EndTime] = current_timestamp, 
            [Status] = -1 
        where [Id] = @operationHistoryId;          
      end      
    end try
    begin catch
      -- Log error
      update [ASOperationsHistoryTable]
        set [EndTime] = current_timestamp, 
          [Status] = -1, 
          [Message]= error_message()
      where [Id] = @operationHistoryId;    
    end catch
  end;
                                
  -- Implement the policy to delete the oldest ASEvents based off @percentageAutoPurge
  if (@eventsRowDeleteCount > 0)
  begin    
    
    begin try
      
      set @parameters = N'APTrimPercentage=' + rtrim(ltrim(cast(@percentageAutoPurge as nchar))) + ',@eventsRowDeleteCount=' + rtrim(ltrim(cast(@eventsRowDeleteCount as nchar)));
      insert into [ASOperationsHistoryTable]
        ([OperationId], [StartTime], [Parameters], [Status], [UserLogin], [Log])
        values (3, current_timestamp, @parameters,  0, system_user, null);     
      set @operationHistoryId = scope_identity();
  
      exec @result = [sys].[sp_getapplock] @Resource=@autoPurgeLockName, @LockMode='Exclusive', @LockOwner='Session', @LockTimeout=90000;
      if @result < 0
      begin
          update [ASOperationsHistoryTable]
            set [EndTime] = current_timestamp, 
              [Status] = -1,
              [Message]= N'Unable to obtain application lock: ' + @autoPurgeLockName
          where [Id] = @operationHistoryId;    
         return;
      end      

      while (@eventsRowDeleteCounter < @eventsRowDeleteCount )
      begin   
          set @oldestWcfEventTime = (select top 1 [TimeCreated] from [ASWcfEventsTable] order by [TimeCreated] asc);
          set @oldestWfEventTime = (select top 1 [TimeCreated] from [ASWfEventsTable] order by [TimeCreated] asc);
          set @oldestWfEventPropertyTime = (select top 1 [TimeCreated] from [ASWfEventPropertiesTable] order by [TimeCreated] asc);
          set @oldestTransferEventTime = (select top 1 [TimeCreated] from [ASTransferEventsTable] order by [TimeCreated] asc);
          
          set @eventsRowBatchSize = @eventsRowMaxBatchSize;
          if (@eventsRowBatchSize + @eventsRowDeleteCounter > @eventsRowDeleteCount)
          begin
            set @eventsRowBatchSize = @eventsRowDeleteCount - @eventsRowDeleteCounter;
          end
          
          if (@oldestWcfEventTime is not null and
              (@oldestWfEventTime is null or @oldestWcfEventTime <= @oldestWfEventTime) and
              (@oldestWfEventPropertyTime is null or @oldestWcfEventTime <= @oldestWfEventPropertyTime) and
              (@oldestTransferEventTime is null or @oldestWcfEventTime <= @oldestTransferEventTime))
          begin            
            
            -- Delete from the WCF event table which has the oldest ASEvents
            select top (@eventsRowBatchSize) @oldestWcfEventTime = [TimeCreated] from [ASWcfEventsTable]
              order by [TimeCreated] asc;
            delete from [ASWcfEventsTable] where [TimeCreated] <= @oldestWcfEventTime;          
            set @rowsDeleted = @@rowcount;
                                                              
            set @eventsRowDeleteCounter = @eventsRowDeleteCounter + @rowsDeleted;
            set @purgeWcfEventTime = @oldestWcfEventTime;
            set @oldestPurgeEventTime = @purgeWcfEventTime;
          end;      
          else if (@oldestWfEventTime is not null and
              (@oldestWcfEventTime is null or @oldestWfEventTime <= @oldestWcfEventTime) and
              (@oldestWfEventPropertyTime is null or @oldestWfEventTime <= @oldestWfEventPropertyTime) and
              (@oldestTransferEventTime is null or @oldestWfEventTime <= @oldestTransferEventTime))
          begin
            -- Delete from the WF event table which has the oldest ASEvents
            select top (@eventsRowBatchSize) @oldestWfEventTime = [TimeCreated] from [ASWfEventsTable]
              order by [TimeCreated] asc;
            delete from [ASWfEventsTable] where [TimeCreated] <= @oldestWfEventTime;          
            set @rowsDeleted = @@rowcount;
                        
            set @eventsRowDeleteCounter = @eventsRowDeleteCounter + @rowsDeleted;
            -- We can reuse the same @purgeWfEventTime to clean up the related WF event tables.
            set @purgeWfEventTime = @oldestWfEventTime;
            set @oldestPurgeEventTime = @purgeWfEventTime;
          end;          
          else if (@oldestWfEventPropertyTime is not null and
              (@oldestWcfEventTime is null or @oldestWfEventPropertyTime <= @oldestWcfEventTime) and
              (@oldestWfEventTime is null or @oldestWfEventPropertyTime <= @oldestWfEventTime) and
              (@oldestTransferEventTime is null or @oldestWfEventPropertyTime <= @oldestTransferEventTime))
          begin
            -- Delete from the WF event property table.  
            select top (@eventsRowBatchSize) @oldestWfEventPropertyTime = [TimeCreated] from [ASWfEventsTable]
              order by [TimeCreated] asc;
            delete from [ASWfEventPropertiesTable] where [TimeCreated] <= @oldestWfEventPropertyTime;          
            set @rowsDeleted = @@rowcount;
                        
            set @eventsRowDeleteCounter = @eventsRowDeleteCounter + @rowsDeleted;
            set @purgeWfEventTime = @oldestWfEventPropertyTime;
            set @oldestPurgeEventTime = @oldestWfEventPropertyTime;          
          end;          
          else if (@oldestTransferEventTime is not null and
              (@oldestWfEventTime is null or @oldestTransferEventTime <= @oldestWfEventTime) and
              (@oldestWfEventPropertyTime is null or @oldestTransferEventTime <= @oldestWfEventPropertyTime) and
              (@oldestWcfEventTime is null or @oldestTransferEventTime <= @oldestWcfEventTime))
          begin
            -- Delete from the Transfer event table which has the oldest ASEvents
            select top (@eventsRowBatchSize) @oldestTransferEventTime = [TimeCreated] from [ASTransferEventsTable]
              order by [TimeCreated] asc;
            delete from [ASTransferEventsTable] where [TimeCreated] <= @oldestTransferEventTime;          
            set @rowsDeleted = @@rowcount;
                        
            set @eventsRowDeleteCounter = @eventsRowDeleteCounter + @rowsDeleted;
            set @purgeTransferEventTime = @oldestTransferEventTime;
            set @oldestPurgeEventTime = @purgeTransferEventTime;
          end;   
          else
          begin
            -- No more ASEvents. Finish.
            break;
          end;          
      end;
          
      -- Cleanup WCF event related tables          
      if (@purgeWcfEventTime is not null)
      begin
        exec @result = [ASInternal_PurgeEventData] 
          @purgeMode = 2,
          @cutoffUtcDateTime = @purgeWcfEventTime,
          @archive = 0,
          @doLog = 0,
          @eventType = N'WCF';
      end;
      
      -- Cleanup WF event related tables
      if (@purgeWfEventTime is not null)
      begin
        exec @result = [ASInternal_PurgeEventData] 
          @purgeMode = 2,
          @cutoffUtcDateTime = @purgeWfEventTime,
          @archive = 0,
          @doLog = 0,
          @eventType = N'WF';
      end;

      -- Cleanup transfer event related tables
      if (@purgeTransferEventTime is not null)
      begin
        exec @result = [ASInternal_PurgeEventData] 
          @purgeMode = 2,
          @cutoffUtcDateTime = @purgeTransferEventTime,
          @archive = 0,
          @doLog = 0,
          @eventType = N'TRANSFER';
      end;            
            
      -- Log update
      set @log = N'EventsDeleted=' + rtrim(ltrim(cast(@eventsRowDeleteCounter as nchar))) + N';PurgeDateTimeBoundary=' + convert(nvarchar, isnull(@oldestPurgeEventTime, N''), 126);
      update [ASOperationsHistoryTable]
        set [Log] = @log
        where [Id] = @operationHistoryId;
            
      -- Check if we need to delete from ASStagingTable.  If so, set appropriate flag and Import jobs will perform the delete.                  
      while (@eventsRowDeleteCounter < @eventsRowDeleteCount)
      begin         
        set @eventsRowBatchSize = @eventsRowMaxBatchSize;
        if (@eventsRowBatchSize + @eventsRowDeleteCounter > @eventsRowDeleteCount)
        begin
          set @eventsRowBatchSize = @eventsRowDeleteCount - @eventsRowDeleteCounter;
        end        
      
        set @oldestWfEventId = (select top 1 [Id] from [ASStagingTable] where [EventTypeId] >= 100 and [EventTypeId] <= 199 order by [Id] asc);
        set @oldestWcfEventId = (select top 1 [Id] from [ASStagingTable] where [EventTypeId] >= 200 and [EventTypeId] <= 399 order by [Id] asc);
        set @oldestTransferEventId = (select top 1 [Id] from [ASStagingTable] where [EventTypeId] >= 400 and [EventTypeId] <= 499 order by [Id] asc);
      
        if (@oldestWfEventId is not null and
            (@oldestWcfEventId is null or @oldestWfEventId <= @oldestWcfEventId) and
            (@oldestTransferEventId is null or @oldestWfEventId <= @oldestTransferEventId))
        begin
          select top (@eventsRowBatchSize) @deleteId = [Id] from [ASStagingTable]
            where [EventTypeId] >= 100 and [EventTypeId] <= 199
            order by [Id] asc;          

          if (@deleteId is null)
            break;
            
          delete from [ASStagingTable] 
            where [EventTypeId] >= 100 and [EventTypeId] <= 199
            and [Id] <= @deleteId;
          set @rowsDeleted = @@rowcount;
          
          set @eventsRowDeleteCounter = @eventsRowDeleteCounter + @rowsDeleted;
        end;        
        else if (@oldestWcfEventId is not null and
            (@oldestWfEventId is null or @oldestWcfEventId <= @oldestWfEventId) and
            (@oldestTransferEventId is null or @oldestWcfEventId <= @oldestTransferEventId))
        begin
          select top (@eventsRowBatchSize) @deleteId = [Id] from [ASStagingTable]
            where [EventTypeId] >= 200 and [EventTypeId] <= 399
            order by [Id] asc;          

          if (@deleteId is null)
            break;
            
          delete from [ASStagingTable] 
            where [EventTypeId] >= 200 and [EventTypeId] <= 399
            and [Id] <= @deleteId;
          set @rowsDeleted = @@rowcount;
          
          set @eventsRowDeleteCounter = @eventsRowDeleteCounter + @rowsDeleted;
        end;
        else if (@oldestTransferEventId is not null and
            (@oldestWcfEventId is null or @oldestTransferEventId <= @oldestWcfEventId) and
            (@oldestWfEventId is null or @oldestTransferEventId <= @oldestWfEventId))
        begin
          select top (@eventsRowBatchSize) @deleteId = [Id] from [ASStagingTable]
            where [EventTypeId] >= 400 and [EventTypeId] <= 499
            order by [Id] asc;          

          if (@deleteId is null)
            break;
            
          delete from [ASStagingTable] 
            where [EventTypeId] >= 400 and [EventTypeId] <= 499
            and [Id] <= @deleteId;
          set @rowsDeleted = @@rowcount;
          
          set @eventsRowDeleteCounter = @eventsRowDeleteCounter + @rowsDeleted;
        end;                
        else
        begin
          -- No more ASEvents
          break;
        end;
      end;
            
      -- Log success
      set @log = N'EventsDeleted=' + rtrim(ltrim(cast(@eventsRowDeleteCounter as nchar))) + N';PurgeDateTimeBoundary=' + convert(nvarchar, isnull(@oldestPurgeEventTime, N''), 126);
      update [ASOperationsHistoryTable]
        set [EndTime] = current_timestamp, 
          [Status] = 1, 
          [Log] = @log
        where [Id] = @operationHistoryId;
    end try
    begin catch
      exec [ASInternal_RethrowError];
      
      -- Log error
      set @log = N'EventsDeleted=' + rtrim(ltrim(cast(@eventsRowDeleteCounter as nchar))) + N';PurgeDateTimeBoundary=' + convert(nvarchar, isnull(@oldestPurgeEventTime, N''), 126);
      update [ASOperationsHistoryTable]
        set [EndTime] = current_timestamp, 
          [Status] = -1,
          [Log] = @log,
          [Message]= error_message()
      where [Id] = @operationHistoryId;    
    end catch    
    
    exec [sys].[sp_releaseapplock] @autoPurgeLockName, 'Session';
  end;  
    
  exec sp_releaseapplock @lockName, 'Session';         
  return 0;
end;