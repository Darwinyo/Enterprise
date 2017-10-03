create function [ASInternal_GetEventSource](@name nvarchar(256), 
  @site nvarchar(256),
  @virtualPath nvarchar(256),
  @appVirtualPath nvarchar(256),
  @serviceVirtualPath nvarchar(256))
returns nvarchar(1024)
as 
begin    
  declare @eventSource nvarchar(1024);

  set @eventSource = N'';
    
  if @name is not null
    set @eventSource = @name;

  if (@appVirtualPath is not null and @serviceVirtualPath is not null)
    set @eventSource = @appVirtualPath + N'|' + @serviceVirtualPath + N'|' + @eventSource;
  else if (@virtualPath is not null)
    set @eventSource = @virtualPath + N'|' + @eventSource;
    
  if @site is not null
    set @eventSource = @site + @eventSource;    
      
  return @eventSource;    
end