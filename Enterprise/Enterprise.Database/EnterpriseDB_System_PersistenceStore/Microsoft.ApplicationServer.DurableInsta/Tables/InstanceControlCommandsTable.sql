CREATE TABLE [Microsoft.ApplicationServer.DurableInstancing].[InstanceControlCommandsTable] (
    [Id]                     BIGINT           IDENTITY (1, 1) NOT NULL,
    [InstanceId]             UNIQUEIDENTIFIER NOT NULL,
    [ServiceIdentifier]      VARCHAR (MAX)    DEFAULT (NULL) NULL,
    [Type]                   TINYINT          NOT NULL,
    [ExecutionAttempts]      TINYINT          DEFAULT ((0)) NOT NULL,
    [LastExecutionAttemptAt] DATETIME         DEFAULT (NULL) NULL,
    [CurrentMachine]         NVARCHAR (128)   DEFAULT (NULL) NULL,
    [LockExpiration]         DATETIME         DEFAULT (NULL) NULL,
    [Exception]              NVARCHAR (MAX)   DEFAULT (NULL) NULL
);


GO
CREATE NONCLUSTERED INDEX [NCIX_CurrentMachine]
    ON [Microsoft.ApplicationServer.DurableInstancing].[InstanceControlCommandsTable]([CurrentMachine] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NCIX_InstanceId]
    ON [Microsoft.ApplicationServer.DurableInstancing].[InstanceControlCommandsTable]([InstanceId] ASC) WITH (IGNORE_DUP_KEY = ON);


GO
CREATE UNIQUE CLUSTERED INDEX [CIX_Id]
    ON [Microsoft.ApplicationServer.DurableInstancing].[InstanceControlCommandsTable]([Id] ASC);

