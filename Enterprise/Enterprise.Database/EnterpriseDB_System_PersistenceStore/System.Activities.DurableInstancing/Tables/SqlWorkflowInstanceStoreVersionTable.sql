CREATE TABLE [System.Activities.DurableInstancing].[SqlWorkflowInstanceStoreVersionTable] (
    [Major]       BIGINT   NOT NULL,
    [Minor]       BIGINT   NOT NULL,
    [Build]       BIGINT   NOT NULL,
    [Revision]    BIGINT   NOT NULL,
    [LastUpdated] DATETIME NULL,
    CONSTRAINT [CIX_SqlWorkflowInstanceStoreVersionTable] PRIMARY KEY CLUSTERED ([Major] ASC, [Minor] ASC, [Build] ASC, [Revision] ASC)
);

