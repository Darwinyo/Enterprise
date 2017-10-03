
create procedure [Microsoft.ApplicationServer.DurableInstancing].[CompleteCommandsExecution]
	@machineName nvarchar(128),
	@commandsToComplete xml,
	@commandsToAbandon xml,
	@retryCount as int
as
begin
	set nocount on;
	set transaction isolation level read committed;
	set xact_abort on;
	set deadlock_priority low;
	
	declare @now as datetime
	set @now = getutcdate()	

    DECLARE @CommandsListTempTable TABLE
	(
		Id bigint not null PRIMARY KEY 
	)		

	DECLARE @CommandExceptionListTempTable TABLE
	(	
		[Id] bigint not null PRIMARY KEY,
		[Exception] nvarchar(max)
	);
	
	DECLARE @AbandondedCommandsTempTable TABLE
	(
		[Id] bigint not null,
		[InstanceId] uniqueidentifier not null PRIMARY KEY,
		[ServiceIdentifier] varchar(max) null default (null),
		[Type] tinyint not null,
		[ExecutionAttempts] tinyint not null default (0),
		[LastExecutionAttemptAt] datetime null default (null),
		[LastExecutedOn] nvarchar(128) null default (null),
		[Exception] nvarchar(max) not null
	);
    
    insert into @CommandsListTempTable 
    select T.Item.value('@id', 'bigint')
	from @commandsToComplete.nodes('//cs/c') as T(Item)
	option (maxdop 1)	
    	
	delete from [InstanceControlCommandsTable]
	from @CommandsListTempTable commandsToDelete inner merge join 
		[Microsoft.ApplicationServer.DurableInstancing].[InstanceControlCommandsTable] commandQueue 	
		on commandQueue.[Id] = commandsToDelete.[Id]
	
	insert into @CommandExceptionListTempTable 
    select T.Item.value('@id', 'bigint'), T.Item.value('@e', 'nvarchar(max)')
	from @commandsToAbandon.nodes('//cs/c') as T(Item)		
	option (maxdop 1)
	
	begin tran
			
	update [InstanceControlCommandsTable]
	set [ExecutionAttempts] = [ExecutionAttempts] + 1,
		[LockExpiration] = null,
		[Exception] = commandsToAbandon.[Exception]
	from @CommandExceptionListTempTable commandsToAbandon
			inner merge join 
		[InstanceControlCommandsTable] commandQueue
			on commandQueue.[Id] = commandsToAbandon.[Id]	
			
	delete from [InstanceControlCommandsTable]
	output deleted.[Id], deleted.[InstanceId], deleted.[ServiceIdentifier], deleted.[Type], deleted.[ExecutionAttempts], 
		   GETUTCDATE(), @machineName, deleted.[Exception] into @AbandondedCommandsTempTable		   
	from @CommandExceptionListTempTable  commandsToAbandonedInstanceControlCommandsTable
	inner loop join [InstanceControlCommandsTable] commandQueue 	
		on commandQueue.[Id] = commandsToAbandonedInstanceControlCommandsTable.[Id]
	where (commandQueue.[ExecutionAttempts] >= @retryCount);

	merge [AbandonedInstanceControlCommandsTable] as T
	using @AbandondedCommandsTempTable as S
	on (S.[InstanceId] = T.[InstanceId])
	when matched
	    then update set T.[Id] = S.[Id], T.[Type] = S.[Type], T.[ExecutionAttempts] = S.[ExecutionAttempts],
	    T.[LastExecutionAttemptAt] = S.[LastExecutionAttemptAt], T.[LastExecutedOn] = S.[LastExecutedOn], 
		T.[Exception] = S.[Exception]
	when not matched
		then insert (Id, InstanceId, ServiceIdentifier, Type, ExecutionAttempts, LastExecutionAttemptAt, LastExecutedOn, Exception) 
		values(S.Id, S.InstanceId, S.ServiceIdentifier, S.Type, S.ExecutionAttempts, S.LastExecutionAttemptAt, S.LastExecutedOn, S.Exception);
		  
	commit tran
end
GO
GRANT EXECUTE
    ON OBJECT::[Microsoft.ApplicationServer.DurableInstancing].[CompleteCommandsExecution] TO [Microsoft.ApplicationServer.DurableInstancing.WorkflowManagementServiceUsers]
    AS [dbo];

