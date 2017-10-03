create procedure [ASInternal_AddTableToPurgeLog] @log nvarchar(max) out, 
  @tableName sysname,  @batchCount int, @totalRecords bigint, @totalTime int
as 
begin
  declare @avgBatchTime bigint;
  
  if @totalTime <> 0 and @batchCount <> 0
    set @avgBatchTime = cast(@totalTime / (cast(@batchCount as float)) as bigint);
  else
    set @avgBatchTime = 0;
  
  set @log = @log +  N'<table name="' + @tableName + N'" batches="' + cast(@batchCount as nvarchar) +
   N'" totalRecords="' + cast(@totalRecords as nvarchar) + N'" totalTime="' + cast(@totalTime as nvarchar) + 
   N'" avgBatchTime="' + cast(@avgBatchTime as nvarchar) + N'"/>';
end