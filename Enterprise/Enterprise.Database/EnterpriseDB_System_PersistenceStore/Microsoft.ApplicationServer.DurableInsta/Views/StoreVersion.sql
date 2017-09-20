
create view [Microsoft.ApplicationServer.DurableInstancing].[StoreVersion] as
      select 	[Major],
				[Minor],
				[Build],
				[Revision],
				[LastUpdated],
				[StoreIdentifier]
      from [Microsoft.ApplicationServer.DurableInstancing].[StoreVersionTable]
GO
GRANT SELECT
    ON OBJECT::[Microsoft.ApplicationServer.DurableInstancing].[StoreVersion] TO [System.Activities.DurableInstancing.InstanceStoreObservers]
    AS [dbo];

