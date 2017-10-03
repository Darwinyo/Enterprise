create procedure [ASCreateEventTablesPartition]
  @tableSet int = 0, -- 0: all tables, 1: WCF tables, 2: WF tables
  @partitionUtcDateTime datetime2 = null,  
  @fileGroup sysname = null
as    
  set nocount on; 
  
  begin try
    declare @parameters nvarchar(max);
    declare @operationHistoryId bigint;
    
    if @partitionUtcDateTime is null
      set @partitionUtcDateTime = getutcdate();
      
    -- Start operation
    set @parameters = N'@tableSet=' + cast(@tableSet as nvarchar)+ N';@partitionUtcDateTime=' + 
      convert(nvarchar, @partitionUtcDateTime) + N';@fileGroup=' + isNull(@fileGroup, '');
    
    insert into [ASOperationsHistoryTable]([OperationId], [StartTime], [Parameters],
     [Status], [UserLogin])
    values (1, current_timestamp, @parameters,  0, system_user);
    
    set @operationHistoryId = scope_identity();
    
    -- Perform validations
    if serverproperty('EngineEdition') <> 3 
      exec [ASInternal_ThrowError] 201, 'Partitioning is only available in SQL Server Enterprise Edition.';
    
    if @tableSet < 0 or @tableSet > 2
      exec [ASInternal_ThrowError] 202, 'Invalid table set value.';
      
    if @fileGroup is not null
    begin     
      if filegroup_id(@fileGroup) is null
        exec [ASInternal_ThrowError] 203, 'Invalid file group name';
      
      set @fileGroup = quotename(@fileGroup);    
    end    
      
    if (@tableSet = 0 or @tableSet = 1)
    begin
      exec [ASInternal_CreateMonitoringTablePartition] 'ASWcfEventsTable', 
        @fileGroup, @partitionUtcDateTime;
      exec [ASInternal_CreateMonitoringTablePartition] 'ASTransferEventsTable', 
        @fileGroup, @partitionUtcDateTime;
    end
    
    if @tableSet = 0 or @tableSet = 2
    begin
      exec [ASInternal_CreateMonitoringTablePartition] 'ASWfEventsTable', 
       @fileGroup, @partitionUtcDateTime;
      exec [ASInternal_CreateMonitoringTablePartition] 'ASWfEventPropertiesTable', 
        @fileGroup, @partitionUtcDateTime;
      exec [ASInternal_CreateMonitoringTablePartition] 'ASWfInstancesTable', 
        @fileGroup, @partitionUtcDateTime;   
    end
        
    -- Log success
    update [ASOperationsHistoryTable]
    set [EndTime] = current_timestamp, [Status] = 1
    where [Id] = @operationHistoryId;
    
    return 0;
  end try
  begin catch
    exec [ASInternal_RethrowError];
    
    -- Log error
    update [ASOperationsHistoryTable]
    set [EndTime] = current_timestamp, [Status] = -1, [Message]= error_message()
    where [Id] = @operationHistoryId;
    
    return -1;
  end catch
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[ASCreateEventTablesPartition] TO [ASMonitoringDbAdmin]
    AS [dbo];

