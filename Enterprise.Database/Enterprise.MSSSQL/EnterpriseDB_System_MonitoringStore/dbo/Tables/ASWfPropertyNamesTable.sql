CREATE TABLE [dbo].[ASWfPropertyNamesTable] (
    [EventSourceId] INT            NOT NULL,
    [Name]          NVARCHAR (128) NOT NULL,
    [Type]          NVARCHAR (128) NOT NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [CI_ASWfPropertyNamesTable_EventSourceId_Name_Type]
    ON [dbo].[ASWfPropertyNamesTable]([EventSourceId] ASC, [Name] ASC, [Type] ASC);


GO
GRANT UPDATE
    ON OBJECT::[dbo].[ASWfPropertyNamesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[ASWfPropertyNamesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[ASWfPropertyNamesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[ASWfPropertyNamesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];

