CREATE TABLE [dbo].[ASTransferEventsTable] (
    [Id]              BIGINT        NOT NULL,
    [EventTypeId]     INT           NOT NULL,
    [EventSourceId]   INT           NOT NULL,
    [ProcessId]       INT           NOT NULL,
    [TraceLevelId]    TINYINT       NOT NULL,
    [E2EActivityId]   NVARCHAR (36) NULL,
    [ToE2EActivityId] NVARCHAR (36) NULL,
    [TimeCreated]     DATETIME2 (7) NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [NCI_ASTransferEventsTable_RelatedE2EActivityId]
    ON [dbo].[ASTransferEventsTable]([ToE2EActivityId] ASC)
    ON [MSAppServerPS_ASTransferEventsTable] ([TimeCreated]);


GO
CREATE NONCLUSTERED INDEX [NCI_ASTransferEventsTable_E2EActivityId]
    ON [dbo].[ASTransferEventsTable]([E2EActivityId] ASC)
    ON [MSAppServerPS_ASTransferEventsTable] ([TimeCreated]);


GO
CREATE NONCLUSTERED INDEX [NCI_ASTransferEventsTable_Id]
    ON [dbo].[ASTransferEventsTable]([Id] ASC)
    ON [MSAppServerPS_ASTransferEventsTable] ([TimeCreated]);


GO
CREATE CLUSTERED INDEX [CI_ASTransferEventsTable_TimeCreated]
    ON [dbo].[ASTransferEventsTable]([TimeCreated] ASC) WITH (DATA_COMPRESSION = PAGE ON PARTITIONS (1), DATA_COMPRESSION = PAGE ON PARTITIONS (2))
    ON [MSAppServerPS_ASTransferEventsTable] ([TimeCreated]);


GO
GRANT UPDATE
    ON OBJECT::[dbo].[ASTransferEventsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[ASTransferEventsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[ASTransferEventsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[ASTransferEventsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];

