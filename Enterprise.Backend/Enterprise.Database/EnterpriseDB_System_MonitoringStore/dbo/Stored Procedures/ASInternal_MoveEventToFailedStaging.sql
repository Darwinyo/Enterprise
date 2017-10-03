create procedure [ASInternal_MoveEventToFailedStaging]
(@eventId bigint,
@errorNumber int,
@errorMessage nvarchar(max))
as
begin
  declare @ASFailedStagingTableRowCount bigint;
  declare @maxASFailedStagingTableRowCount bigint;
  
  set @maxASFailedStagingTableRowCount = (select [MaxSizeFailedStagingTable] from [ASConfigurationPropertiesTable]);
  if (@maxASFailedStagingTableRowCount is null)
  begin
    set @maxASFailedStagingTableRowCount = -1;
  end;

  set @ASFailedStagingTableRowCount = (select count_big(*) from [ASFailedStagingTable]);
                  
  if (@maxASFailedStagingTableRowCount < 0 or @ASFailedStagingTableRowCount < @maxASFailedStagingTableRowCount)
  begin
    begin try      
      begin transaction;          

      insert into [ASFailedStagingTable] 
        ([Id], [ArchiveId], [EventTypeId], [E2EActivityId],
        [Computer], [EventSource], [ProcessId], [TraceLevelId], [TimeCreated],
        [Data1Str], [Data2Str], [Data3Str], [Data4Str], [Data5Str], [Data6Str], [Data7Str], [Data8Str], [Data9Str], [Data1MaxStr], 
        [Data1Int], [Data2Int], [Data3Int], [Data1BigInt], [Data1UniqueId], 
        [CustomAnnotations], [CustomProperties], [CustomArguments], [ErrorNumber], [ErrorMessage])
      select
        [Id], [ArchiveId], [EventTypeId], [E2EActivityId],
        [Computer], [EventSource], [ProcessId], [TraceLevelId], [TimeCreated],
        [Data1Str], [Data2Str], [Data3Str], [Data4Str], [Data5Str], [Data6Str], [Data7Str], [Data8Str], [Data9Str], [Data1MaxStr], 
        [Data1Int], [Data2Int], [Data3Int], [Data1BigInt], [Data1UniqueId],
        [CustomAnnotations], [CustomProperties], [CustomArguments], @errorNumber, @errorMessage
      from [ASStagingTable]
        where [Id] = @eventId;
      
      delete from [ASStagingTable] where [Id] = @eventId;
                    
      commit transaction;
    end try
    begin catch        
      if (@@trancount > 0)
        rollback transaction;
    end catch;
  end;  
end;