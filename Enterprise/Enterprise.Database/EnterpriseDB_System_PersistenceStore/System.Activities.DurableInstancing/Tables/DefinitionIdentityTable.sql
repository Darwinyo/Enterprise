CREATE TABLE [System.Activities.DurableInstancing].[DefinitionIdentityTable] (
    [SurrogateIdentityId]               BIGINT           IDENTITY (1, 1) NOT NULL,
    [DefinitionIdentityHash]            UNIQUEIDENTIFIER NOT NULL,
    [DefinitionIdentityAnyRevisionHash] UNIQUEIDENTIFIER NOT NULL,
    [Name]                              NVARCHAR (MAX)   NULL,
    [Package]                           NVARCHAR (MAX)   NULL,
    [Build]                             BIGINT           NULL,
    [Major]                             BIGINT           NULL,
    [Minor]                             BIGINT           NULL,
    [Revision]                          BIGINT           NULL,
    CONSTRAINT [CIX_DefinitionIdentityTable] PRIMARY KEY CLUSTERED ([SurrogateIdentityId] ASC) WITH (ALLOW_PAGE_LOCKS = OFF)
);


GO
CREATE NONCLUSTERED INDEX [NCIX_DefinitionIdentityTable_DefinitionIdentityAnyRevisionHash]
    ON [System.Activities.DurableInstancing].[DefinitionIdentityTable]([DefinitionIdentityAnyRevisionHash] ASC) WITH (ALLOW_PAGE_LOCKS = OFF);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NCIX_DefinitionIdentityTable_DefinitionIdentityHash]
    ON [System.Activities.DurableInstancing].[DefinitionIdentityTable]([DefinitionIdentityHash] ASC) WITH (ALLOW_PAGE_LOCKS = OFF, IGNORE_DUP_KEY = ON);

