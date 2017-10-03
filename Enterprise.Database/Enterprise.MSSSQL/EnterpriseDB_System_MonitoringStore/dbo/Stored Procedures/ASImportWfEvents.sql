create procedure [ASImportWfEvents]
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
    
  set @jobIdentifier = N'ASImportWfEvents';
  set @lastRunSuccess = 1;  

  exec @result = [ASInternal_ImportWfEvents]
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
    ON OBJECT::[dbo].[ASImportWfEvents] TO [ASMonitoringDbWriter]
    AS [dbo];

