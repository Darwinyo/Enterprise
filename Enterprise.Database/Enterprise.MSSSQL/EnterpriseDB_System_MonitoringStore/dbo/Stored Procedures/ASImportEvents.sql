create procedure [ASImportEvents]
(@batchSize int = 1000)
as 
begin
  set nocount on;
  set deadlock_priority low;
  set transaction isolation level read committed;

  declare @ret int;
  declare @retTemp int;

  declare @jobIdentifier nvarchar(128);
  declare @lastRunSuccess bit;
  declare @errorNumber int;
  declare @errorMessage nvarchar(2048);
  declare @errorNumberTemp int;
  declare @errorMessageTemp nvarchar(2048);
  
  set @jobIdentifier = N'ASImportEvents';
  set @lastRunSuccess = 1;  
  
  exec @ret = [ASInternal_ImportWcfEvents] 
    @batchSize,
    @errorNumber out,
    @errorMessage out;
  
  exec @retTemp = [ASInternal_ImportTransferEvents] 
    @batchSize,
    @errorNumberTemp out,
    @errorMessageTemp out;
    
  if (@retTemp < 0)
  begin
    set @ret = @retTemp;
    set @errorNumber = @errorNumberTemp;
    set @errorMessage = @errorMessageTemp;
  end
    
  exec @retTemp = [ASInternal_ImportWfEvents]
    @batchSize,
    @errorNumberTemp out,
    @errorMessageTemp out;  

  if (@retTemp < 0)
  begin
    set @ret = @retTemp;
    set @errorNumber = @errorNumberTemp;
    set @errorMessage = @errorMessageTemp;
  end
  
  if (@ret < 0)
    set @lastRunSuccess = 0;  

  -- Update the job status
  update [ASJobsTable] set	
    [LastRunTime] = getutcdate(),
    [IsLastRunSuccess] = @lastRunSuccess,
    [LastErrorCode] = @errorNumber,
    [LastError] = @errorMessage
    where [JobIdentifier] = @jobIdentifier; 
    
  return @ret;
end
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[ASImportEvents] TO [ASMonitoringDbWriter]
    AS [dbo];

