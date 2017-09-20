
create procedure [System.Activities.DurableInstancing].[GetActivatableWorkflowsActivationParameters]
	@machineName nvarchar(128)
as
begin
	set nocount on
	set transaction isolation level read committed	
	set xact_abort on;	
	set deadlock_priority low
	
	declare @now datetime
	set @now = getutcdate()
	
	select 0 as 'Result'
	
	select top(1000) serviceDeployments.[SiteName], serviceDeployments.[RelativeApplicationPath], serviceDeployments.[RelativeServicePath]
	from (
		select distinct [ServiceDeploymentId], [WorkflowHostType]
		from [RunnableInstancesTable] with (readpast)
		where [RunnableTime] <= @now
		) runnableWorkflows inner join [ServiceDeploymentsTable] serviceDeployments
		on runnableWorkflows.[ServiceDeploymentId] = serviceDeployments.[Id]
	where not exists (
						select top (1) 1
						from [LockOwnersTable] lockOwners
						where lockOwners.[LockExpiration] > @now
						and lockOwners.[MachineName] = @machineName
						and lockOwners.[WorkflowHostType] = runnableWorkflows.[WorkflowHostType]
					  )
end
GO
GRANT EXECUTE
    ON OBJECT::[System.Activities.DurableInstancing].[GetActivatableWorkflowsActivationParameters] TO [System.Activities.DurableInstancing.WorkflowActivationUsers]
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[System.Activities.DurableInstancing].[GetActivatableWorkflowsActivationParameters] TO [System.Activities.DurableInstancing.InstanceStoreUsers]
    AS [dbo];

