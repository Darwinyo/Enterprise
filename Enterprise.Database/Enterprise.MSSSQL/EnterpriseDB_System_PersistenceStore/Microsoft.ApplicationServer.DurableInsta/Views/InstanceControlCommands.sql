
create view [Microsoft.ApplicationServer.DurableInstancing].[InstanceControlCommands] as
      select [Id],
             [InstanceId],
             [Type],
             [ExecutionAttempts],
             [LastExecutionAttemptAt],
             [CurrentMachine],
             [Exception]
      from [Microsoft.ApplicationServer.DurableInstancing].[InstanceControlCommandsTable]
GO
GRANT SELECT
    ON OBJECT::[Microsoft.ApplicationServer.DurableInstancing].[InstanceControlCommands] TO [System.Activities.DurableInstancing.InstanceStoreObservers]
    AS [dbo];

