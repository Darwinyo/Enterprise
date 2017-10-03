create function [ASInternal_GetCustomAnotations] (@eventId bigint)
returns nvarchar(max)
as
begin
  declare @annotations nvarchar(max);
  
  set @annotations = 
    (select [Annotations] 
      from [ASWfEventsTable] as [WE]
      join
      [ASWfEventAnnotationSetsTable] as [WEAS]
      on [WE].[AnnotationSetId] = [WEAS].[Id]
      where [WE].[Id] = @eventId);
   
  return @annotations;
end