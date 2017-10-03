create view [ASEventSources]
as
select	[Id],
  [Name],
  [Computer],
  [Site],
  [VirtualPath],
  [ApplicationVirtualPath],
  [ServiceVirtualPath]
  from [ASEventSourcesTable];
GO
GRANT SELECT
    ON OBJECT::[dbo].[ASEventSources] TO [ASMonitoringDbReader]
    AS [dbo];

