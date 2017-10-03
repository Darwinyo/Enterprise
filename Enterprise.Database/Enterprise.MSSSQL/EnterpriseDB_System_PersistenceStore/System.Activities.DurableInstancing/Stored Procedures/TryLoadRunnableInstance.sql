
create procedure [System.Activities.DurableInstancing].[TryLoadRunnableInstance]
	@surrogateLockOwnerId bigint,
	@workflowHostType uniqueidentifier,
	@operationType tinyint,
	@handleInstanceVersion bigint,
	@handleIsBoundToLock bit,
	@encodingOption tinyint,	
	@operationTimeout int
as
begin
	set nocount on
	set transaction isolation level read committed	
	set xact_abort on;	
	set deadlock_priority -6
	begin tran
	
	declare @instanceId uniqueIdentifier
	declare @now datetime
	set @now = getutcdate()
	
	declare @workflowIdentityFilter tinyint
	
	select @workflowIdentityFilter = [WorkflowIdentityFilter]
	from [LockOwnersTable]
	where [LockOwnersTable].SurrogateLockOwnerId = @surrogateLockOwnerId
	
	if (@workflowIdentityFilter = null)
		set @workflowIdentityFilter = 0
		
	if (@workflowIdentityFilter = 1)
	begin
		-- Load any Runnable instances of specified WorkflowHostType
		select top (1) @instanceId = instances.[Id]
		from [RunnableInstancesTable] runnableInstances with (readpast, updlock)
			inner loop join [InstancesTable] instances with (readpast, updlock)
			on runnableInstances.[SurrogateInstanceId] = instances.[SurrogateInstanceId]
		where runnableInstances.[WorkflowHostType] = @workflowHostType
			  and 
			  runnableInstances.[RunnableTime] <= @now	
	end
	else if (@workflowIdentityFilter = 2)
	begin
		declare @AnyRevisionFilter table
		(
			DefinitionIdentityAnyRevisionHash uniqueidentifier
			UNIQUE (DefinitionIdentityAnyRevisionHash)
		)

		insert into @AnyRevisionFilter 
		select distinct [DefinitionIdentityAnyRevisionHash]
		from [DefinitionIdentityTable] as IdentityTable, [IdentityOwnerTable] as IdentityOwnerTable
		where IdentityOwnerTable.[SurrogateLockOwnerId] = @surrogateLockOwnerId 
			and 
			IdentityTable.[SurrogateIdentityId] = IdentityOwnerTable.[SurrogateIdentityId]
	
		-- Load Runnables instances of specified WorkflowHostType and ignore revision field on supported identities. 
		select top (1) @instanceId = instances.[Id]
		from [RunnableInstancesTable] runnableInstances with (readpast, updlock)
			inner loop join [InstancesTable] instances with (readpast, updlock)
			on runnableInstances.[SurrogateInstanceId] = instances.[SurrogateInstanceId]
			inner loop join (
						select IdentityTable.[SurrogateIdentityId] as IdentityId
						from [System.Activities.DurableInstancing].[DefinitionIdentityTable] as IdentityTable, @AnyRevisionFilter as AnyRevision
						where IdentityTable.[DefinitionIdentityAnyRevisionHash] = AnyRevision.DefinitionIdentityAnyRevisionHash
					) as FilteredIdentities 
			on runnableInstances.SurrogateIdentityId = FilteredIdentities.IdentityId
		where runnableInstances.[WorkflowHostType] = @workflowHostType
			  and 
			  runnableInstances.[RunnableTime] <= @now	  			
	end
	else
	begin
		-- Load Runnable instances of specified WorkflowHostType and the supported identities
		select top (1) @instanceId = instances.[Id]
		from [RunnableInstancesTable] runnableInstances with (readpast, updlock)
			inner loop join [InstancesTable] instances with (readpast, updlock)
			on runnableInstances.[SurrogateInstanceId] = instances.[SurrogateInstanceId]
			inner loop join (
				select [SurrogateIdentityId] as IdentityId 
				from [IdentityOwnerTable] 
				where [SurrogateLockOwnerId] = @surrogateLockOwnerId
			) as FilteredIdentities  
			on runnableInstances.[SurrogateIdentityId] = FilteredIdentities.IdentityId
		where runnableInstances.[WorkflowHostType] = @workflowHostType
			  and 
			  runnableInstances.[RunnableTime] <= @now
	end	       

    if (@@rowcount = 1)
    begin
		select 0 as 'Result', cast(1 as bit)				
		exec [System.Activities.DurableInstancing].[LoadInstance] @surrogateLockOwnerId, @operationType, @handleInstanceVersion, @handleIsBoundToLock, null, @instanceId, null, @encodingOption, null, null, @operationTimeout
    end	
    else
    begin
		select 0 as 'Result', cast(0 as bit)
    end
    
    if (@@trancount > 0)
    begin
		commit tran
    end
end
GO
GRANT EXECUTE
    ON OBJECT::[System.Activities.DurableInstancing].[TryLoadRunnableInstance] TO [System.Activities.DurableInstancing.InstanceStoreUsers]
    AS [dbo];

