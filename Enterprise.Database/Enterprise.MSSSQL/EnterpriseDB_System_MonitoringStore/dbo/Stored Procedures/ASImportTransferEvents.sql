create procedure [ASImportTransferEvents]
(@batchSize int = 1000)
as
begin
  set nocount on;
  set deadlock_priority low;
  set transaction isolation level read committed;

  declare @jobIdentifier nvarchar(128);
  declare @lastRunSuccess bit;
  declare @errorNumber int;
  declare @errorMessage nvarchar(2048);
  declare @result int;
    
  set @jobIdentifier = N'ASImportTransferEvents';
  set @lastRunSuccess = 1;  

  exec @result = [ASInternal_ImportTransferEvents]
    @batchSize,
    @errorNumber out,
    @errorMessage out;
    
  if (@result < 0)
    set @lastRunSuccess = 0;  

  -- Update the job status
  update [ASJobsTable] set	
    [LastRunTime] = getutcdate(),
    [IsLastRunSuccess] = @lastRunSuccess,
    [LastErrorCode] = @errorNumber,
    [LastError] = @errorMessage
    where [JobIdentifier] = @jobIdentifier; 
    
  return @result;    
end;
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[ASImportTransferEvents] TO [ASMonitoringDbWriter]
    AS [dbo];

