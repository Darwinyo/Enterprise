CREATE TABLE [dbo].[ASStagingTable] (
    [Id]                BIGINT          IDENTITY (1, 1) NOT NULL,
    [ArchiveId]         BIGINT          DEFAULT ((0)) NOT NULL,
    [EventTypeId]       INT             NOT NULL,
    [E2EActivityId]     NVARCHAR (36)   NULL,
    [Computer]          NVARCHAR (450)  NOT NULL,
    [EventSource]       NVARCHAR (1024) DEFAULT (N'') NULL,
    [ProcessId]         INT             NOT NULL,
    [TraceLevelId]      TINYINT         NOT NULL,
    [TimeCreated]       DATETIME2 (7)   NOT NULL,
    [Data1Str]          NVARCHAR (450)  NULL,
    [Data2Str]          NVARCHAR (450)  NULL,
    [Data3Str]          NVARCHAR (450)  NULL,
    [Data4Str]          NVARCHAR (450)  NULL,
    [Data5Str]          NVARCHAR (450)  NULL,
    [Data6Str]          NVARCHAR (450)  NULL,
    [Data7Str]          NVARCHAR (450)  NULL,
    [Data8Str]          NVARCHAR (450)  NULL,
    [Data9Str]          NVARCHAR (450)  NULL,
    [Data1MaxStr]       NVARCHAR (MAX)  NULL,
    [Data1Int]          INT             NULL,
    [Data2Int]          INT             NULL,
    [Data3Int]          INT             NULL,
    [Data1BigInt]       BIGINT          NULL,
    [Data1UniqueId]     NVARCHAR (36)   NULL,
    [CustomAnnotations] NVARCHAR (MAX)  NULL,
    [CustomProperties]  NVARCHAR (MAX)  NULL,
    [CustomArguments]   NVARCHAR (MAX)  NULL
);


GO
ALTER TABLE [dbo].[ASStagingTable] SET (LOCK_ESCALATION = AUTO);


GO
CREATE UNIQUE CLUSTERED INDEX [CI_ASStagingTable_Id_EventTypeId]
    ON [dbo].[ASStagingTable]([Id] ASC, [EventTypeId] ASC)
    ON [MSAppServerPS_ASStagingTable] ([EventTypeId]);


GO
GRANT UPDATE
    ON OBJECT::[dbo].[ASStagingTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[ASStagingTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[ASStagingTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[ASStagingTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[ASStagingTable] TO [ASMonitoringDbWriter]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[ASStagingTable] TO [ASMonitoringDbWriter]
    AS [dbo];

