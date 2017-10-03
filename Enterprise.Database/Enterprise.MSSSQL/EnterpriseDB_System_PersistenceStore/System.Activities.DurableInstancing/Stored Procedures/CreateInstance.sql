
create procedure [System.Activities.DurableInstancing].[CreateInstance]
	@instanceId uniqueidentifier,
	@surrogateLockOwnerId bigint,
	@workflowHostType uniqueidentifier,
	@serviceDeploymentId bigint,
	@surrogateInstanceId bigint output,
	@result int output
as
begin
	set nocount on
	set transaction isolation level read committed
	set xact_abort on;	
	
	set @surrogateInstanceId = 0
	set @result = 0
	declare	@surrogateIdentityId bigint
	
	select	@surrogateIdentityId = [SurrogateIdentityId]
	from	[System.Activities.DurableInstancing].[DefinitionIdentityTable]
	where	[DefinitionIdentityHash] = '00000000-0000-0000-0000-000000000000'
	and		[DefinitionIdentityAnyRevisionHash] = '00000000-0000-0000-0000-000000000000'
	and		[Name] is null
	and		[Package] is null
	and		[Build] is null
	and		[Major] is null
	and		[Minor] is null
	and		[Revision] is null

	if @surrogateIdentityId is null
	 begin
		goto Error
	 end
	else
	 begin
		begin try
			insert into [InstancesTable] ([Id], [SurrogateLockOwnerId], [CreationTime], [WorkflowHostType], [ServiceDeploymentId], [Version], [SurrogateIdentityId])
			values (@instanceId, @surrogateLockOwnerId, getutcdate(), @workflowHostType, @serviceDeploymentId, 1, @surrogateIdentityId)
			
			set @surrogateInstanceId = scope_identity()		
		end try
		begin catch
			if (error_number() != 2601)
			begin
				goto Error
			end
		end catch
	 end
	 
	 goto Done

Error:
	set @result = 99
	select @result as 'Result'
	
Done:

end