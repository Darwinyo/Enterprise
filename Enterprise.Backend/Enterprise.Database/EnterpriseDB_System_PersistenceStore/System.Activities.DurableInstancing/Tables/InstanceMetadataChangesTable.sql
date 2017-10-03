CREATE TABLE [System.Activities.DurableInstancing].[InstanceMetadataChangesTable] (
    [SurrogateInstanceId] BIGINT          NOT NULL,
    [ChangeTime]          BIGINT          IDENTITY (1, 1) NOT NULL,
    [EncodingOption]      TINYINT         NOT NULL,
    [Change]              VARBINARY (MAX) NOT NULL,
    CONSTRAINT [CIX_InstanceMetadataChangesTable] PRIMARY KEY CLUSTERED ([SurrogateInstanceId] ASC, [ChangeTime] ASC)
);

