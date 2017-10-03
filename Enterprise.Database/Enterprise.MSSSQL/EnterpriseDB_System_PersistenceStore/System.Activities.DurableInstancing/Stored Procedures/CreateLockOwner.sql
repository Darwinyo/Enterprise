
create procedure [System.Activities.DurableInstancing].[CreateLockOwner]
	@lockOwnerId uniqueidentifier,
	@lockTimeout int,
	@workflowHostType uniqueidentifier,
	@enqueueCommand bit,
	@deleteInstanceOnCompletion bit,	
	@primitiveLockOwnerData varbinary(max),
	@complexLockOwnerData varbinary(max),
	@writeOnlyPrimitiveLockOwnerData varbinary(max),
	@writeOnlyComplexLockOwnerData varbinary(max),
	@encodingOption tinyint,
	@machineName nvarchar(128),
	@identityMetadata xml = null
as
begin
	set nocount on
	set transaction isolation level read committed
	set xact_abort on;	
	
	begin transaction
	
	declare @lockAcquired bigint
	declare @lockExpiration datetime
	declare @now datetime
	declare @result int
	declare @surrogateLockOwnerId bigint
	declare @workflowIdentityFilter tinyint

	set @result = 0
	
	exec @lockAcquired = sp_getapplock @Resource = 'InstanceStoreLock', @LockMode = 'Shared', @LockTimeout = 10000
		
	if (@lockAcquired < 0)
	begin
		select @result as 'Result'
		set @result = 13
	end
	
	if (@result = 0)
	begin
		-- insert the list of identity to the DefinitionIdentityTable
		exec [System.Activities.DurableInstancing].[InsertDefinitionIdentity] @identityMetadata
		
		if (@identityMetadata is not null)
		 begin
			select @workflowIdentityFilter = T.Item.value('WorkflowIdentityFilter[1]', 'tinyint')
			from @identityMetadata.nodes('/IdentityMetadata') as T(Item)
		 end
		
		if @workflowIdentityFilter is null
			set @workflowIdentityFilter = 0

		--Create Lock Owner entry 
		set @now = getutcdate()
		
		if (@lockTimeout = 0)
			set @lockExpiration = '9999-12-31T23:59:59';
		else 
			set @lockExpiration = dateadd(second, @lockTimeout, getutcdate());
		
		insert into [LockOwnersTable] ([Id], [LockExpiration], [MachineName], [WorkflowHostType], [EnqueueCommand], [DeletesInstanceOnCompletion], [PrimitiveLockOwnerData], [ComplexLockOwnerData], [WriteOnlyPrimitiveLockOwnerData], [WriteOnlyComplexLockOwnerData], [EncodingOption], [WorkflowIdentityFilter])
		values (@lockOwnerId, @lockExpiration, @machineName, @workflowHostType, @enqueueCommand, @deleteInstanceOnCompletion, @primitiveLockOwnerData, @complexLockOwnerData, @writeOnlyPrimitiveLockOwnerData, @writeOnlyComplexLockOwnerData, @encodingOption, @workflowIdentityFilter)
		
		set @surrogateLockOwnerId = scope_identity()
		
		-- insert identity collection with its lock owner.
		if (@identityMetadata is not null)
		 begin
			insert into [System.Activities.DurableInstancing].[IdentityOwnerTable] 
			(
						[SurrogateIdentityId], 
						[SurrogateLockOwnerId]
			)
			select		[System.Activities.DurableInstancing].[DefinitionIdentityTable].[SurrogateIdentityId], 
						@surrogateLockOwnerId
			from		[System.Activities.DurableInstancing].[DefinitionIdentityTable]
			where		[System.Activities.DurableInstancing].[DefinitionIdentityTable].[DefinitionIdentityHash] in
						(
							select	T.Item.value('DefinitionIdentityHash[1]', 'uniqueidentifier') 
							from	@identityMetadata.nodes('/IdentityMetadata/IdentityCollection/Identity') as T(Item)
						)
		 end
		else
		 begin
			insert into [System.Activities.DurableInstancing].[IdentityOwnerTable] 
			(
				[SurrogateIdentityId], 
				[SurrogateLockOwnerId]
			)
			select  [SurrogateIdentityId], @surrogateLockOwnerId
			from	[System.Activities.DurableInstancing].[DefinitionIdentityTable]
			where	[DefinitionIdentityHash] = '00000000-0000-0000-0000-000000000000'
		 end 
	end
	
	if (@result != 13)
		exec sp_releaseapplock @Resource = 'InstanceStoreLock'
	
	if (@result = 0)
	begin
		commit transaction
		select 0 as 'Result', @surrogateLockOwnerId
	end
	else
		rollback transaction
end
GO
GRANT EXECUTE
    ON OBJECT::[System.Activities.DurableInstancing].[CreateLockOwner] TO [System.Activities.DurableInstancing.WorkflowActivationUsers]
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[System.Activities.DurableInstancing].[CreateLockOwner] TO [System.Activities.DurableInstancing.InstanceStoreUsers]
    AS [dbo];

