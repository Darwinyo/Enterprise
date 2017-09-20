create procedure [ASInternal_ArchivePurgeWFEvents]  
  @cutoffUtcDateTime datetime2,
  @archiveTableName nvarchar(max),		
  @useTransaction bit,
  @operationHistoryId bigint,
  @batchSize int,
  @totalRecordCount bigint,
  @purgeRecordCount bigint out,  
  @log nvarchar(max) out, 
  @archiveSql nvarchar(max),
  @importEventsSproc nvarchar(max)
as
begin	     
  -- Implements workflow event archive and purged for completed instances
  
  declare @archiveParamDef nvarchar(100);
  declare @currentRecordCount bigint;
  declare @tablePurgeStartTime datetime2;
  declare @batchCount int;         
  declare @rowCount int;  

  set @archiveParamDef = N'@batchSize int, @cutoffUtcDateTime datetime2';
  set @currentRecordCount = @purgeRecordCount;
  set @tablePurgeStartTime = current_timestamp;
  set @batchCount = 0;         
  set @rowCount = 1;
        
  while @rowCount > 0
  begin   
                                                                 
    -- Use transactions if the archive db is on the same server
    if @useTransaction = 1
      begin transaction;
      
    -- Archive data into the archive database staging table      
    if @archiveTableName is not null  
    begin
      exec [sys].[sp_executesql] @archiveSql, @archiveParamDef, @batchSize, @cutoffUtcDateTime;     
      if @@rowcount = 0
      begin
        if @@trancount > 0
          rollback;
        break;
      end      
    end  
                                
    -- delete the data  
    if (@useTransaction = 0)
      begin transaction; -- use a local transaction for the two delete statements
      
    delete from [ASWfEventProperties]
    from [ASWfEventProperties] PT JOIN
         [ASWfEventsTable] ET ON PT.[EventId] = ET.[Id]
    where ET.[WorkflowInstanceId] in 
      (select top(@batchSize) [WorkflowInstanceId]
       from [ASWfInstances]
       where [LastModifiedTime] < @cutoffUtcDateTime and
          ([LastEventStatus] = N'Completed' or
          [LastEventStatus] = N'Terminated' or
          [LastEventStatus] = N'Canceled')       
       order by [LastModifiedTime]);
          
    delete from [ASWfEventsTable]
    where [WorkflowInstanceId] in 
      (select top(@batchSize) [WorkflowInstanceId]
       from [ASWfInstances]
       where [LastModifiedTime] < @cutoffUtcDateTime and
          ([LastEventStatus] = N'Completed' or
          [LastEventStatus] = N'Terminated' or
          [LastEventStatus] = N'Canceled')
       order by [LastModifiedTime]);

    set @rowCount = @@rowcount;
    
    if (@rowCount > 0)
    begin
      set @batchCount = @batchCount + 1;
      set @currentRecordCount = @currentRecordCount + @rowCount;
      exec [ASInternal_UpdatePurgeOperation]
        @operationHistoryId, @currentRecordCount, @totalRecordCount, @log;
    end
    
    commit transaction;       
    
    -- If we archived, we need to run ASImportEvents
    if @archiveSql is not null               
      exec [sys].[sp_executesql] @importEventsSproc;             		  
  end  
  
  -- Create log entry for the table purge  
  declare @tableRecordCount bigint;
  declare @executionTime int;

  set @tableRecordCount = @currentRecordCount - @purgeRecordCount;
  set @executionTime = datediff(second, @tablePurgeStartTime, current_timestamp);
  exec [ASInternal_AddTableToPurgeLog] @log out, 'ASWfEventsTable', @batchCount, 
    @tableRecordCount, @executionTime;
  
  set @purgeRecordCount = @currentRecordCount;
  
end