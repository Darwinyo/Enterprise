
create procedure [System.Activities.DurableInstancing].[GetWorkflowInstanceStoreVersion]
as
begin
	set nocount on
	set transaction isolation level read committed		
	set xact_abort on;	
		
	select		Major
				,Minor
				,Build
				,Revision
	from		[System.Activities.DurableInstancing].[SqlWorkflowInstanceStoreVersionTable]
	
end
GO
GRANT EXECUTE
    ON OBJECT::[System.Activities.DurableInstancing].[GetWorkflowInstanceStoreVersion] TO [System.Activities.DurableInstancing.WorkflowActivationUsers]
    AS [dbo];


GO
GRANT EXECUTE
    ON OBJECT::[System.Activities.DurableInstancing].[GetWorkflowInstanceStoreVersion] TO [System.Activities.DurableInstancing.InstanceStoreUsers]
    AS [dbo];

