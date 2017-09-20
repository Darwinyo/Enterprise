create procedure [ASInternal_ImportWfEvents]
(@batchSize int,
@errorNumber int out,
@errorMessage nvarchar(2048) out)
as 
  declare @lockName nvarchar(255);
  declare @result int;
  declare @resultTemp int;
  declare @stopId bigint; 
        
  set @lockName = N'[ImportWfEventsLock]';
  exec @result = sp_getapplock @Resource=@lockName, @LockMode='Exclusive', @LockOwner='Session', @LockTimeout=100;    
  if @result < 0
  begin
    return 1;
  end;
  
  set @stopId = (select top 1 [Id] from [ASStagingTable] where
    [EventTypeId] >= 100 and 
    [EventTypeId] <= 199
    order by [Id] desc);

  -- First move the WF ASEvents that do not need to be shredded (batch insert)
  exec @result = [ASInternal_ImportWfEventsBatch] @stopId, @batchSize, @errorNumber out, @errorMessage out;
  
  -- Then move the WF ASEvents that need to be shredded row by row  
  exec @resultTemp = [ASInternal_ImportWfEventsRow] @stopId, @errorNumber out, @errorMessage out;
  if (@resultTemp < 0)
  begin
    set @result = @resultTemp;
  end
    
  exec sp_releaseapplock @lockName, 'Session';  
    
  return @result;