CREATE TABLE [Microsoft.ApplicationServer.DurableInstancing].[StoreVersionTable] (
    [Major]           BIGINT           NULL,
    [Minor]           BIGINT           NULL,
    [Build]           BIGINT           NULL,
    [Revision]        BIGINT           NULL,
    [LastUpdated]     DATETIME         NULL,
    [StoreIdentifier] UNIQUEIDENTIFIER NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [CIX_StoreVersionTable]
    ON [Microsoft.ApplicationServer.DurableInstancing].[StoreVersionTable]([Major] ASC, [Minor] ASC, [Build] ASC, [Revision] ASC);

