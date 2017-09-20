CREATE TABLE [dbo].[ASWfEventPropertiesTable] (
    [EventId]        BIGINT         NOT NULL,
    [WfDataSourceId] TINYINT        DEFAULT ((0)) NOT NULL,
    [Name]           NVARCHAR (128) NOT NULL,
    [Type]           NVARCHAR (128) NULL,
    [Value]          SQL_VARIANT    NULL,
    [ValueBlob]      NVARCHAR (MAX) NULL,
    [TimeCreated]    DATETIME2 (7)  NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [NCI_ASWfEventPropertiesTable_EventId]
    ON [dbo].[ASWfEventPropertiesTable]([EventId] ASC)
    ON [MSAppServerPS_ASWfEventPropertiesTable] ([TimeCreated]);


GO
CREATE NONCLUSTERED INDEX [NCI_ASWfEventPropertiesTable_Name_Value]
    ON [dbo].[ASWfEventPropertiesTable]([Name] ASC, [Value] ASC) WHERE ([Value] IS NOT NULL)
    ON [MSAppServerPS_ASWfEventPropertiesTable] ([TimeCreated]);


GO
CREATE CLUSTERED INDEX [CI_ASWfEventPropertiesTable_TimeCreated]
    ON [dbo].[ASWfEventPropertiesTable]([TimeCreated] ASC) WITH (DATA_COMPRESSION = PAGE ON PARTITIONS (1), DATA_COMPRESSION = PAGE ON PARTITIONS (2))
    ON [MSAppServerPS_ASWfEventPropertiesTable] ([TimeCreated]);


GO
GRANT UPDATE
    ON OBJECT::[dbo].[ASWfEventPropertiesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[ASWfEventPropertiesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[ASWfEventPropertiesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[ASWfEventPropertiesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];

