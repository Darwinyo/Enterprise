create procedure [ASInternal_GetAnnotationSetId]
(@annotations nvarchar(max),
@annotationSetId int output)
as
begin
  declare @annotationsXml xml;
  
  merge [ASWfEventAnnotationSetsTable] with (repeatableread) as [target]
    using (values(@annotations, checksum(@annotations))) as source([Annotations], [AnnotationsChecksum]) 
    on [target].[Annotations] = [source].[Annotations] and
    [target].[AnnotationsChecksum] = [source].[AnnotationsChecksum]
    when not matched then 
      insert ([Annotations], [AnnotationsChecksum]) values (@annotations, checksum(@annotations));
      
  if (@@rowcount = 0)
  begin
    set @annotationSetId = (select [Id] from [ASWfEventAnnotationSetsTable]
     where [Annotations] = @annotations
      and [AnnotationsChecksum] = checksum(@annotations))
  end;
  else
  begin
    set @annotationSetId = scope_identity();
    
    set @annotationsXml = cast(@annotations as xml);
    insert into [ASWfEventAnnotationsTable] ([AnnotationSetId], [Name], [Value])
      select @annotationSetId, [Name], [Value] from [ASInternal_ExtractAnnotationsFromXml](@annotationsXml);    
  end;        
end