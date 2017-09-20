create procedure [ASInternal_ArchivePurgeTable]
  @tableName sysname,
  @cutoffUtcDateTime datetime2,		  
  @useTransaction bit,
  @operationHistoryId bigint,
  @batchSize int,
  @totalRecordCount bigint,
  @purgeRecordCount bigint out,  
  @log nvarchar(max) out,
  @archiveSql nvarchar(max),  
  @importEventsSproc nvarchar(max),
  @deleteSql nvarchar(max) = null,
  @getBatchSql nvarchar(max) = null
as
begin	     
  -- Generic method to archive/purge a table in batches based on a cutoff date time
  
  declare @sqlTableName sysname;
  declare @getBatchSqlParamDef nvarchar(200);
  declare @purgeParamDef nvarchar(100);
  declare @currentRecordCount bigint;
  declare @tablePurgeStartTime datetime2;
  declare @batchCount int;  

  set @sqlTableName = N'' + quotename(@tableName);        
  set @getBatchSqlParamDef = N'@batchSize int, @cutoffUtcDateTime datetime2, @batchStartTime datetime2 out, @batchEndTime datetime2 out';         
  set @purgeParamDef = N'@batchStartTime datetime2, @batchEndTime datetime2';
  
  if @getBatchSql is null
    set @getBatchSql = N'select @batchStartTime = min([TimeCreated]), @batchEndTime = max ([TimeCreated])
         from (select top (@batchSize) [TimeCreated] from ' + @sqlTableName + N' where [TimeCreated] < @cutoffUtcDateTime
         order by [TimeCreated]) as Batch'; 
  
  if @deleteSql is null
    set @deleteSql = N'delete from ' + @sqlTableName + N' where [TimeCreated] between @batchStartTime and @batchEndTime';
      
  set @currentRecordCount = @purgeRecordCount;
  set @tablePurgeStartTime = current_timestamp;
  set @batchCount = 0;  
  
  while 1 = 1
  begin               
    declare @batchStartTime datetime2;
    declare @batchEndTime datetime2;
    declare @progress int;
    declare @tableRecordCount bigint;
    declare @executionTime int;

    set @progress = 0;
                                           
    -- Get a date range for the next batch
    exec [sys].[sp_executesql] @getBatchSql, @getBatchSqlParamDef, @batchSize, @cutoffUtcDateTime, @batchStartTime out, @batchEndTime out;
                  
    if @batchStartTime is null
      break;
                  
    -- Use transactions if the archive db is on the same server
    if @useTransaction = 1
      begin transaction;
      
    -- Archive data into the archive database staging table      
    if @archiveSql is not null         
      exec [sys].[sp_executesql] @archiveSql, @purgeParamDef, @batchStartTime, @batchEndTime;
    
    -- delete the data          
    exec [sys].[sp_executesql] @deleteSql, @purgeParamDef, @batchStartTime, @batchEndTime;
    
    set @currentRecordCount = @currentRecordCount + @@rowcount; 
    
    if @useTransaction = 1
      commit transaction;  
      
    -- If we archived, we need to run ASImportEvents
    if @archiveSql is not null               
      exec [sys].[sp_executesql] @importEventsSproc;      
      
    -- Update progress		
    set @batchCount = @batchCount + 1;   		  
    exec [ASInternal_UpdatePurgeOperation] @operationHistoryId, 
      @currentRecordCount, @totalRecordCount, @log;
  end  
  
  -- Create log entry for the table purge  
  set @tableRecordCount = @currentRecordCount - @purgeRecordCount;
  set @executionTime = datediff(second, @tablePurgeStartTime, current_timestamp);
  exec [ASInternal_AddTableToPurgeLog] @log out, @tableName, @batchCount, 
    @tableRecordCount, @executionTime;
  
  set @purgeRecordCount = @currentRecordCount;
  
end