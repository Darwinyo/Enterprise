CREATE TABLE [dbo].[ASWcfEventsTable] (
    [Id]                    BIGINT         NOT NULL,
    [EventTypeId]           INT            NOT NULL,
    [EventSourceId]         INT            NOT NULL,
    [ProcessId]             INT            NOT NULL,
    [TraceLevelId]          TINYINT        NOT NULL,
    [E2EActivityId]         NVARCHAR (36)  NULL,
    [TimeCreated]           DATETIME2 (7)  NOT NULL,
    [Data1UniqueIdentifier] NVARCHAR (36)  NULL,
    [Data1Str]              NVARCHAR (450) NULL,
    [Data2Str]              NVARCHAR (450) NULL,
    [Data3Str]              NVARCHAR (450) NULL,
    [Data4Str]              NVARCHAR (450) NULL,
    [Data1MaxStr]           NVARCHAR (MAX) NULL,
    [Data1Int]              INT            NULL,
    [Data2Int]              INT            NULL,
    [Data3Int]              INT            NULL
);


GO
CREATE NONCLUSTERED INDEX [NCI_ASWcfEventsTable_E2EActivityId]
    ON [dbo].[ASWcfEventsTable]([E2EActivityId] ASC)
    INCLUDE([Id])
    ON [MSAppServerPS_ASWcfEventsTable] ([TimeCreated]);


GO
CREATE NONCLUSTERED INDEX [NCI_ASWcfEventsTable_EventTypeId_TimeCreated]
    ON [dbo].[ASWcfEventsTable]([EventTypeId] ASC, [TimeCreated] ASC)
    INCLUDE([EventSourceId], [Data1Int])
    ON [MSAppServerPS_ASWcfEventsTable] ([TimeCreated]);


GO
CREATE NONCLUSTERED INDEX [NCI_ASWcfEventsTable_EventSourceId]
    ON [dbo].[ASWcfEventsTable]([EventSourceId] ASC)
    ON [MSAppServerPS_ASWcfEventsTable] ([TimeCreated]);


GO
CREATE NONCLUSTERED INDEX [NCI_ASWcfEventsTable_Id]
    ON [dbo].[ASWcfEventsTable]([Id] ASC)
    ON [MSAppServerPS_ASWcfEventsTable] ([TimeCreated]);


GO
CREATE CLUSTERED INDEX [CI_ASWcfEventsTable_TimeCreated]
    ON [dbo].[ASWcfEventsTable]([TimeCreated] ASC) WITH (DATA_COMPRESSION = PAGE ON PARTITIONS (1), DATA_COMPRESSION = PAGE ON PARTITIONS (2))
    ON [MSAppServerPS_ASWcfEventsTable] ([TimeCreated]);


GO
GRANT UPDATE
    ON OBJECT::[dbo].[ASWcfEventsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[ASWcfEventsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[ASWcfEventsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[ASWcfEventsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];

