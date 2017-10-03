
create view [Microsoft.ApplicationServer.DurableInstancing].[AbandonedInstanceControlCommands] as
      select [Id],
             [InstanceId],
             [Type],
             [ExecutionAttempts],
             [LastExecutionAttemptAt],
             [LastExecutedOn],
             [Exception]
      from [Microsoft.ApplicationServer.DurableInstancing].[AbandonedInstanceControlCommandsTable]
GO
GRANT SELECT
    ON OBJECT::[Microsoft.ApplicationServer.DurableInstancing].[AbandonedInstanceControlCommands] TO [System.Activities.DurableInstancing.InstanceStoreObservers]
    AS [dbo];

