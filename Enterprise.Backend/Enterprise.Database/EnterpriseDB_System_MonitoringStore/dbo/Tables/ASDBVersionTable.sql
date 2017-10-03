CREATE TABLE [dbo].[ASDBVersionTable] (
    [DbIdentity]      NVARCHAR (36) NOT NULL,
    [MajorVersion]    INT           NOT NULL,
    [MinorVersion]    INT           NOT NULL,
    [BuildVersion]    INT           NOT NULL,
    [RevisionVersion] INT           NOT NULL
);


GO
GRANT UPDATE
    ON OBJECT::[dbo].[ASDBVersionTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[ASDBVersionTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[ASDBVersionTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[ASDBVersionTable] TO [ASMonitoringDbAdmin]
    AS [dbo];

