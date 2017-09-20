-- This is called by the ASImportWcfEvents, ASImportTransferEvents, ImportWfEventsBatch in 
-- the case when a batch fails to get moved from ASStagingTable.
-- This sproc will process the failed batch row by row.
-- Note: For WF ASEvents, this sproc upholds the same semantics as ImportWfEventsBatch, only
--       process WF ASEvents that do not have custom variables or annotations.
create procedure [ASInternal_ImportEvents]
(@eventTypeIdStart int,
@eventTypeIdEnd int,
@eventIdStart bigint,
@eventIdEnd bigint,
@errorNumber int out,
@errorMessage nvarchar(2048) out)
as
  declare @result int;
    
  declare @originalId bigint;
  declare @id bigint;
  declare @archiveId bigint;
  declare @eventTypeId int;
  declare @e2eActivityId nvarchar(36);	
  declare @computer nvarchar(450);
  declare @eventSource nvarchar(1024);
  declare @processId int;
  declare @traceLevelId tinyint;
  declare @timeCreated datetime2;

  declare @data1Str nvarchar(450);
  declare @data2Str nvarchar(450);
  declare @data3Str nvarchar(450);
  declare @data4Str nvarchar(450);
  declare @data5Str nvarchar(450);
  declare @data6Str nvarchar(450);
  declare @data7Str nvarchar(450);
  declare @data8Str nvarchar(450);
  declare @data9Str nvarchar(450);
  declare @data1MaxStr nvarchar(max);
  declare @data1Int int;	
  declare @data2Int int;	
  declare @data3Int int;	
  declare @data1BigInt bigint;
  declare @data1UniqueIdentifier nvarchar(36);
  
  declare @eventSourceId int;
  declare @trackingProfileId int;

  set @result = 0;  
      
  declare eventCursor cursor forward_only fast_forward for select
    Id,
    ArchiveId,
    EventTypeId,
    E2EActivityId,
    Computer,
    EventSource,
    ProcessId,
    TraceLevelId,
    TimeCreated,
    Data1Str,
    Data2Str,
    Data3Str,
    Data4Str,
    Data5Str,
    Data6Str,
    Data7Str,
    Data8Str,
    Data9Str,
    Data1MaxStr,
    Data1Int,
    Data2Int,
    Data3Int,
    Data1BigInt,
    Data1UniqueId
   from [ASStagingTable] 
   where 
    [EventTypeId] >= @eventTypeIdStart and 
    [EventTypeId] <= @eventTypeIdEnd and
    ([CustomProperties] is null or [CustomProperties] = N'<items />') and
    ([CustomAnnotations] is null or [CustomAnnotations] = N'<items />') and    
    ([CustomArguments] is null or [CustomArguments] = N'<items />') and    
    [Id] >= @eventIdStart and
    [Id] <= @eventIdEnd
   order by [Id] asc;	
   
  open eventCursor;
  
  fetch next from eventCursor into 
    @id,
    @archiveId,
    @eventTypeId,
    @e2eActivityId,
    @computer,
    @eventSource,
    @processId,
    @traceLevelId,
    @timeCreated,
    @data1Str,
    @data2Str,
    @data3Str,
    @data4Str,
    @data5Str,
    @data6Str,
    @data7Str,
    @data8Str,
    @data9Str,
    @data1MaxStr,	
    @data1Int,
    @data2Int,
    @data3Int,
    @data1BigInt,
    @data1UniqueIdentifier;
    
  while (@@fetch_status = 0)
  begin

    begin try    
    
      begin transaction;
    
      set @originalId = @id;
      if (@archiveId >= 1)
      begin
        -- This indicates the row was copied to Staging as a result of the archiving process
        -- Use the ArchiveId as the event Id.
        set @id = @archiveId;
      end;
      
      exec [ASInternal_GetEventSourceId]
        @computer,
        @eventSource,
        @eventSourceId output;
                          
      if (@eventTypeId >= 100 and @eventTypeId < 200) -- WF tracking records
      begin		      
        exec [ASInternal_GetWfTrackingProfileId]
          @data1Str,
          @trackingProfileId output;
                
        insert into [ASWfEventsTable] 
          ([Id], [EventTypeId], [EventSourceId], [ProcessId], [TraceLevelId], [WorkflowInstanceId], [RecordNumber], [TrackingProfileId], [TimeCreated],
          [Data1Str], 
          [Data2Str],
          [Data3Str],
          [Data4Str],
          [Data5Str],
          [Data6Str],
          [Data7Str],
          [Data8Str],
          [Data1MaxStr],
          [Data1Int])
        values
          (@id, @eventTypeId, @eventSourceId, @processId, @traceLevelId, @data1UniqueIdentifier, @data1BigInt, @trackingProfileId, @timeCreated,
          @data2Str,
          @data3Str,
          @data4Str,
          @data5Str,
          @data6Str,
          @data7Str,
          @data8Str,
          @data9Str,
          @data1MaxStr,
          @data1Int);
      end;
      else if ((@eventTypeId >= 200 and @eventTypeId < 300)) -- WCF ASEvents
      begin
        insert into [ASWcfEventsTable] 
          ([Id], [EventTypeId], [E2EActivityId], [EventSourceId], [ProcessId], [TraceLevelId], [TimeCreated],
          [Data1Str],
          [Data2Str],
          [Data3Str],
          [Data4Str],
          [Data1MaxStr],
          [Data1Int],
          [Data2Int],
          [Data3Int],
          [Data1UniqueIdentifier])
        values
          (@id, @eventTypeId, @e2eActivityId, @eventSourceId, @processId, @traceLevelId, @timeCreated,
          @data1Str,
          @data2Str,
          @data3Str,
          @data4Str,
          @data1MaxStr,
          @data1Int,
          @data2Int,
          @data3Int,
          @data1UniqueIdentifier); -- CorrelationId  
      end;
      else if (@eventTypeId = 499) -- TransferEvent
      begin							
        insert into [ASTransferEventsTable]
          ([Id], [EventTypeId], [E2EActivityId], [EventSourceId], [ProcessId], [TraceLevelId], [TimeCreated],
          [ToE2EActivityId])
        values
          (@id, @eventTypeId, @e2eActivityId, @eventSourceId, @processId, @traceLevelId, @timeCreated,
          @data1UniqueIdentifier); -- RelatedActivityId
      end;
      else 
      begin -- Error case
        exec [ASInternal_ThrowError] 302, N'Unknown EventTypeId.';
      end;						
                    
      delete from [ASStagingTable] where [Id] = @originalId;
      
      commit transaction;
    end try
    begin catch
      set @result = -1;
    
      if (@@trancount > 0)
        rollback transaction;
            
      select @errorNumber = error_number();      
      select @errorMessage = error_message();
      
      -- When we are archiving and get SQL error 2627: Violation of primary key on (Id, TimeCreated), we must cleanup the staging table.  
      -- This is a duplicate row which can be safely deleted.
      if (@archiveId >= 1 and @errorNumber = 2627)
      begin
        delete from [ASStagingTable] where [Id] = @originalId;
      end
      else
      begin        
        exec [ASInternal_MoveEventToFailedStaging]
          @originalId,
          @errorNumber,
          @errorMessage;          
      end;  
    end catch;
    
   fetch next from eventCursor into 
    @id,
    @archiveId,
    @eventTypeId,
    @e2eActivityId,
    @computer,
    @eventSource,
    @processId,
    @traceLevelId,
    @timeCreated,
    @data1Str,
    @data2Str,
    @data3Str,
    @data4Str,
    @data5Str,
    @data6Str,
    @data7Str,
    @data8Str,
    @data9Str,
    @data1MaxStr,	
    @data1Int,
    @data2Int,
    @data3Int,
    @data1BigInt,
    @data1UniqueIdentifier;
  end;
  
  close eventCursor;
  deallocate eventCursor; 
  
  return @result;