
create view [System.Activities.DurableInstancing].[Instances] as
      select [InstancesTable].[Id] as [InstanceId],
             [PendingTimer],
             [CreationTime],
             [LastUpdated] as [LastUpdatedTime],
             [InstancesTable].[ServiceDeploymentId],
             [SuspensionExceptionName],
             [SuspensionReason],
             [BlockingBookmarks] as [ActiveBookmarks],
             case when [LockOwnersTable].[LockExpiration] > getutcdate()
				then [LockOwnersTable].[MachineName]
				else null
				end as [CurrentMachine],
             [LastMachineRunOn] as [LastMachine],
             [ExecutionStatus],
             [IsInitialized],
             [IsSuspended],
             [IsCompleted],
             [InstancesTable].[DataEncodingOption] as [EncodingOption],
             [PrimitiveDataProperties] as [ReadWritePrimitiveDataProperties],
             [WriteOnlyPrimitiveDataProperties],
             [ComplexDataProperties] as [ReadWriteComplexDataProperties],
             [WriteOnlyComplexDataProperties],
             [Name] as [IdentityName],
             [Package] as [IdentityPackage],
             [Build],
             [Major],
             [Minor],
             [Revision]
      from [System.Activities.DurableInstancing].[InstancesTable]
      left outer join [System.Activities.DurableInstancing].[LockOwnersTable]
      on [InstancesTable].[SurrogateLockOwnerId] = [LockOwnersTable].[SurrogateLockOwnerId]
      join [System.Activities.DurableInstancing].[DefinitionIdentityTable]
      on [InstancesTable].[SurrogateIdentityId] = [DefinitionIdentityTable].[SurrogateIdentityId]
GO

create trigger [System.Activities.DurableInstancing].[DeleteInstanceTrigger] on [System.Activities.DurableInstancing].[Instances]
instead of delete
as
begin	
	if (@@rowcount = 0)
		return
		
	set nocount on
	set transaction isolation level read committed		
	set xact_abort on;	
	
	declare @surrogateInstanceIds table ([SurrogateInstanceId] bigint primary key)		
	
	insert into @surrogateInstanceIds
	select [SurrogateInstanceId]
	from deleted as [DeletedInstances]
	join [InstancesTable] on [InstancesTable].[Id] = [DeletedInstances].[InstanceId]
	
	delete [InstancePromotedPropertiesTable]
	from @surrogateInstanceIds as [InstancesToDelete]
	inner merge join [System.Activities.DurableInstancing].[InstancePromotedPropertiesTable] on [InstancePromotedPropertiesTable].[SurrogateInstanceId] = [InstancesToDelete].[SurrogateInstanceId]
	
	delete [KeysTable]
	from @surrogateInstanceIds as [InstancesToDelete]
	inner loop join [System.Activities.DurableInstancing].[KeysTable] on [KeysTable].[SurrogateInstanceId] = [InstancesToDelete].[SurrogateInstanceId]
	
	delete from [InstanceMetadataChangesTable]
	from @surrogateInstanceIds as [InstancesToDelete]
	inner merge join [System.Activities.DurableInstancing].[InstanceMetadataChangesTable] on [InstanceMetadataChangesTable].[SurrogateInstanceId] = [InstancesToDelete].[SurrogateInstanceId]
	
	delete [RunnableInstancesTable]
	from @surrogateInstanceIds as [InstancesToDelete]
	inner loop join [System.Activities.DurableInstancing].[RunnableInstancesTable] on [RunnableInstancesTable].[SurrogateInstanceId] = [InstancesToDelete].[SurrogateInstanceId]
	
	delete [InstancesTable]
	from @surrogateInstanceIds as [InstancesToDelete]
	inner merge join [System.Activities.DurableInstancing].[InstancesTable] on [InstancesTable].[SurrogateInstanceId] = [InstancesToDelete].[SurrogateInstanceId]
end
GO
GRANT SELECT
    ON OBJECT::[System.Activities.DurableInstancing].[Instances] TO [System.Activities.DurableInstancing.InstanceStoreObservers]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[System.Activities.DurableInstancing].[Instances] TO [System.Activities.DurableInstancing.InstanceStoreUsers]
    AS [dbo];

