create procedure [ASInternal_GetArchiveSettings]
  @archiveTableName nvarchar(max) out,
  @useTransaction bit out,
  @importEventsSproc nvarchar(max) out
as
begin	
  declare @defaultSchema sysname;
  declare @archiveServer sysname;
  declare @archiveDatabase sysname;
  declare @sql nvarchar(max);
  declare @paramDef nvarchar(50);
  declare @checkObject smallint;
  
  set @defaultSchema = (select quotename(default_schema_name) from sys.database_principals where name = current_user);
  select @archiveServer = [ArchiveServer], @archiveDatabase = [ArchiveDatabase]
  from [ASConfigurationPropertiesTable];
  
  if @archiveDatabase is null    
  begin
    exec [ASInternal_ThrowError] 103, N'Invalid archive database name', 0;
    return -1;
  end
  
  set @paramDef = N'@objectName sysname, @checkObject smallint out';
  
  if @archiveServer is not null
  begin
  
    -- Verifying the linked server name to prevent sql injection 
    exec [sys].[sp_executesql] N'select @checkObject = server_id from sys.servers where name = @objectName', 
      @paramDef, @archiveServer, @checkObject out;
    
    if @checkObject is null
    begin
      exec [ASInternal_ThrowError] 104, N'Invalid archive linked server name', 0;
      return -1;
    end
    
    set @archiveServer = quotename(@archiveServer);                    
    set @archiveTableName = @archiveServer + N'.';   
    set @useTransaction = 0; 
  end
  else 
  begin
    set @archiveTableName = N'';   
    set @useTransaction = 1; 
  end

  -- Verifying the database name to prevent sql injection    
  if @archiveServer is null
    set @sql = N'select @checkObject = db_id(@objectName)';
  else
    set @sql = N'select @checkObject = database_id from ' + @archiveServer + N'.master.sys.databases where name = @objectName';
                      
  exec [sys].[sp_executesql] @sql, @paramDef, @archiveDatabase, @checkObject out

  if @checkObject is null
    exec [ASInternal_ThrowError] 103, N'Invalid archive database name', 0;
      
  set @archiveDatabase = quotename(@archiveDatabase);
  set @importEventsSproc = @archiveTableName + @archiveDatabase + N'.' + @defaultSchema + N'.[ASImportEvents]';  
  set @archiveTableName = @archiveTableName + @archiveDatabase + N'.' + @defaultSchema + N'.[ASStagingTable]';
         
end