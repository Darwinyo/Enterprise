create procedure [ASInternal_GetWfTrackingProfileId]
(@trackingProfile nvarchar(450),
@trackingProfileId int output)
as
begin
  merge [ASWfTrackingProfilesTable] with (repeatableread) as [target]
    using (values(@trackingProfile)) as source([Name]) 
    on [target].[Name] = [source].[Name]
    when not matched then 
      insert ([Name]) values (@trackingProfile);
      
  if (@@rowcount = 0)
  begin
    set @trackingProfileId = (select [Id] from [ASWfTrackingProfilesTable]
     where [Name] = @trackingProfile)
  end;
  else
  begin
    set @trackingProfileId = scope_identity();
  end;        
end;