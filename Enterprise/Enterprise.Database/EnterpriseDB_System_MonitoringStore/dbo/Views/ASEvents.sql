create view [ASEvents]
as
select	[Id],
  [EventTypeId],
  [EventType],
  [EventVersion],
  [EventSourceId],
  [ProcessId],
  [TraceLevelId],
  [TraceLevel],
  [E2EActivityId],
  [TimeCreated]
  from [ASWfEvents]
union all
select	[Id],
  [EventTypeId],
  [EventType],
  [EventVersion],
  [EventSourceId],
  [ProcessId],
  [TraceLevelId],
  [TraceLevel],
  [E2EActivityId],
  [TimeCreated]
  from [ASWcfEvents];
GO
GRANT SELECT
    ON OBJECT::[dbo].[ASEvents] TO [ASMonitoringDbReader]
    AS [dbo];

