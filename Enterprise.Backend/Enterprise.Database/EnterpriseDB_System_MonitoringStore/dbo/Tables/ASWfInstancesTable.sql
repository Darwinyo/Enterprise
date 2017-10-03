CREATE TABLE [dbo].[ASWfInstancesTable] (
    [Id]                 BIGINT         IDENTITY (1, 1) NOT NULL,
    [WorkflowInstanceId] NVARCHAR (36)  NOT NULL,
    [LatestRecordNumber] BIGINT         NOT NULL,
    [LastEventSourceId]  INT            NOT NULL,
    [LastEventStatus]    NVARCHAR (450) NOT NULL,
    [StartTime]          DATETIME2 (7)  NOT NULL,
    [LastModifiedTime]   DATETIME2 (7)  NOT NULL,
    [CurrentDuration]    INT            DEFAULT ((0)) NOT NULL,
    [ExceptionCount]     INT            DEFAULT ((0)) NOT NULL,
    [LastAbortedTime]    DATETIME2 (7)  NULL
);


GO
CREATE NONCLUSTERED INDEX [NCI_ASWfInstancesTable_LastAbortedTime]
    ON [dbo].[ASWfInstancesTable]([LastAbortedTime] ASC)
    INCLUDE([LastEventSourceId], [LastEventStatus]) WHERE ([LastAbortedTime] IS NOT NULL)
    ON [MSAppServerPS_ASWfInstancesTable] ([StartTime]);


GO
CREATE NONCLUSTERED INDEX [NCI_ASWfInstancesTable_LastModifiedTime]
    ON [dbo].[ASWfInstancesTable]([LastModifiedTime] ASC)
    INCLUDE([LastEventSourceId], [LastEventStatus])
    ON [MSAppServerPS_ASWfInstancesTable] ([StartTime]);


GO
CREATE NONCLUSTERED INDEX [NCI_ASWfInstancesTable_LastEventSourceId]
    ON [dbo].[ASWfInstancesTable]([LastEventSourceId] ASC)
    ON [MSAppServerPS_ASWfInstancesTable] ([StartTime]);


GO
CREATE NONCLUSTERED INDEX [NCI_ASWfInstancesTable_WorkflowInstanceId]
    ON [dbo].[ASWfInstancesTable]([WorkflowInstanceId] ASC)
    ON [MSAppServerPS_ASWfInstancesTable] ([StartTime]);


GO
CREATE CLUSTERED INDEX [CI_ASWfInstancesTable_StartTime]
    ON [dbo].[ASWfInstancesTable]([StartTime] ASC)
    ON [MSAppServerPS_ASWfInstancesTable] ([StartTime]);


GO
GRANT UPDATE
    ON OBJECT::[dbo].[ASWfInstancesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[ASWfInstancesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[ASWfInstancesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[ASWfInstancesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];

