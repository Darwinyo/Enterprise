create view [ASWfEventProperties]
as
select	[EventId],
  [Name],
  case [WfDataSourceId]
    when 0 then N'Variable'
    when 1 then N'Argument'
  end as [WfDataSource],
  [Type],
  cast([Value] as nvarchar(318)) as [Value],
  [ValueBlob],
  [TimeCreated]
  from [ASWfEventPropertiesTable];
GO
GRANT SELECT
    ON OBJECT::[dbo].[ASWfEventProperties] TO [ASMonitoringDbReader]
    AS [dbo];

