create view [ASConfigProperties]
as
select  [ArchiveServer],
  [ArchiveDatabase],
  [APEnabled],
  [APThreshold],
  [APMaxEventAge],
  [APTrimPercentage]
  from [ASConfigurationPropertiesTable];
GO
GRANT SELECT
    ON OBJECT::[dbo].[ASConfigProperties] TO [ASMonitoringDbAdmin]
    AS [dbo];

