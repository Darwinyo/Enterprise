CREATE TABLE [dbo].[ASOperationsHistoryTable] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserLogin]   NVARCHAR (128) NOT NULL,
    [OperationId] INT            NOT NULL,
    [Parameters]  NVARCHAR (MAX) NOT NULL,
    [Status]      INT            NOT NULL,
    [Message]     NVARCHAR (MAX) NULL,
    [Log]         NVARCHAR (MAX) NULL,
    [StartTime]   DATETIME2 (7)  NOT NULL,
    [EndTime]     DATETIME2 (7)  NULL,
    CONSTRAINT [PK_ASOperationsHistoryTable_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
GRANT UPDATE
    ON OBJECT::[dbo].[ASOperationsHistoryTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[ASOperationsHistoryTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[ASOperationsHistoryTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[ASOperationsHistoryTable] TO [ASMonitoringDbAdmin]
    AS [dbo];

