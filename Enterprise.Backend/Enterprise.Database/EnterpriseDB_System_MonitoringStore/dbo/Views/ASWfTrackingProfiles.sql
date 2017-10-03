create view [ASWfTrackingProfiles]
as
select  [Id],
  [Name]
  from [ASWfTrackingProfilesTable];
GO
GRANT SELECT
    ON OBJECT::[dbo].[ASWfTrackingProfiles] TO [ASMonitoringDbReader]
    AS [dbo];

