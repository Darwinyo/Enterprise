create procedure [ASAutoPurge]
as
begin
  set nocount on;
  set transaction isolation level read committed;
  set deadlock_priority low;
    
  declare @jobIdentifier nvarchar(128);
  declare @lastRunSuccess bit;
  declare @errorNumber int;
  declare @errorMessage nvarchar(2048);
  declare @result int;  
  
  set @jobIdentifier = N'ASAutoPurge';
  set @lastRunSuccess = 1;  
  
  begin try
    exec @result = [ASInternal_AutoPurge];
  end try
  begin catch
    set @lastRunSuccess = 0;
    set @errorNumber = error_number();
    set @errorMessage = error_message();
    
    exec [ASInternal_RethrowError];
  end catch;
  
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
    ON OBJECT::[dbo].[ASAutoPurge] TO [ASMonitoringDbAdmin]
    AS [dbo];

