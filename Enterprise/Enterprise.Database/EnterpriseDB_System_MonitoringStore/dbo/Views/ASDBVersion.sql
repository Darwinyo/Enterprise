create view [ASDBVersion]
as
select  [DbIdentity] as [DbIdentity],
  [MajorVersion],
  [MinorVersion],
  [BuildVersion],
  [RevisionVersion]
  from [ASDBVersionTable];
GO
GRANT SELECT
    ON OBJECT::[dbo].[ASDBVersion] TO [ASMonitoringDbReader]
    AS [dbo];

