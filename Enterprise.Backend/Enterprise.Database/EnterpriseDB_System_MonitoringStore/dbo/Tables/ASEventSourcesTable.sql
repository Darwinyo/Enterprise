CREATE TABLE [dbo].[ASEventSourcesTable] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [Name]                   NVARCHAR (256) NULL,
    [Computer]               NVARCHAR (450) NOT NULL,
    [Site]                   NVARCHAR (256) NULL,
    [VirtualPath]            NVARCHAR (256) NULL,
    [ApplicationVirtualPath] NVARCHAR (256) NULL,
    [ServiceVirtualPath]     NVARCHAR (256) NULL,
    CONSTRAINT [PK_ASEventSourcesTable_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [NCI_ASEventSourcesTable_ServiceVirtualPath]
    ON [dbo].[ASEventSourcesTable]([ServiceVirtualPath] ASC);


GO
CREATE NONCLUSTERED INDEX [NCI_ASEventSourcesTable_VirtualPath]
    ON [dbo].[ASEventSourcesTable]([VirtualPath] ASC);


GO
CREATE NONCLUSTERED INDEX [NCI_ASEventSourcesTable_Site]
    ON [dbo].[ASEventSourcesTable]([Site] ASC);


GO
CREATE NONCLUSTERED INDEX [NCI_ASEventSourcesTable_Computer]
    ON [dbo].[ASEventSourcesTable]([Computer] ASC);


GO
GRANT UPDATE
    ON OBJECT::[dbo].[ASEventSourcesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[ASEventSourcesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[ASEventSourcesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[ASEventSourcesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];

