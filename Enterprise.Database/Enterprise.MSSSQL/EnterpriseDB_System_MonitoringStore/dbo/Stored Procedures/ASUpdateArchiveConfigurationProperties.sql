create procedure [ASUpdateArchiveConfigurationProperties]
(
  @archiveServer sysname,
  @archiveDatabase sysname
)
as
  begin	
    set nocount on;

    set transaction isolation level read committed;

    update [ASConfigurationPropertiesTable]
      set [ArchiveServer] = @archiveServer,
          [ArchiveDatabase] = @archiveDatabase;        
  end;
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[ASUpdateArchiveConfigurationProperties] TO [ASMonitoringDbAdmin]
    AS [dbo];

