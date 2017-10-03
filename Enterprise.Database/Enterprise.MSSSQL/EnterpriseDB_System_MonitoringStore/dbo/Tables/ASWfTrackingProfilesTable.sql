CREATE TABLE [dbo].[ASWfTrackingProfilesTable] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (450) NULL,
    CONSTRAINT [PK_ASWfTrackingProfilesTable_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [NCI_ASWfTrackingProfilesTable_Name]
    ON [dbo].[ASWfTrackingProfilesTable]([Name] ASC);


GO
GRANT UPDATE
    ON OBJECT::[dbo].[ASWfTrackingProfilesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[ASWfTrackingProfilesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[ASWfTrackingProfilesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[ASWfTrackingProfilesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];

