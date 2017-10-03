create view [ASWfEventAnnotations]
as
select	[Id],
  [AnnotationSetId],
  [Name],
  [Value]
  from [ASWfEventAnnotationsTable];
GO
GRANT SELECT
    ON OBJECT::[dbo].[ASWfEventAnnotations] TO [ASMonitoringDbReader]
    AS [dbo];

