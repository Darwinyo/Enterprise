CREATE TABLE [dbo].[ASWfEventAnnotationSetsTable] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [Annotations]         NVARCHAR (MAX) NOT NULL,
    [AnnotationsChecksum] INT            NOT NULL,
    CONSTRAINT [PK_ASWfEventAnnotationSetsTable_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [NCI_ASWfEventAnnotationSetsTable_AnnotationsChecksum]
    ON [dbo].[ASWfEventAnnotationSetsTable]([AnnotationsChecksum] ASC);


GO
GRANT UPDATE
    ON OBJECT::[dbo].[ASWfEventAnnotationSetsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[ASWfEventAnnotationSetsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[ASWfEventAnnotationSetsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[ASWfEventAnnotationSetsTable] TO [ASMonitoringDbAdmin]
    AS [dbo];

