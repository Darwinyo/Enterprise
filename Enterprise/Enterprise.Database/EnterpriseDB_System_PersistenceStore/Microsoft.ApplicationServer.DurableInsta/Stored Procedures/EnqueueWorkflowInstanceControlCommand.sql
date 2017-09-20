
create procedure [Microsoft.ApplicationServer.DurableInstancing].[EnqueueWorkflowInstanceControlCommand]
	@instanceId uniqueIdentifier,
	@commandType tinyint,
	@serviceIdentifier nvarchar(max)
    --return value - 0 - Success, 
        --		 1 - Instance does not exist, 
	--               2 - Command not recognized,
	--               3 - Control command on instance already exists
as
begin
    
	set nocount on;
	set transaction isolation level read committed;
	set xact_abort on;
	set deadlock_priority low;
	
	declare @result as int
	set @result = 0	
	
	if ((@commandType < 0) or (@commandType > 4))
	begin
		set @result = 2		
		goto ExitProcNoTran
	end

	begin tran	
	
	if not exists (select top 1 1 from [System.Activities.DurableInstancing].[Instances] where [InstanceId] = @instanceId)
	begin
		set @result = 1		
		goto ExitProc
	end

	if (@commandType = 4) -- delete
	begin
		delete from [System.Activities.DurableInstancing].[Instances] where [InstanceId] = @instanceId
		delete from [AbandonedInstanceControlCommandsTable] where @instanceId = [InstanceId]
		goto ExitProc
	end
				
	insert into [InstanceControlCommandsTable] ([InstanceId], [ServiceIdentifier], [Type], [ExecutionAttempts])
			values(@instanceId, @serviceIdentifier, @commandType, 0);		
	if (@@ROWCOUNT = 0)
	begin
		set @result = 3
		goto ExitProc
	end
	else
	begin
		delete from [AbandonedInstanceControlCommandsTable]
		where @instanceId = [InstanceId]
	end
			
ExitProc:
	commit tran
ExitProcNoTran:	
	return @result
end
GO
GRANT EXECUTE
    ON OBJECT::[Microsoft.ApplicationServer.DurableInstancing].[EnqueueWorkflowInstanceControlCommand] TO [Microsoft.ApplicationServer.DurableInstancing.WorkflowAdministrators]
    AS [dbo];

