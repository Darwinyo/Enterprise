
create view [System.Activities.DurableInstancing].[ServiceDeployments] as
      select [Id] as [ServiceDeploymentId],
             [SiteName],
             [RelativeServicePath],
             [RelativeApplicationPath],
             [ServiceName],
             [ServiceNamespace]
      from [System.Activities.DurableInstancing].[ServiceDeploymentsTable]
GO

create trigger [System.Activities.DurableInstancing].[DeleteServiceDeploymentTrigger] on [System.Activities.DurableInstancing].[ServiceDeployments]
instead of delete
as
begin	
	if (@@rowcount = 0)
		return	
		
	set nocount on
	set transaction isolation level read committed		
	set xact_abort on;	
	
	declare @lockAcquired bigint
	declare @candidateDeploymentIdsPass1 table([Id] bigint primary key)
	
	exec @lockAcquired = sp_getapplock @Resource = 'InstanceStoreLock', @LockMode = 'Exclusive', @LockTimeout = 25000
	
	if (@lockAcquired < 0)
		return

	insert into @candidateDeploymentIdsPass1
	select [ServiceDeploymentId] from deleted
	except
	select [ServiceDeploymentId] from [InstancesTable]
	
	delete [ServiceDeploymentsTable]
	from [ServiceDeploymentsTable]
	join @candidateDeploymentIdsPass1 as [OrphanedIds] on [OrphanedIds].[Id] = [ServiceDeploymentsTable].[Id]
	
	exec sp_releaseapplock @Resource = 'InstanceStoreLock'
end
GO
GRANT SELECT
    ON OBJECT::[System.Activities.DurableInstancing].[ServiceDeployments] TO [System.Activities.DurableInstancing.InstanceStoreObservers]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[System.Activities.DurableInstancing].[ServiceDeployments] TO [System.Activities.DurableInstancing.InstanceStoreUsers]
    AS [dbo];

