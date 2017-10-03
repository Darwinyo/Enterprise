create procedure [ASInternal_CreateMonitoringTablePartition]
  @tableName sysname, 
  @fileGroup sysname,
  @partitionDateTime datetime2    
as 
begin
  declare @sql nvarchar(max);
  declare @paramDef nvarchar(50);
  
  if @fileGroup is null
  begin
    set @fileGroup = N'[PRIMARY]'; -- Default file group is case sensitive.
  end
  
  set @sql = N'alter partition scheme ' + quotename(N'MSAppServerPS_' + @tableName) + N' next used ' + @fileGroup;        
  exec [sys].[sp_executesql] @sql;
      	      
  set @sql = N'alter partition function ' +  quotename(N'MSAppServerPF_' + @tableName) + N'() split range (@partitionDateTime)';
  set @paramDef = N'@partitionDateTime datetime2';
  exec [sys].[sp_executesql] @sql, @paramDef, @partitionDateTime;
end