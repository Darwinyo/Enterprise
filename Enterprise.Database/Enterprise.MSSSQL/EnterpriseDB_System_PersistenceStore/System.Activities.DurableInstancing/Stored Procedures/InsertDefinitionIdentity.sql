
create procedure [System.Activities.DurableInstancing].[InsertDefinitionIdentity]	
	@identityMetadata xml = null
as
begin
	set nocount on
	set transaction isolation level read committed		
	set xact_abort on;
	
	if (@identityMetadata is not null)
	 begin
		insert into [System.Activities.DurableInstancing].[DefinitionIdentityTable]
		(
				[DefinitionIdentityHash],
				[DefinitionIdentityAnyRevisionHash],
				[Name],
				[Package],
				[Build],
				[Major],
				[Minor],
				[Revision]
		)
		select 	T.Item.value('DefinitionIdentityHash[1]', 'uniqueidentifier'),
				T.Item.value('DefinitionIdentityAnyRevisionHash[1]', 'uniqueidentifier'),
				T.Item.value('Name[1]', 'nvarchar(max)'),
				T.Item.value('Package[1]', 'nvarchar(max)'),
				T.Item.value('Build[1]', 'bigint'),
				T.Item.value('Major[1]', 'bigint'),
				T.Item.value('Minor[1]', 'bigint'),
				T.Item.value('Revision[1]', 'bigint')
		from	@identityMetadata.nodes('/IdentityMetadata/IdentityCollection/Identity') as T(Item)
	 end	
end
GO
GRANT EXECUTE
    ON OBJECT::[System.Activities.DurableInstancing].[InsertDefinitionIdentity] TO [System.Activities.DurableInstancing.InstanceStoreUsers]
    AS [dbo];

