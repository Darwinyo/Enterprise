
CREATE PROCEDURE [Microsoft.ApplicationServer.DurableInstancing].[PS_AddRoleMember]
@roleName nvarchar(256),
@roleMemberName nvarchar(128),
@memberSid varbinary(85)
--Return Value 0: Normal completion 
--             1: User and login with stale SID have been recreated
--             2: User and login with stale SID failed to be dropped because other artifacts are secured by the stale principals
AS
BEGIN
	DECLARE @sid varbinary(85)
	DECLARE @principalName sysname
	DECLARE @returnValue int
	DECLARE @quotedMemberName nvarchar(130)
	
	set @returnValue = 0
	
	--This is to get the approriate casing for the provided name	
	set @sid = SUSER_SID(@roleMemberName, 0)
	if (@sid is not null)
	begin
		set @roleMemberName = suser_sname(@sid)
	end
	
	set @quotedMemberName = quotename(@roleMemberName)
		
	BEGIN
	    --Check for a Server Login with the same name but old SID (stale login)
		IF EXISTS (SELECT * FROM sys.server_principals WHERE name = @roleMemberName and [sid] <> @memberSid)
		BEGIN
		    --Cleanup Stale Database User (if present) and Server Login
			begin try
				IF EXISTS (SELECT * FROM sys.database_principals WHERE name = @roleMemberName)
				BEGIN
					exec ('DROP USER '+@quotedMemberName)
				END
				exec ('DROP LOGIN '+@quotedMemberName)
				set @returnValue = 1
			end try
			begin catch
				set @returnValue = 2
			end catch
		END
		--Create a Server Login if not there already
		IF NOT EXISTS (SELECT * FROM sys.server_principals WHERE name = @roleMemberName)
		BEGIN
			exec ('CREATE LOGIN '+@quotedMemberName+' FROM WINDOWS')
		END
		SET @sid = (SELECT [sid] FROM sys.server_principals WHERE name = @roleMemberName)
		--Look for a Database user with this SID. Could have a different name, like dbo.  Create if needed.
		IF NOT EXISTS (SELECT [name] FROM sys.database_principals WHERE [sid] = @sid union SELECT [name] FROM sys.database_principals WHERE [name] = @roleMemberName)
		BEGIN
			exec ('CREATE USER '+@quotedMemberName+' FROM LOGIN '+@quotedMemberName)
		END
		--Get the Principal name for the Database User (not necessarily the same as the roleMemberName).
		SET @principalName = (SELECT [name] FROM sys.database_principals WHERE [sid] = @sid)
	END
	IF NOT (@principalName = 'dbo' OR @principalName = 'sys')
	BEGIN
		exec sp_addrolemember @roleName, @principalName				
	END	
	return @returnValue
END