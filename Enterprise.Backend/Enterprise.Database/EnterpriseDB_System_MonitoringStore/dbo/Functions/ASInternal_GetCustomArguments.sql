create function [ASInternal_GetCustomArguments] (@eventId bigint)
returns nvarchar(max)
as
begin
  declare @arguments xml;
  
  set @arguments = (select [Name], [Type], [Value], [ValueBlob] 
  from [ASWfEventPropertiesTable]
  where [EventId] = @eventId and [WfDataSourceId] = 1
  for xml auto, binary base64, type).query(
  N'<items>{
     for $a in /ASWfEventPropertiesTable
     return 
     <item name="{data($a/@Name)}" type="{data($a/@Type)}">{if ($a/@ValueBlob) then data($a/@ValueBlob) else data($a/@Value)}</item>
   }</items>')
   
  return cast(@arguments as nvarchar(max)); 
end