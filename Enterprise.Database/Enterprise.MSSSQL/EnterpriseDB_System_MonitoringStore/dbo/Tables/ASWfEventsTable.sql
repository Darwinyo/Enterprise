CREATE TABLE [dbo].[ASWfEventsTable] (
    [Id]                 BIGINT         NOT NULL,
    [EventTypeId]        INT            NOT NULL,
    [EventSourceId]      INT            NOT NULL,
    [ProcessId]          INT            NOT NULL,
    [TraceLevelId]       TINYINT        NOT NULL,
    [WorkflowInstanceId] NVARCHAR (36)  NULL,
    [RecordNumber]       BIGINT         NULL,
    [TrackingProfileId]  INT            NULL,
    [AnnotationSetId]    INT            NULL,
    [TimeCreated]        DATETIME2 (7)  NOT NULL,
    [Data1Str]           NVARCHAR (450) NULL,
    [Data2Str]           NVARCHAR (450) NULL,
    [Data3Str]           NVARCHAR (450) NULL,
    [Data4Str]           NVARCHAR (450) NULL,
    [Data5Str]           NVARCHAR (450) NULL,
    [Data6Str]           NVARCHAR (450) NULL,
    [Data7Str]           NVARCHAR (450) NULL,
    [Data8Str]           NVARCHAR (450) NULL,
    [Data1MaxStr]        NVARCHAR (MAX) NULL,
    [Data1Int]           INT            NULL
);


GO
CREATE NONCLUSTERED INDEX [NCI_ASWfEventsTable_EventSourceId]
    ON [dbo].[ASWfEventsTable]([EventSourceId] ASC)
    ON [MSAppServerPS_ASWfEventsTable] ([TimeCreated]);


GO
CREATE NONCLUSTERED INDEX [NCI_ASWfEventsTable_WorkflowInstanceId]
    ON [dbo].[ASWfEventsTable]([WorkflowInstanceId] ASC)
    ON [MSAppServerPS_ASWfEventsTable] ([TimeCreated]);


GO
CREATE NONCLUSTERED INDEX [NCI_ASWfEventsTable_Id]
    ON [dbo].[ASWfEventsTable]([Id] ASC)
    ON [MSAppServerPS_ASWfEventsTable] ([TimeCreated]);


GO
CREATE CLUSTERED INDEX [CI_ASWfEventsTable_TimeCreated]
    ON [dbo].[ASWfEventsTable]([TimeCreated] ASC) WITH (DATA_COMPRESSION = PAGE ON PARTITIONS (1), DATA_COMPRESSION = PAGE ON PARTITIONS (2))
    ON [MSAppServerPS_ASWfEventsTable] ([TimeCreated]);


