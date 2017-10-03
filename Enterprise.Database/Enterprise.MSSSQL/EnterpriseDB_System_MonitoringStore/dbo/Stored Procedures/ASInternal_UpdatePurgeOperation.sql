create procedure [ASInternal_UpdatePurgeOperation] @operationHistoryId bigint, 
 @recordCount bigint, @totalRecords bigint, @log nvarchar(max)
as 
begin   
  declare @progress bigint;
  
  if (@totalRecords = 0)
    set @progress = 0;
  else if @totalRecords < 0
    set @progress = @recordCount;
  else
    set @progress = cast(round(99.0 * cast(@recordCount as float) / @totalRecords, 0) as bigint); 
   
  declare @xmlMessage nvarchar(max);
  set @xmlMessage = N'<purge><progress value="' + cast(@progress as nvarchar) + N'"/>' + @log + N'</purge>';
    
  update [ASOperationsHistoryTable]
  set [Log] = @xmlMessage
  where Id = @operationHistoryId;
    
end