CREATE TABLE [dbo].[ASFailedStagingTable] (
    [Id]                BIGINT          NOT NULL,
    [ArchiveId]         BIGINT          NOT NULL,
    [EventTypeId]       INT             NOT NULL,
    [E2EActivityId]     NVARCHAR (36)   NULL,
    [Computer]          NVARCHAR (450)  NOT NULL,
    [EventSource]       NVARCHAR (1024) NULL,
    [ProcessId]         INT             NULL,
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
    [CustomArguments]   NVARCHAR (MAX)  NULL,
    [ErrorNumber]       INT             NULL,
    [ErrorMessage]      NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_ASFailedStagingTable_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
GRANT UPDATE
    ON OBJECT::[dbo].[ASFailedStagingTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[ASFailedStagingTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[ASFailedStagingTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[ASFailedStagingTable] TO [ASMonitoringDbAdmin]
    AS [dbo];

