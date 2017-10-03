CREATE TABLE [System.Activities.DurableInstancing].[KeysTable] (
    [Id]                  UNIQUEIDENTIFIER NOT NULL,
    [SurrogateKeyId]      BIGINT           IDENTITY (1, 1) NOT NULL,
    [SurrogateInstanceId] BIGINT           NULL,
    [EncodingOption]      TINYINT          NULL,
    [Properties]          VARBINARY (MAX)  NULL,
    [IsAssociated]        BIT              NULL,
    CONSTRAINT [CIX_KeysTable] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (ALLOW_PAGE_LOCKS = OFF, IGNORE_DUP_KEY = ON)
);


GO
CREATE NONCLUSTERED INDEX [NCIX_KeysTable_SurrogateInstanceId]
    ON [System.Activities.DurableInstancing].[KeysTable]([SurrogateInstanceId] ASC) WITH (ALLOW_PAGE_LOCKS = OFF);

