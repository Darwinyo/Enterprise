create view [ASWcfEvents]
as
select	[Id],
  [EventTypeId],
  case [EventTypeId]
    when 201 then N'ClientMessageInspectorAfterReceiveInvoked'
    when 202 then N'ClientMessageInspectorBeforeSendInvoked'
    when 203 then N'ClientParameterInspectorAfterCallInvoked'
    when 204 then N'ClientParameterInspectorBeforeCallInvoked'
    when 205 then N'OperationInvoked'
    when 206 then N'ErrorHandlerInvoked'
    when 207 then N'FaultProviderInvoked'
    when 208 then N'MessageInspectorAfterReceiveInvoked'
    when 209 then N'MessageInspectorBeforeSendInvoked'
    when 210 then N'MessageThrottleExceeded'
    when 211 then N'ParameterInspectorAfterCallInvoked'
    when 212 then N'ParameterInspectorBeforeCallInvoked'
    when 213 then N'ServiceHostStarted'
    when 214 then N'OperationCompleted'
    when 215 then N'MessageReceivedByTransport'
    when 216 then N'MessageSentByTransport'
    when 217 then N'ClientOperationPrepared'
    when 218 then N'ClientOperationCompleted'
    when 219 then N'ServiceException'
    when 220 then N'MessageSentToTransport'
    when 221 then N'MessageReceivedFromTransport'
    when 222 then N'OperationFailed'
    when 223 then N'OperationFaulted'
    when 224 then N'MessageThrottleAtSeventyPercent'
    when 225 then N'TraceCorrelationKeys'
    when 301 then N'UserDefinedErrorOccurred'
    when 302 then N'UserDefinedWarningOccurred'
    when 303 then N'UserDefinedInformationEventOccured'
    when 364 then N'AggregateOperationCompleted'
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
  [TimeCreated],
  case [EventTypeId]
    when 220 then [Data1UniqueIdentifier]
    when 221 then [Data1UniqueIdentifier]
  end as [CorrelationId],
  case [EventTypeId]
    when 213 then [Data1Str]
  end as [ServiceTypeName],
  case [EventTypeId]
    when 201 then [Data1Str]
    when 202 then [Data1Str]
    when 203 then [Data1Str]
    when 204 then [Data1Str]
    when 208 then [Data1Str]
    when 209 then [Data1Str]
    when 211 then [Data1Str]
    when 212 then [Data1Str]
  end as [InspectorTypeName],
  case [EventTypeId]
    when 206 then [Data1Str]
    when 207 then [Data1Str]
  end as [ErrorHandlerType],
  case [EventTypeId]
    when 206 then [Data1Int]
  end as [Handled],
  case [EventTypeId]
    when 219 then [Data1MaxStr]
  end as [ExceptionMessage],
  case [EventTypeId]
    when 206 then [Data2Str]
    when 207 then [Data2Str]
    when 219 then [Data1Str]
  end as [ExceptionTypeName],
  case [EventTypeId]
    when 210 then [Data1Str]
    when 224 then [Data1Str]
  end as [ThrottleProperty],
  case [EventTypeId]
    when 210 then [Data1Int]
    when 224 then [Data1Int]
  end as [ThrottleCapacity],
  case [EventTypeId]
    when 215 then [Data1Str]
    when 216 then [Data1Str]
    when 217 then [Data3Str]
    when 218 then [Data3Str]
  end as [Uri],
  case [EventTypeId]
    when 217 then [Data1Str]        
    when 218 then [Data1Str]  
  end as [Action],
  case [EventTypeId]
    when 205 then [Data1Str]
    when 214 then [Data1Str]
    when 222 then [Data1Str]
    when 223 then [Data1Str]
    when 364 then [Data1Str]
  end as [OperationName],
  case [EventTypeId]
    when 205 then [Data2Str]
  end as [CallerInfo],
  case [EventTypeId]
    when 217 then [Data2Str]
    when 218 then [Data2Str]
  end as [ContractName],
  case [EventTypeId]
    when 217 then [Data3Str]
  end as [Destination],
  case [EventTypeId]
    when 214 then [Data1Int]
    when 222 then [Data1Int]
    when 223 then [Data1Int]
  end as [Duration],  
  case [EventTypeId]
    when 225 then [Data1UniqueIdentifier]
  end as [InstanceKey],
  case [EventTypeId]
    when 225 then [Data1Str]
  end as [Values],
  case [EventTypeId]
    when 225 then [Data2Str]
  end as [ParentScope],
  case [EventTypeId]
    when 301 then [Data1Str]
    when 302 then [Data1Str]
    when 303 then [Data1Str]
  end as [Name],
  case [EventTypeId]
    when 301 then [Data1MaxStr]
    when 302 then [Data1MaxStr]
    when 303 then [Data1MaxStr]
  end as [Payload],
  case [EventTypeId]
    when 364 then [Data1Int]
  end as [AggregateCount],
  case [EventTypeId]
    when 364 then [Data2Int]
  end as [AverageDuration],
  case [EventTypeId]
    when 364 then [Data3Int]
  end as [MaxDuration]  
  from [ASWcfEventsTable];
GO
GRANT SELECT
    ON OBJECT::[dbo].[ASWcfEvents] TO [ASMonitoringDbReader]
    AS [dbo];

