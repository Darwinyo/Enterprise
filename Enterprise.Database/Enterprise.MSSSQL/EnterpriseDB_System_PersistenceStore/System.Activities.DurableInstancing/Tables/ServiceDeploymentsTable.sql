CREATE TABLE [System.Activities.DurableInstancing].[ServiceDeploymentsTable] (
    [Id]                      BIGINT           IDENTITY (1, 1) NOT NULL,
    [ServiceDeploymentHash]   UNIQUEIDENTIFIER NOT NULL,
    [SiteName]                NVARCHAR (MAX)   NOT NULL,
    [RelativeServicePath]     NVARCHAR (MAX)   NOT NULL,
    [RelativeApplicationPath] NVARCHAR (MAX)   NOT NULL,
    [ServiceName]             NVARCHAR (MAX)   NOT NULL,
    [ServiceNamespace]        NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [CIX_ServiceDeploymentsTable] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (ALLOW_PAGE_LOCKS = OFF)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NCIX_ServiceDeploymentsTable_ServiceDeploymentHash]
    ON [System.Activities.DurableInstancing].[ServiceDeploymentsTable]([ServiceDeploymentHash] ASC) WITH (ALLOW_PAGE_LOCKS = OFF, IGNORE_DUP_KEY = ON);

