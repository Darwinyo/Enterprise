CREATE TABLE [System.Activities.DurableInstancing].[RunnableInstancesTable] (
    [SurrogateInstanceId] BIGINT           NOT NULL,
    [WorkflowHostType]    UNIQUEIDENTIFIER NULL,
    [ServiceDeploymentId] BIGINT           NULL,
    [RunnableTime]        DATETIME         NOT NULL,
    [SurrogateIdentityId] BIGINT           NOT NULL,
    CONSTRAINT [CIX_RunnableInstancesTable_SurrogateInstanceId] PRIMARY KEY CLUSTERED ([SurrogateInstanceId] ASC) WITH (ALLOW_PAGE_LOCKS = OFF, IGNORE_DUP_KEY = ON)
);


GO
CREATE NONCLUSTERED INDEX [NCIX_RunnableInstancesTable_SurrogateIdentityId]
    ON [System.Activities.DurableInstancing].[RunnableInstancesTable]([SurrogateIdentityId] ASC) WITH (ALLOW_PAGE_LOCKS = OFF);


GO
CREATE NONCLUSTERED INDEX [NCIX_RunnableInstancesTable_RunnableTime]
    ON [System.Activities.DurableInstancing].[RunnableInstancesTable]([RunnableTime] ASC)
    INCLUDE([WorkflowHostType], [ServiceDeploymentId]) WITH (ALLOW_PAGE_LOCKS = OFF);


GO
CREATE NONCLUSTERED INDEX [NCIX_RunnableInstancesTable]
    ON [System.Activities.DurableInstancing].[RunnableInstancesTable]([WorkflowHostType] ASC, [RunnableTime] ASC) WITH (ALLOW_PAGE_LOCKS = OFF);

