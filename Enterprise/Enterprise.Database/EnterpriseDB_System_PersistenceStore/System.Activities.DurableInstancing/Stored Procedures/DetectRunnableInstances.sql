
create procedure [System.Activities.DurableInstancing].[DetectRunnableInstances]
	@workflowHostType uniqueidentifier,
	@surrogateLockOwnerId bigint = null
as
begin
	set nocount on
	set transaction isolation level read committed	
	set xact_abort on;	
	set deadlock_priority low
	
	declare @nextRunnableTime datetime
	declare @workflowIdentityFilter tinyint
	
	if (@surrogateLockOwnerId is not null)
	 begin
		select @workflowIdentityFilter = [WorkflowIdentityFilter]
		from [LockOwnersTable]
		where [LockOwnersTable].SurrogateLockOwnerId = @surrogateLockOwnerId
	 end
	
	if (@workflowIdentityFilter is null)
		set @workflowIdentityFilter = 0
				
	if (@workflowIdentityFilter = 1)
	begin
		-- Any Identity
		select top 1 @nextRunnableTime = [RunnableInstancesTable].[RunnableTime]
				  from [RunnableInstancesTable] with (readpast)
				  where [WorkflowHostType] = @workflowHostType
				  order by [WorkflowHostType], [RunnableTime]
	end
	else if (@workflowIdentityFilter = 2)
	begin
		--AnyRevision
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
		
		select top 1 @nextRunnableTime = RunnableInstance.[RunnableTime]
				  from [RunnableInstancesTable] as RunnableInstance with (readpast) 
					inner loop join (
						select IdentityTable.[SurrogateIdentityId] as IdentityId
						from [System.Activities.DurableInstancing].[DefinitionIdentityTable] as IdentityTable, @AnyRevisionFilter as AnyRevision
						where IdentityTable.[DefinitionIdentityAnyRevisionHash] = AnyRevision.DefinitionIdentityAnyRevisionHash
					) as FilteredIdentities
					on RunnableInstance.[SurrogateIdentityId] =  FilteredIdentities.IdentityId
				  where RunnableInstance.[WorkflowHostType] = @workflowHostType
				  order by [WorkflowHostType], [RunnableTime]	
	end 
	else
		begin
			-- default to Exact
			if (@surrogateLockOwnerId is null)
			 begin
				declare	@surrogateIdentityId bigint
	
				select		@surrogateIdentityId = [SurrogateIdentityId]
				from		[System.Activities.DurableInstancing].[DefinitionIdentityTable]
				where		[DefinitionIdentityHash] = '00000000-0000-0000-0000-000000000000'
				and			[DefinitionIdentityAnyRevisionHash] = '00000000-0000-0000-0000-000000000000'
				and			[Name] is null
				and			[Package] is null
				and			[Build] is null
				and			[Major] is null
				and			[Minor] is null
				and			[Revision] is null
				
				select		top 1 @nextRunnableTime = RunnableInstances.[RunnableTime]
				from		[RunnableInstancesTable] as RunnableInstances with (readpast)
				where		[WorkflowHostType] = @workflowHostType
				and			[SurrogateIdentityId] = @surrogateIdentityId
				order by	[WorkflowHostType], [RunnableTime]	
			 end
			else
			 begin
				select top 1 @nextRunnableTime = RunnableInstances.[RunnableTime]
						  from [RunnableInstancesTable] as RunnableInstances with (readpast)
							inner loop join (
								select [SurrogateIdentityId] as IdentityId
								from [IdentityOwnerTable] 
								where [SurrogateLockOwnerId] = @surrogateLockOwnerId
							) as FilteredIdentities
							on RunnableInstances.[SurrogateIdentityId] = FilteredIdentities.IdentityId 
						  where [WorkflowHostType] = @workflowHostType
						  order by [WorkflowHostType], [RunnableTime]	
			 end
		end
	
	
	select 0 as 'Result', @nextRunnableTime, getutcdate()
end
GO
GRANT EXECUTE
    ON OBJECT::[System.Activities.DurableInstancing].[DetectRunnableInstances] TO [System.Activities.DurableInstancing.InstanceStoreUsers]
    AS [dbo];

