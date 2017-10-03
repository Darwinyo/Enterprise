
create procedure [Microsoft.ApplicationServer.DurableInstancing].[DequeueWorkflowInstanceControlCommands]
    @timeRange as int,
	@machineName as nvarchar(128),
	@batchSize as int
as
begin

	set nocount on;
	set transaction isolation level repeatable read;
	set xact_abort on;
	set deadlock_priority low;
	
	declare @now as datetime
	declare @expiryData as datetime
	set @now = getutcdate()
	set @expiryData = dateadd(second, @timeRange, @now)
	
	update top (@batchSize) [Microsoft.ApplicationServer.DurableInstancing].[InstanceControlCommandsTable] with (readpast)
	set [CurrentMachine] = @machineName,		
		[LockExpiration] = @expiryData
	output inserted.[Id] [Id], inserted.[InstanceId] [InstanceId], inserted.[ServiceIdentifier] [ServiceIdentifier], inserted.[Type] [Type]
	from [Microsoft.ApplicationServer.DurableInstancing].[InstanceControlCommandsTable] commandQueue with (readpast)
	left outer loop join [System.Activities.DurableInstancing].[Instances] I with (readpast) on I.InstanceId = commandQueue.[InstanceId]  
	where ([LockExpiration] is null or [LockExpiration] < @now) and (I.CurrentMachine is null or I.CurrentMachine = @machineName)
	
	exec [Microsoft.ApplicationServer.DurableInstancing].[CleanupAbandonedInstanceControlCommands] @timeRange=10
end
GO
GRANT EXECUTE
    ON OBJECT::[Microsoft.ApplicationServer.DurableInstancing].[DequeueWorkflowInstanceControlCommands] TO [Microsoft.ApplicationServer.DurableInstancing.WorkflowManagementServiceUsers]
    AS [dbo];

