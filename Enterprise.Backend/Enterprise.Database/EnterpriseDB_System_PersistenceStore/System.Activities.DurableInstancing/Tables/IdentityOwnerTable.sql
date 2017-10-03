CREATE TABLE [System.Activities.DurableInstancing].[IdentityOwnerTable] (
    [SurrogateIdentityId]  BIGINT NOT NULL,
    [SurrogateLockOwnerId] BIGINT NOT NULL,
    CONSTRAINT [NCIX_IdentityOwnerTable_IdentityOwner] PRIMARY KEY CLUSTERED ([SurrogateLockOwnerId] ASC, [SurrogateIdentityId] ASC) WITH (ALLOW_PAGE_LOCKS = OFF)
);