GO
create trigger [ASWfEventsTable_AfterInsertTrigger]
on [ASWfEventsTable]
after insert
as
  -- Handles inserting first state for all workflow instances
  merge [ASWfInstancesTable] as [target]
    using (select
      [WorkflowInstanceId],
      [State],
      [EventTypeId],
      [TimeCreated],
      [RecordNumber],
      [EventSourceId],
      case [EventTypeId]
        when 101 then 1 -- WorkflowInstanceUnhandledExceptionRecord
        else 0
      end as [ExceptionCount],
      case [EventTypeId]
        when 102 then [TimeCreated] -- WorkflowInstanceAbortedRecord
      end as [LastAbortedTime]
      from
        (select
          [WorkflowInstanceId],
          case [EventTypeId]
            when 100 then [Data1Str]
            when 101 then N'UnhandledException'
            when 102 then N'Aborted'
            when 112 then N'Suspended'
            when 113 then N'Terminated'            
          end as [State],
          [EventTypeId],
          [TimeCreated],
          [RecordNumber],
          [EventSourceId],
          row_number() over (partition by [WorkflowInstanceId] order by [TimeCreated] asc, [RecordNumber] asc) as [Rank]
        from inserted
          where ([EventTypeId] = 100 and [Data1Str] <> N'Deleted' and [Data1Str] <> N'Unloaded') -- WorkflowInstanceRecord
          or [EventTypeId] = 101 -- WorkflowInstanceUnhandledExceptionRecord
          or [EventTypeId] = 102 -- WorkflowInstanceAbortedRecord
          or [EventTypeId] = 112 -- WorkflowInstanceSuspendedRecord
          or [EventTypeId] = 113) -- WorkflowInstanceTerminatedRecord          
          as [WorkflowEvents] 
        where [Rank] = 1) as [source]
      on ([target].[WorkflowInstanceId] = [source].[WorkflowInstanceId])
      when not matched then
        insert ([WorkflowInstanceId], [LastEventSourceId], [LastEventStatus], [LatestRecordNumber], [StartTime], [LastModifiedTime], 
          [CurrentDuration], [ExceptionCount], [LastAbortedTime])
          values ([source].[WorkflowInstanceId], [source].[EventSourceId], [source].[State], [source].[RecordNumber], [source].[TimeCreated], [source].[TimeCreated], 
          0, [source].[ExceptionCount], [source].[LastAbortedTime]);

  -- Handles updating last state for all workflow instances. Skip Deleted and Unloaded states.
  merge [ASWfInstancesTable] as [target]
    using (select
      [WorkflowInstanceId],
      [State],
      [EventTypeId],
      [TimeCreated],
      [RecordNumber],
      [EventSourceId]
      from
        (select
          [WorkflowInstanceId],
          case [EventTypeId]
            when 100 then [Data1Str]
            when 101 then N'UnhandledException'
            when 102 then N'Aborted'
            when 112 then N'Suspended'
            when 113 then N'Terminated'            
          end as [State],
          [EventTypeId],
          [RecordNumber],
          [TimeCreated],
          [EventSourceId],
          row_number() over (partition by [WorkflowInstanceId] order by [TimeCreated] desc, [RecordNumber] desc) as [Rank]
        from inserted
          where ([EventTypeId] = 100 and [Data1Str] <> N'Deleted' and [Data1Str] <> N'Unloaded') -- WorkflowInstanceRecord
          or [EventTypeId] = 101 -- WorkflowInstanceUnhandledExceptionRecord          
          or [EventTypeId] = 102 -- WorkflowInstanceAbortedRecord
          or [EventTypeId] = 112 -- WorkflowInstanceSuspendedRecord
          or [EventTypeId] = 113) -- WorkflowInstanceTerminatedRecord          
          as [WorkflowEvents]
        where [Rank] = 1) as [source]
      on ([target].[WorkflowInstanceId] = [source].[WorkflowInstanceId] and 
          ([source].[TimeCreated] > [target].[LastModifiedTime] or
          ([source].[TimeCreated] = [target].[LastModifiedTime] and [source].[RecordNumber] >= [target].[LatestRecordNumber])))
      when matched then 
        update set 
          [LastEventSourceId] = [source].[EventSourceId],
          [LastEventStatus] = [source].[State],
          [LatestRecordNumber] = [source].[RecordNumber],
          [LastModifiedTime] = [source].[TimeCreated],
          [CurrentDuration] = datediff(s, [target].[StartTime], [source].[TimeCreated]);  
    
  -- Handles updating LastAbortedTime for all workflow instances (the last seen record 101 or 102)
  merge [ASWfInstancesTable] as [target]
    using (select
      [WorkflowInstanceId],
      case [EventTypeId]
        when 101 then [TimeCreated] -- WorkflowInstanceUnhandledExceptionRecord
        when 102 then [TimeCreated] -- WorkflowInstanceAbortedRecord
      end as [LastAbortedTime],
      [TimeCreated],
      [RecordNumber]      
      from
        (select
          [WorkflowInstanceId],
          [EventTypeId],
          [TimeCreated],
          [RecordNumber],               
          row_number() over (partition by [WorkflowInstanceId] order by [TimeCreated] desc, [RecordNumber] desc) as [Rank]
        from inserted
          where [EventTypeId] = 102 or -- WorkflowInstanceAbortedRecord
          [EventTypeId] = 101 -- WorkflowInstanceUnhandledExceptionRecord
          ) as [WorkflowEvents] 
        where [Rank] = 1) as [source]
      on ([target].[WorkflowInstanceId] = [source].[WorkflowInstanceId] and
        ([target].[LastAbortedTime] is null or
         [target].[LastAbortedTime] < [source].[LastAbortedTime]))
      when matched then 
        update set 
          [LastAbortedTime] = [source].[LastAbortedTime];

  -- Handles updating CountUnhandledExceptions for all workflow instances
  merge [ASWfInstancesTable] as [target]
    using (select
        [WorkflowInstanceId],
        count(*) as [Count]
        from inserted
          where [EventTypeId] = 101 -- WorkflowInstanceUnhandledExceptionRecord
          group by [WorkflowInstanceId]) as [source]
      on ([target].[WorkflowInstanceId] = [source].[WorkflowInstanceId])
      when matched then 
        update set 
          [ExceptionCount] = [target].[ExceptionCount] + [source].[Count];
GO
GRANT UPDATE
    ON OBJECT::[dbo].[ASWfEventsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[ASWfEventsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[ASWfEventsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[ASWfEventsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];

