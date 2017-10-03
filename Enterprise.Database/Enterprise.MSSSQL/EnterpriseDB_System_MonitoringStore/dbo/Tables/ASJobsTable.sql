CREATE TABLE [dbo].[ASJobsTable] (
    [Id]                 INT              IDENTITY (1, 1) NOT NULL,
    [JobIdentifier]      NVARCHAR (128)   NOT NULL,
    [Sql]                NVARCHAR (MAX)   NULL,
    [LastRunTime]        DATETIME2 (7)    NULL,
    [IsLastRunSuccess]   BIT              NULL,
    [LastErrorCode]      INT              NULL,
    [LastError]          NVARCHAR (2048)  NULL,
    [PeriodInSeconds]    INT              NULL,
    [ConversationHandle] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_JobsTable_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NCI_ASJobsTable_ConversationHandle]
    ON [dbo].[ASJobsTable]([ConversationHandle] ASC) WHERE ([ConversationHandle] IS NOT NULL);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NCI_ASJobsTable_JobIdentifier]
    ON [dbo].[ASJobsTable]([JobIdentifier] ASC);


GO
GRANT UPDATE
    ON OBJECT::[dbo].[ASJobsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[ASJobsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[ASJobsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[ASJobsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];

