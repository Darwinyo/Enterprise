create view [ASWfInstances]
as
select	[Id],
  [WorkflowInstanceId],
  [LastEventSourceId],
  [LastEventStatus],
  [StartTime],
  [LastModifiedTime],
  [CurrentDuration],
  [ExceptionCount],
  [LastAbortedTime]
  from [ASWfInstancesTable];
GO
GRANT SELECT
    ON OBJECT::[dbo].[ASWfInstances] TO [ASMonitoringDbReader]
    AS [dbo];

