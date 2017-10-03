CREATE ROLE [ASMonitoringDbReader]
    AUTHORIZATION [dbo];


GO
ALTER ROLE [ASMonitoringDbReader] ADD MEMBER [ASMonitoringDbAdmin];

