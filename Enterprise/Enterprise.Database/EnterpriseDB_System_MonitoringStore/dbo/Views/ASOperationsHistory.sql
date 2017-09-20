create view [ASOperationsHistory]
as
select 
  [Id], 
  [UserLogin], 
  case [OperationId]
    when 1 then N'ASCreateEventTablesPartition'
    when 2 then N'ASPurgeEventData'
    when 3 then N'ASAutoPurge'
  end as [Name], 
  [Parameters],   
  [Status],
  [Message],
  [Log],
  [StartTime],
  [EndTime]
  from [ASOperationsHistoryTable];
GO
GRANT SELECT
    ON OBJECT::[dbo].[ASOperationsHistory] TO [ASMonitoringDbAdmin]
    AS [dbo];

