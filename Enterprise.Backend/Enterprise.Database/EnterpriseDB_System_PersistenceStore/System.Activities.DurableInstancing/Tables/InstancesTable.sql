CREATE TABLE [System.Activities.DurableInstancing].[InstancesTable] (
    [Id]                               UNIQUEIDENTIFIER NOT NULL,
    [SurrogateInstanceId]              BIGINT           IDENTITY (1, 1) NOT NULL,
    [SurrogateLockOwnerId]             BIGINT           NULL,
    [PrimitiveDataProperties]          VARBINARY (MAX)  DEFAULT (NULL) NULL,
    [ComplexDataProperties]            VARBINARY (MAX)  DEFAULT (NULL) NULL,
    [WriteOnlyPrimitiveDataProperties] VARBINARY (MAX)  DEFAULT (NULL) NULL,
    [WriteOnlyComplexDataProperties]   VARBINARY (MAX)  DEFAULT (NULL) NULL,
    [MetadataProperties]               VARBINARY (MAX)  DEFAULT (NULL) NULL,
    [DataEncodingOption]               TINYINT          DEFAULT ((0)) NULL,
    [MetadataEncodingOption]           TINYINT          DEFAULT ((0)) NULL,
    [Version]                          BIGINT           NOT NULL,
    [PendingTimer]                     DATETIME         NULL,
    [CreationTime]                     DATETIME         NOT NULL,
    [LastUpdated]                      DATETIME         DEFAULT (NULL) NULL,
    [WorkflowHostType]                 UNIQUEIDENTIFIER NULL,
    [ServiceDeploymentId]              BIGINT           NULL,
    [SuspensionExceptionName]          NVARCHAR (450)   DEFAULT (NULL) NULL,
    [SuspensionReason]                 NVARCHAR (MAX)   DEFAULT (NULL) NULL,
    [BlockingBookmarks]                NVARCHAR (MAX)   DEFAULT (NULL) NULL,
    [LastMachineRunOn]                 NVARCHAR (450)   DEFAULT (NULL) NULL,
    [ExecutionStatus]                  NVARCHAR (450)   DEFAULT (NULL) NULL,
    [IsInitialized]                    BIT              DEFAULT ((0)) NULL,
    [IsSuspended]                      BIT              DEFAULT ((0)) NULL,
    [IsReadyToRun]                     BIT              DEFAULT ((0)) NULL,
    [IsCompleted]                      BIT              DEFAULT ((0)) NULL,
    [SurrogateIdentityId]              BIGINT           NOT NULL,
    CONSTRAINT [CIX_InstancesTable] PRIMARY KEY CLUSTERED ([SurrogateInstanceId] ASC) WITH (ALLOW_PAGE_LOCKS = OFF)
);


GO
CREATE NONCLUSTERED INDEX [NCIX_InstancesTable_WorkflowHostType]
    ON [System.Activities.DurableInstancing].[InstancesTable]([WorkflowHostType] ASC) WITH (ALLOW_PAGE_LOCKS = OFF);


GO
CREATE NONCLUSTERED INDEX [NCIX_InstancesTable_ServiceDeploymentId]
    ON [System.Activities.DurableInstancing].[InstancesTable]([ServiceDeploymentId] ASC) WITH (ALLOW_PAGE_LOCKS = OFF);


GO
CREATE NONCLUSTERED INDEX [NCIX_InstancesTable_SuspensionExceptionName]
    ON [System.Activities.DurableInstancing].[InstancesTable]([SuspensionExceptionName] ASC) WITH (ALLOW_PAGE_LOCKS = OFF);


GO
CREATE NONCLUSTERED INDEX [NCIX_InstancesTable_CreationTime]
    ON [System.Activities.DurableInstancing].[InstancesTable]([CreationTime] ASC) WITH (ALLOW_PAGE_LOCKS = OFF);


GO
CREATE NONCLUSTERED INDEX [NCIX_InstancesTable_LastUpdated]
    ON [System.Activities.DurableInstancing].[InstancesTable]([LastUpdated] ASC) WITH (ALLOW_PAGE_LOCKS = OFF);


GO
CREATE NONCLUSTERED INDEX [NCIX_InstancesTable_SurrogateLockOwnerId]
    ON [System.Activities.DurableInstancing].[InstancesTable]([SurrogateLockOwnerId] ASC) WITH (ALLOW_PAGE_LOCKS = OFF);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NCIX_InstancesTable_Id]
    ON [System.Activities.DurableInstancing].[InstancesTable]([Id] ASC)
    INCLUDE([Version], [SurrogateLockOwnerId], [IsCompleted]) WITH (ALLOW_PAGE_LOCKS = OFF);

