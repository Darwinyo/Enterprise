CREATE ROLE [ASMonitoringDbWriter]
    AUTHORIZATION [dbo];


GO
ALTER ROLE [ASMonitoringDbWriter] ADD MEMBER [ASMonitoringDbAdmin];

