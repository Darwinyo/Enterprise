create view [ASWfEvents]
as
select  [Id],
  [EventTypeId],
  case [EventTypeId]
    when 100 then N'WorkflowInstanceRecord'
    when 101 then N'WorkflowInstanceUnhandledExceptionRecord'
    when 102 then N'WorkflowInstanceAbortedRecord'
    when 103 then N'ActivityStateRecord'
    when 104 then N'ActivityScheduledRecord'		
    when 105 then N'FaultPropagationRecord'
    when 106 then N'CancelRequestedRecord'
    when 107 then N'BookmarkResumptionRecord'
    when 108 then N'CustomTrackingRecord'
    when 110 then N'CustomTrackingRecord'
    when 111 then N'CustomTrackingRecord'
    when 112 then N'WorkflowInstanceSuspendedRecord'
    when 113 then N'WorkflowInstanceTerminatedRecord'    
  end as [EventType],
  0 as [EventVersion],
  [EventSourceId],
  [ProcessId],
  [WorkflowInstanceId],
  [TrackingProfileId],
  [WorkflowInstanceId] as [E2EActivityId],		
  [TraceLevelId],
  case [TraceLevelId]
    when 0 then N'LogAlways'
    when 1 then N'Critical'
    when 2 then N'Error'
    when 3 then N'Warning'
    when 4 then N'Information'
    when 5 then N'Verbose'
  end as [TraceLevel],
  [RecordNumber],
  [AnnotationSetId],
  [TimeCreated],		
  case [EventTypeId]
    when 103 then [Data2Str]
    when 104 then [Data1Str]
    when 106 then [Data1Str]
    when 107 then [Data1Str]
    when 108 then [Data4Str]
    when 110 then [Data4Str]
    when 111 then [Data4Str]        
  end as [ActivityName],
  case [EventTypeId]
    when 103 then [Data3Str]
    when 104 then [Data2Str]
    when 106 then [Data2Str]
    when 108 then [Data2Str]
    when 110 then [Data2Str]
    when 111 then [Data2Str]
  end as [ActivityId],
  case [EventTypeId]
    when 103 then [Data4Str]
    when 104 then [Data3Str]
    when 106 then [Data3Str]
    when 108 then [Data3Str]
    when 110 then [Data3Str]
    when 111 then [Data3Str]
  end as [ActivityInstanceId],
  case [EventTypeId]
    when 100 then [Data2Str]
    when 101 then [Data1Str]
    when 102 then [Data1Str]    
  end as [ActivityRootId],
  case [EventTypeId]    
    when 103 then [Data5Str]
    when 104 then [Data7Str]
    when 106 then [Data7Str]
    when 108 then [Data5Str]
    when 110 then [Data5Str]
    when 111 then [Data5Str]
  end as [ActivityTypeName],  
  case [EventTypeId]
    when 108 then [Data1Str]
    when 110 then [Data1Str]
    when 111 then [Data1Str]  
  end as [CustomRecordName],
  case [EventTypeId]
    when 101 then [Data2Str]
  end as [SourceName],
  case [EventTypeId]
    when 101 then [Data3Str]
  end as [SourceId],
  case [EventTypeId]
    when 101 then [Data4Str]
  end as [SourceInstanceId],
  case [EventTypeId]
    when 101 then [Data5Str]
  end as [SourceTypeName],      
  case [EventTypeId]
    when 107 then [Data5Str]
  end as [OwnerType],
  case [EventTypeId]
    when 100 then [Data1Str]
    when 101 then N'UnhandledException'
    when 102 then N'Aborted'		
    when 103 then [Data1Str]
    when 104 then N'Schedule'
    when 105 then N'Fault'
    when 106 then N'Cancel'
    when 112 then N'Suspended'
    when 113 then N'Terminated'    
  end as [State],
  case [EventTypeId]
    when 104 then [Data5Str]
    when 106 then [Data5Str]
  end as [ChildActivityId],
  case [EventTypeId]
    when 104 then [Data6Str]
    when 106 then [Data6Str]
  end as [ChildInstanceId],
  case [EventTypeId]
    when 104 then [Data8Str]
    when 106 then [Data8Str]
  end as [ChildTypeName],  
  case [EventTypeId]
    when 104 then [Data4Str]
    when 106 then [Data4Str]		
  end as [ChildActivityName],
  case [EventTypeId]
    when 105 then [Data1Str]
  end as [FaultSrcName],
  case [EventTypeId]
    when 105 then [Data2Str]
  end as [FaultSrcId],
  case [EventTypeId]
    when 105 then [Data3Str]
  end as [FaultSrcInstanceId],  
  case [EventTypeId]
    when 105 then [Data5Str]
  end as [HandlerId],
  case [EventTypeId]
    when 105 then [Data6Str]
  end as [HandlerInstanceId],
  case [EventTypeId]
    when 105 then [Data4Str]
  end as [FaultHandler],
  case [EventTypeId]
    when 105 then [Data7Str]
  end as [FaultSourceType],
  case [EventTypeId]
    when 105 then [Data8Str]
  end as [FaultHandlerType],
  case [EventTypeId]
    when 105 then [Data1MaxStr]
  end as [Fault],
  case [EventTypeId]
    when 105 then [Data1Int]
  end as [IsFaultSource],		
  case [EventTypeId]
    when 107 then [Data6Str]
  end as [SubInstanceID],
  case [EventTypeId]
    when 107 then [Data3Str]
  end as [OwnerActivityId],
  case [EventTypeId]
    when 107 then [Data4Str]
  end as [OwnerInstanceId],
  case [EventTypeId]
    when 107 then [Data2Str]
  end as [OwnerActivityName],
  case [EventTypeId]
    when 101 then [Data1MaxStr]
  end as [Exception],
  case [EventTypeId]
    when 102 then [Data1MaxStr]
    when 112 then [Data1MaxStr]
    when 113 then [Data1MaxStr]
  end as [Reason]
  from [ASWfEventsTable];
GO
GRANT SELECT
    ON OBJECT::[dbo].[ASWfEvents] TO [ASMonitoringDbReader]
    AS [dbo];

