CREATE TABLE [dbo].[ASConfigurationPropertiesTable] (
    [Id]                        INT            IDENTITY (1, 1) NOT NULL,
    [ArchiveServer]             NVARCHAR (128) NULL,
    [ArchiveDatabase]           NVARCHAR (128) NULL,
    [MaxSizeFailedStagingTable] BIGINT         NULL,
    [APEnabled]                 BIT            NOT NULL,
    [APThreshold]               INT            NULL,
    [APMaxEventAge]             FLOAT (53)     NULL,
    [APTrimPercentage]          INT            NULL,
    CONSTRAINT [PK_ASConfigurationPropertiesTable_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Check_ASConfigurationPropertiesTable_APMaxEventAgeIsValid] CHECK ([APMaxEventAge]>(0)),
    CONSTRAINT [Check_ASConfigurationPropertiesTable_APThresholdIsValid] CHECK ([APThreshold]>(0)),
    CONSTRAINT [Check_ASConfigurationPropertiesTable_APTrimPercentageIsValid] CHECK ([APTrimPercentage]>(0) AND [APTrimPercentage]<=(100))
);


GO
GRANT UPDATE
    ON OBJECT::[dbo].[ASConfigurationPropertiesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[ASConfigurationPropertiesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[ASConfigurationPropertiesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[ASConfigurationPropertiesTable] TO [ASMonitoringDbAdmin]
    AS [dbo];

