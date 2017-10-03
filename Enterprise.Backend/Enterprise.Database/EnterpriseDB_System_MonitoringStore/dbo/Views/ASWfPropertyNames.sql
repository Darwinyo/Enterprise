create view [ASWfPropertyNames]
as
select	[EventSourceId],
  [Name],
  [Type]
  from [ASWfPropertyNamesTable];
GO
GRANT SELECT
    ON OBJECT::[dbo].[ASWfPropertyNames] TO [ASMonitoringDbReader]
    AS [dbo];

