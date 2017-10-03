create procedure [ASInternal_ImportTransferEvents]
(@batchSize int,
@errorNumber int out,
@errorMessage nvarchar(2048) out)
as 
  declare @result int;
  declare @resultTemp int;
  declare @lockName nvarchar(255);
  declare @autoPurgeLockName nvarchar(255);
  declare @hasAutoPurgeLock int;
  declare @autopurgeCheckCounter int;
    
  declare @stopId bigint;  
  declare @curId bigint;  
  declare @endId bigint;
  
  declare @eventSourceId int;
  declare @computer nvarchar(450);
  declare @eventSource nvarchar(1024);
  
  set @result = 0;  
      
  set @stopId = (select top 1 [Id] from [ASStagingTable] where
    [EventTypeId] = 499
    order by [Id] desc);  
  if (@stopId is null)
    return @result;
  
  set @lockName = N'[ImportTransferEventsLock]';

  set @autopurgeCheckCounter = 0;
  set @autoPurgeLockName = N'AutoPurgeThresholdLock';
  set @hasAutoPurgeLock = -1;
  
  exec @result = [sys].[sp_getapplock] @Resource=@lockName, @LockMode='Exclusive', @LockOwner='Session', @LockTimeout=100;
  if @result < 0
  begin
    return 1;
  end  
        
  select top 1 @curId=[Id], @computer=[Computer], @eventSource=[EventSource] from [ASStagingTable]
    where ([EventTypeId] = 499) 
    order by [Id] asc;  
                
  while (@curId is not null and @curId <= @stopId)
  begin    
    -- Check if we need to delete from ASStagingTable because of ASAutoPurge.      
    if ((@autopurgeCheckCounter % 10) = 0)
    begin
      if @hasAutoPurgeLock = 0
      begin          
        exec [sys].[sp_releaseapplock] @autoPurgeLockName, 'Session';
        set @hasAutoPurgeLock = -1;
      end
    
      exec @hasAutoPurgeLock = [sys].[sp_getapplock] @Resource=@autoPurgeLockName, @LockMode='Shared', @LockOwner='Session', @LockTimeout=100;
      if @hasAutoPurgeLock < 0
      begin
         break;
      end  
      set @autopurgeCheckCounter = 0;
    end;
    set @autopurgeCheckCounter = @autopurgeCheckCounter + 1;  
  
    if (@eventSource is null)
      set @eventSource = N'';
    
    select top (@batchSize) @endId = [Id] from [ASStagingTable]
      where (([EventTypeId] = 499)) and
        [EventSource] = @eventSource and
        [Computer] = @computer
        order by [Id] asc;      
    
    begin try

      begin transaction;
  
      exec [ASInternal_GetEventSourceId]
        @computer,
        @eventSource,
        @eventSourceId output;
      
      insert into [ASTransferEventsTable]
        ([Id], [EventTypeId], [E2EActivityId], [EventSourceId], [ProcessId], [TraceLevelId], [TimeCreated],
        [ToE2EActivityId])
      select 
        case 
          when [ArchiveId] = 0 then [Id]
          else [ArchiveId]
        end,        
        [EventTypeId], [E2EActivityId], @eventSourceId, [ProcessId], [TraceLevelId], [TimeCreated],
        [Data1UniqueId]
        from [ASStagingTable]                     
      where (([EventTypeId] = 499)) and
        [EventSource] = @eventSource and
        [Computer] = @computer and
            [Id] <= @endId;              

      delete from [ASStagingTable]
        where (([EventTypeId] = 499)) and
          [EventSource] = @eventSource and
          [Computer] = @computer and        
              [Id] <= @endId;              
    
      commit transaction;
            
    end try
    begin catch
      if (@@TRANCOUNT > 0)
        rollback transaction;

      -- If we fail to process the batch, we will try to process the batch row by row      
      exec @resultTemp = [ASInternal_ImportEvents]
        400,
        499,
        @curId,
        @endId,
        @errorNumber out,
        @errorMessage out;        
          
      -- Save the last error    
      if (@resultTemp < 0)
        set @result = @resultTemp;
    end catch            

    set @curId = null;
    select top 1 @curId=[Id], @computer=[Computer], @eventSource=[EventSource] from [ASStagingTable]
      where ([EventTypeId] = 499) 
      order by [Id] asc;              
  end;      
  
  if @hasAutoPurgeLock = 0
  begin          
    exec [sys].[sp_releaseapplock] @autoPurgeLockName, 'Session';
    set @hasAutoPurgeLock = -1;
  end  
    
  exec [sys].[sp_releaseapplock] @lockName, 'Session';
        
  return @result;