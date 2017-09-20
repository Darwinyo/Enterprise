CREATE TABLE [Microsoft.ApplicationServer.DurableInstancing].[AbandonedInstanceControlCommandsCleanupTable] (
    [LastCleanupTime]   DATETIME NOT NULL,
    [LastCleanupCount]  BIGINT   NOT NULL,
    [TotalCleanupCount] BIGINT   NOT NULL
);


GO
CREATE CLUSTERED INDEX [CIX_LastCleanupTime]
    ON [Microsoft.ApplicationServer.DurableInstancing].[AbandonedInstanceControlCommandsCleanupTable]([LastCleanupTime] ASC);

