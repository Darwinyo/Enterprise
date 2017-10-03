CREATE TABLE [Microsoft.ApplicationServer.DurableInstancing].[AbandonedInstanceControlCommandsTable] (
    [Id]                     BIGINT           NOT NULL,
    [InstanceId]             UNIQUEIDENTIFIER NOT NULL,
    [ServiceIdentifier]      VARCHAR (MAX)    DEFAULT (NULL) NULL,
    [Type]                   TINYINT          NOT NULL,
    [ExecutionAttempts]      TINYINT          DEFAULT ((0)) NOT NULL,
    [LastExecutionAttemptAt] DATETIME         DEFAULT (NULL) NULL,
    [LastExecutedOn]         NVARCHAR (128)   DEFAULT (NULL) NULL,
    [Exception]              NVARCHAR (MAX)   NOT NULL
);


GO
CREATE CLUSTERED INDEX [CIX_InstanceId]
    ON [Microsoft.ApplicationServer.DurableInstancing].[AbandonedInstanceControlCommandsTable]([InstanceId] ASC);

