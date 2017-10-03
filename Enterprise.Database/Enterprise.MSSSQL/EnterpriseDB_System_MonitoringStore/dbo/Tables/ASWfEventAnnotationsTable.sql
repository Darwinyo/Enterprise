CREATE TABLE [dbo].[ASWfEventAnnotationsTable] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [AnnotationSetId] INT            NOT NULL,
    [Name]            NVARCHAR (128) NOT NULL,
    [Value]           NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_ASWfEventAnnotationsTable_AnnotationSetId] PRIMARY KEY NONCLUSTERED ([Id] ASC)
);


GO
CREATE CLUSTERED INDEX [CI_ASWfEventAnnotationsTable_AnnotationSetId]
    ON [dbo].[ASWfEventAnnotationsTable]([AnnotationSetId] ASC);


GO
GRANT UPDATE
    ON OBJECT::[dbo].[ASWfEventAnnotationsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[ASWfEventAnnotationsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[ASWfEventAnnotationsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[ASWfEventAnnotationsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];

