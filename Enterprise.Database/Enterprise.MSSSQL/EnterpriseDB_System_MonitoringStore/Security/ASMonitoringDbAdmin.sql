CREATE ROLE [ASMonitoringDbAdmin]
    AUTHORIZATION [dbo];


GO
ALTER ROLE [ASMonitoringDbAdmin] ADD MEMBER [AS_MonitoringDbJobsAdmin];

