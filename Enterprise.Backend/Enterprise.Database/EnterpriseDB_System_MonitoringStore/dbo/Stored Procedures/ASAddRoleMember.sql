create procedure [ASAddRoleMember]
@roleName nvarchar(256),
@roleMemberName nvarchar(128),
@memberSid varbinary(85)
--Return Value 0: Normal completion 1: User and login with stale SID have been recreated
as
begin
	declare @sid varbinary(85);
	declare @principalName sysname;
	declare @returnValue int;
	declare @roleMemberNameQuoted nvarchar(128);
	
	set @returnValue = 0;
	set @roleMemberNameQuoted = suser_sname(suser_sid(@roleMemberName, 0));
	if (@roleMemberNameQuoted is not null)
		set @roleMemberName = @roleMemberNameQuoted;	
	set @roleMemberNameQuoted = quotename(@roleMemberName);
		
	begin
		--Check for a Server Login with the same name but old SID (stale login)
		if exists (select 1 from sys.server_principals where name = @roleMemberName and [sid] <> @memberSid)
		begin try
			--Cleanup Stale Database User (if present) and Server Login
			IF EXISTS (SELECT * FROM sys.database_principals WHERE name = @roleMemberName)
			BEGIN
				exec ('drop user '+@roleMemberNameQuoted);
			END
			exec ('drop login '+@roleMemberNameQuoted);
			set @returnValue = 1;
		end try
		begin catch
		    set @returnValue = 2;
		end catch
			
		--Create a Server Login if not there already
		if not exists (select 1 from sys.server_principals where name = @roleMemberName)
		begin
			exec ('create login '+@roleMemberNameQuoted+' from windows');
		end
		set @sid = (select [sid] from sys.server_principals where name = @roleMemberName)
		--Look for a Database user with this SID. Could have a different name, like dbo.  Create if needed.
		if not exists (select [name] from sys.database_principals where [sid] = @sid)
		begin
			exec ('create user '+@roleMemberNameQuoted+' from login '+@roleMemberNameQuoted);
		end
		--Get the Principal name for the Database User (not necessarily the same as the roleMemberName).
		set @principalName = (select [name] from sys.database_principals where [sid] = @sid);
	end
	if not (@principalName = 'dbo' OR @principalName = 'sys')
	begin
		exec sp_addrolemember @roleName, @principalName;
	end	
	return @returnValue;
end
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[ASAddRoleMember] TO [ASMonitoringDbAdmin]
    AS [dbo];

