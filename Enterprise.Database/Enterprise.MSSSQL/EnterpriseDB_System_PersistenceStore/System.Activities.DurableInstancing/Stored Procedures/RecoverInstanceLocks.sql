
create procedure [System.Activities.DurableInstancing].[RecoverInstanceLocks]
as
begin
	set nocount on;
	set transaction isolation level read committed;
	set xact_abort on;
	set deadlock_priority low;
    
	declare @now as datetime
	set @now = getutcdate()	
	
	insert into [RunnableInstancesTable] ([SurrogateInstanceId], [WorkflowHostType], [ServiceDeploymentId], [RunnableTime], [SurrogateIdentityId])
		select top (1000) instances.[SurrogateInstanceId], instances.[WorkflowHostType], instances.[ServiceDeploymentId], @now, instances.[SurrogateIdentityId]
		from [LockOwnersTable] lockOwners with (readpast) inner loop join
			 [InstancesTable] instances with (readpast)
				on instances.[SurrogateLockOwnerId] = lockOwners.[SurrogateLockOwnerId]
			where 
				lockOwners.[LockExpiration] <= @now and
				instances.[IsInitialized] = 1 and
				instances.[IsSuspended] = 0
	
	delete from [IdentityOwnerTable] with (readpast)
	where [IdentityOwnerTable].[SurrogateLockOwnerId] in
	(
		select [SurrogateLockOwnerId]
		from [System.Activities.DurableInstancing].[LockOwnersTable] lockOwners
		where [LockExpiration] <= @now
		and not exists
		(
			select top (1) 1
			from [System.Activities.DurableInstancing].[InstancesTable] instances with (nolock)
			where instances.[SurrogateLockOwnerId] = lockOwners.[SurrogateLockOwnerId]
		)
	)

	delete from [LockOwnersTable] with (readpast)
	from [LockOwnersTable] lockOwners
	where [LockExpiration] <= @now
	and not exists
	(
		select top (1) 1
		from [InstancesTable] instances with (nolock)
		where instances.[SurrogateLockOwnerId] = lockOwners.[SurrogateLockOwnerId]
	)
end
GO
GRANT EXECUTE
    ON OBJECT::[System.Activities.DurableInstancing].[RecoverInstanceLocks] TO [System.Activities.DurableInstancing.WorkflowActivationUsers]
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[System.Activities.DurableInstancing].[RecoverInstanceLocks] TO [System.Activities.DurableInstancing.InstanceStoreUsers]
    AS [dbo];

