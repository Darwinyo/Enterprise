CREATE TABLE [System.Activities.DurableInstancing].[LockOwnersTable] (
    [Id]                              UNIQUEIDENTIFIER NOT NULL,
    [SurrogateLockOwnerId]            BIGINT           IDENTITY (1, 1) NOT NULL,
    [LockExpiration]                  DATETIME         NOT NULL,
    [WorkflowHostType]                UNIQUEIDENTIFIER NULL,
    [MachineName]                     NVARCHAR (128)   NOT NULL,
    [EnqueueCommand]                  BIT              NOT NULL,
    [DeletesInstanceOnCompletion]     BIT              NOT NULL,
    [PrimitiveLockOwnerData]          VARBINARY (MAX)  DEFAULT (NULL) NULL,
    [ComplexLockOwnerData]            VARBINARY (MAX)  DEFAULT (NULL) NULL,
    [WriteOnlyPrimitiveLockOwnerData] VARBINARY (MAX)  DEFAULT (NULL) NULL,
    [WriteOnlyComplexLockOwnerData]   VARBINARY (MAX)  DEFAULT (NULL) NULL,
    [EncodingOption]                  TINYINT          DEFAULT ((0)) NULL,
    [WorkflowIdentityFilter]          TINYINT          NOT NULL,
    CONSTRAINT [CIX_LockOwnersTable] PRIMARY KEY CLUSTERED ([SurrogateLockOwnerId] ASC) WITH (ALLOW_PAGE_LOCKS = OFF)
);


GO
CREATE NONCLUSTERED INDEX [NCIX_LockOwnersTable_WorkflowIdentityFilter]
    ON [System.Activities.DurableInstancing].[LockOwnersTable]([WorkflowIdentityFilter] ASC) WITH (ALLOW_PAGE_LOCKS = OFF);


GO
CREATE NONCLUSTERED INDEX [NCIX_LockOwnersTable_WorkflowHostType]
    ON [System.Activities.DurableInstancing].[LockOwnersTable]([WorkflowHostType] ASC) WITH (ALLOW_PAGE_LOCKS = OFF);


GO
CREATE NONCLUSTERED INDEX [NCIX_LockOwnersTable_LockExpiration]
    ON [System.Activities.DurableInstancing].[LockOwnersTable]([LockExpiration] ASC)
    INCLUDE([WorkflowHostType], [MachineName]) WITH (ALLOW_PAGE_LOCKS = OFF);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NCIX_LockOwnersTable_Id]
    ON [System.Activities.DurableInstancing].[LockOwnersTable]([Id] ASC) WITH (ALLOW_PAGE_LOCKS = OFF, IGNORE_DUP_KEY = ON);

