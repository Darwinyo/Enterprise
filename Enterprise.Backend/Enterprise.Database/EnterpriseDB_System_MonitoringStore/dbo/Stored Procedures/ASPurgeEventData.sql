create procedure [ASPurgeEventData]
  @purgeMode int, -- 1:instance base, 2:time base
  @cutoffUtcDateTime datetime2,		
  @archive bit,
  @operationReference nvarchar(64) = null
as
begin	 
  set nocount on; 

  declare @lockName nvarchar(255);
  declare @result int;
  declare @apEnabled bit;
  
  set @lockName = N'[PurgeEventDataLock]';  
  if @purgeMode is null or (@purgeMode <> 1 and @purgeMode <> 2)
  begin
     exec [ASInternal_ThrowError] 101, 
       N'Invalid purge mode. Valid values are 1 for instance based purge and 2 for time based purge', 0;
      return -1;
  end

  if @archive is null
  begin
     exec [ASInternal_ThrowError] 105, 
       N'Invalid archive mode. Valid values are 0 for purge data and 1 for archive data.', 0;
      return -1;
  end           
             
  -- Try to acquire an application lock  
  exec @result = [sys].[sp_getapplock] @Resource=@lockName, @LockMode='Exclusive', @LockOwner='Session', @LockTimeout=100;  
    
  if @result < 0
  begin 
    set @apEnabled = (select top 1 [APEnabled] from [ASConfigurationPropertiesTable]);
    if @apEnabled = 1
    begin
      exec [ASInternal_ThrowError] 106, N'You cannot manually purge ASEvents from the database at this time. Your system is configured to automatically purge ASEvents from the database periodically. If you would like to manually remove ASEvents, please disable automatic purging by setting the ''APEnabled'' configuration property to ''0''.', 0;
      return -1;      
    end
    else
    begin  
      exec [ASInternal_ThrowError] 102, N'You cannot purge ASEvents from the database at this time. Another purge operation is already in progress.', 0;
      return -1;
    end
  end
  
  set @result = 0;
  
  exec @result = [ASInternal_PurgeEventData]
    @purgeMode = @purgeMode,
    @cutoffUtcDateTime = @cutoffUtcDateTime,
    @archive = @archive,
    @operationReference = @operationReference,
    @doLog = 1,
    @eventType = N'ALL';
  
  -- Try to release the application lock
  exec [sys].[sp_releaseapplock] @lockName, 'Session';
  
  return @result;
end
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[ASPurgeEventData] TO [ASMonitoringDbAdmin]
    AS [dbo];

