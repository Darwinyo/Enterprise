create view [ASTransferEvents]
as
select	[Id],
  [EventTypeId],
  case [EventTypeId]
    when 499 then N'TransferEvent'		
  end as [EventType],
  0 as [EventVersion],
  [EventSourceId],
  [ProcessId],
  [TraceLevelId],
  case [TraceLevelId]
    when 0 then N'LogAlways'
    when 1 then N'Critical'
    when 2 then N'Error'
    when 3 then N'Warning'
    when 4 then N'Information'
    when 5 then N'Verbose'
  end as [TraceLevel],		
  [E2EActivityId],
  [ToE2EActivityId],
  [TimeCreated]
  from [ASTransferEventsTable];
GO
GRANT SELECT
    ON OBJECT::[dbo].[ASTransferEvents] TO [ASMonitoringDbReader]
    AS [dbo];

