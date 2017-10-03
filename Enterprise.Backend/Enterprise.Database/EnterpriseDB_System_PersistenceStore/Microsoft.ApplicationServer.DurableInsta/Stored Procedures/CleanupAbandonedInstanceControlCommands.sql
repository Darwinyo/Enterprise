
create procedure [Microsoft.ApplicationServer.DurableInstancing].[CleanupAbandonedInstanceControlCommands]
    @timeRange as int
as
begin

	set nocount on;
	set transaction isolation level repeatable read;
	set xact_abort on;
	set deadlock_priority low;
	
	declare @now as datetime
	declare @expiryTime as datetime
	
	set @now = getutcdate()
	set @expiryTime = dateadd(minute, -@timeRange, @now)
	
	update top (1) [AbandonedInstanceControlCommandsCleanupTable]
		set [LastCleanupTime] = @now
	from [AbandonedInstanceControlCommandsCleanupTable]
	where ([LastCleanupTime] is null or [LastCleanupTime] < @expiryTime)
	
	if (@@ROWCOUNT = 1)
	begin
		delete from [Microsoft.ApplicationServer.DurableInstancing].[AbandonedInstanceControlCommandsTable] where InstanceId in
			(Select InstanceId from [Microsoft.ApplicationServer.DurableInstancing].[AbandonedInstanceControlCommandsTable] Except
			Select InstanceId from [System.Activities.DurableInstancing].[Instances]) 		

		update top (1) [AbandonedInstanceControlCommandsCleanupTable]
			set [LastCleanupCount] = @@ROWCOUNT,
			[TotalCleanupCount] = [TotalCleanupCount] + @@ROWCOUNT;
	end
end
GO
GRANT EXECUTE
    ON OBJECT::[Microsoft.ApplicationServer.DurableInstancing].[CleanupAbandonedInstanceControlCommands] TO [Microsoft.ApplicationServer.DurableInstancing.WorkflowManagementServiceUsers]
    AS [dbo];

