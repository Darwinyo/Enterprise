create procedure [ASInternal_GetEventSourceId]
(@computer nvarchar(450),
@eventSource nvarchar(1024),
@eventSourceId int output)
as
begin
  declare @eventSourceName nvarchar(256);
  declare @site nvarchar(256);
  declare @appVirtualPath nvarchar(256);
  declare @serviceVirtualPath nvarchar(256);
  declare @virtualPath nvarchar(256);
  
  declare @appVirtualPathStartIdx int;    
  declare @serviceVirtualPathStartIdx int;    
  declare @serviceNameStartIdx int;

  if (@eventSource is null or len(@eventSource) = 0)
  begin            
    set @eventSourceId = (select [Id] from [ASEventSourcesTable] with (repeatableread)
     where [Name] is null and 
      [Computer] = @computer and
      [Site] is null and
      [VirtualPath] is null);
           
    if (@eventSourceId is null)
    begin           
      merge [ASEventSourcesTable] with (serializable) as [target]
        using (values(@computer)) as source([Computer]) 
        on [target].[Name] is null
        and [target].[Computer] = [source].[Computer]
        and [target].[Site] is null 
        and [target].[VirtualPath] is null
        when not matched then 
          insert ([Name], [Computer], [Site], [VirtualPath]) values (null, @computer, null, null);
      if (@@rowcount = 0)
      begin
        set @eventSourceId = (select [Id] from [ASEventSourcesTable]
         where [Name] is null and 
          [Computer] = @computer and
          [Site] is null and
          [VirtualPath] is null);
      end;
      else
      begin
        set @eventSourceId = scope_identity();
      end;        
    end;
  end
  else
  begin
    -- Examples:
    --Default Web Site/ShoppingCart
    --Default Web Site/ShoppingCart|/ShoppingCartService.xamlx|ShoppingCartService
  
    set @appVirtualPathStartIdx = charindex(N'/', @eventSource);
    set @serviceVirtualPathStartIdx = charindex(N'|', @eventSource);
    if (@serviceVirtualPathStartIdx > 0)
    begin
      set @serviceNameStartIdx = charindex(N'|', @eventSource, @serviceVirtualPathStartIdx + 1);
    end;
        
    -- Must include '/' which can not be the first character
    if (@appVirtualPathStartIdx <= 1)
        exec [ASInternal_ThrowError] 300, N'Unable to parse EventSource.';
            
    if (@serviceVirtualPathStartIdx > 0)
    begin 
      if (@appVirtualPathStartIdx >= @serviceVirtualPathStartIdx - 1)
      begin
        -- Format:
        -- Default Web Site/|/ShoppingCartService.xamlx|ShoppingCartService        
        set @site = substring(@eventSource, 1, @appVirtualPathStartIdx - 1);
        set @appVirtualPath = substring(@eventSource, @appVirtualPathStartIdx, @serviceVirtualPathStartIdx - @appVirtualPathStartIdx);
        set @serviceVirtualPath = substring(@eventSource, @serviceVirtualPathStartIdx + 1, @serviceNameStartIdx - @serviceVirtualPathStartIdx - 1);    
        set @virtualPath = @serviceVirtualPath;
        set @eventSourceName = substring(@eventSource, @serviceNameStartIdx + 1, len(@eventSource) - @serviceNameStartIdx);
        
        set @eventSourceId = (select [Id] from [ASEventSourcesTable] with (repeatableread)
         where [Name] = @eventSourceName and 
          [Computer] = @computer and
          [Site] = @site and
          [VirtualPath] = @virtualPath and
          [ApplicationVirtualPath] = @appVirtualPath and
          [ServiceVirtualPath] = @serviceVirtualPath);
        
        if (@eventSourceId is null)
        begin
          merge [ASEventSourcesTable] with (serializable) as [target]
            using (values(@eventSourceName, @computer, @site, @virtualPath, @appVirtualPath, @serviceVirtualPath)) as source([Name], [Computer], [Site], [VirtualPath], [ApplicationVirtualPath], [ServiceVirtualPath]) 
            on [target].[Name] = [source].[Name] and 
              [target].[Computer] = [source].[Computer] and
              [target].[Site] = [source].[Site] and
              [target].[VirtualPath] = [source].[VirtualPath] and
              [target].[ApplicationVirtualPath] = [source].[ApplicationVirtualPath] and
              [target].[ServiceVirtualPath] = [source].[ServiceVirtualPath]
            when not matched then 
              insert ([Name], [Computer], [Site], [VirtualPath], [ApplicationVirtualPath], [ServiceVirtualPath]) values (@eventSourceName, @computer, @site, @virtualPath, @appVirtualPath, @serviceVirtualPath);       
              
          if (@@rowcount = 0)
          begin
            set @eventSourceId = (select [Id] from [ASEventSourcesTable]
             where [Name] = @eventSourceName and 
              [Computer] = @computer and
              [Site] = @site and
              [VirtualPath] = @virtualPath and 
              [ApplicationVirtualPath] = @appVirtualPath and
              [ServiceVirtualPath] = @serviceVirtualPath);
          end;
          else
          begin
            set @eventSourceId = scope_identity();
          end;
        end;                
      end;
      else if (@serviceNameStartIdx > 0)
      begin
        --Format:
        --Default Web Site/ShoppingCart|/ShoppingCartService.xamlx|ShoppingCartService
        set @site = substring(@eventSource, 1, @appVirtualPathStartIdx - 1);
        set @appVirtualPath = substring(@eventSource, @appVirtualPathStartIdx, @serviceVirtualPathStartIdx - @appVirtualPathStartIdx);
        set @serviceVirtualPath = substring(@eventSource, @serviceVirtualPathStartIdx + 1, @serviceNameStartIdx - @serviceVirtualPathStartIdx - 1);    
        set @virtualPath = @appVirtualPath + @serviceVirtualPath;
        set @eventSourceName = substring(@eventSource, @serviceNameStartIdx + 1, len(@eventSource) - @serviceNameStartIdx);
        
        set @eventSourceId = (select [Id] from [ASEventSourcesTable] with (repeatableread)
         where [Name] = @eventSourceName and 
          [Computer] = @computer and
          [Site] = @site and
          [VirtualPath] = @virtualPath and
          [ApplicationVirtualPath] = @appVirtualPath and
          [ServiceVirtualPath] = @serviceVirtualPath);
        
        if (@eventSourceId is null)
        begin
          merge [ASEventSourcesTable] with (serializable) as [target]
            using (values(@eventSourceName, @computer, @site, @virtualPath, @appVirtualPath, @serviceVirtualPath)) as source([Name], [Computer], [Site], [VirtualPath], [ApplicationVirtualPath], [ServiceVirtualPath]) 
            on [target].[Name] = [source].[Name] and 
              [target].[Computer] = [source].[Computer] and
              [target].[Site] = [source].[Site] and
              [target].[VirtualPath] = [source].[VirtualPath] and
              [target].[ApplicationVirtualPath] = [source].[ApplicationVirtualPath] and
              [target].[ServiceVirtualPath] = [source].[ServiceVirtualPath]
            when not matched then 
              insert ([Name], [Computer], [Site], [VirtualPath], [ApplicationVirtualPath], [ServiceVirtualPath]) values (@eventSourceName, @computer, @site, @virtualPath, @appVirtualPath, @serviceVirtualPath);       
              
          if (@@rowcount = 0)
          begin
            set @eventSourceId = (select [Id] from [ASEventSourcesTable]
             where [Name] = @eventSourceName and 
              [Computer] = @computer and
              [Site] = @site and
              [VirtualPath] = @virtualPath and 
              [ApplicationVirtualPath] = @appVirtualPath and
              [ServiceVirtualPath] = @serviceVirtualPath);
          end;
          else
          begin
            set @eventSourceId = scope_identity();
          end;
        end;        
      end
      else
      begin
        --Format:
        --Default Web Site/ShoppingCart/ShoppingCartService.xamlx|ShoppingCartService

        set @site = substring(@eventSource, 1, @appVirtualPathStartIdx - 1);
        set @virtualPath = substring(@eventSource, @appVirtualPathStartIdx, @serviceVirtualPathStartIdx - @appVirtualPathStartIdx);        
        set @eventSourceName = substring(@eventSource, @serviceVirtualPathStartIdx + 1, len(@eventSource) - @serviceVirtualPathStartIdx);      
        
        set @eventSourceId = (select [Id] from [ASEventSourcesTable] with (repeatableread)
         where [Name] = @eventSourceName and 
          [Computer] = @computer and
          [Site] = @site and
          [VirtualPath] = @virtualPath);
        
        if (@eventSourceId is null)
        begin
          merge [ASEventSourcesTable] with (serializable) as [target]
            using (values(@eventSourceName, @computer, @site, @virtualPath)) as source([Name], [Computer], [Site], [VirtualPath]) 
            on [target].[Name] = [source].[Name] and 
              [target].[Computer] = [source].[Computer] and
              [target].[Site] = [source].[Site] and
              [target].[VirtualPath] = [source].[VirtualPath]
            when not matched then 
              insert ([Name], [Computer], [Site], [VirtualPath]) values (@eventSourceName, @computer, @site, @virtualPath);       
              
          if (@@rowcount = 0)
          begin
            set @eventSourceId = (select [Id] from [ASEventSourcesTable]
             where [Name] = @eventSourceName and 
              [Computer] = @computer and
              [Site] = @site and
              [VirtualPath] = @virtualPath);
          end;
          else
          begin
            set @eventSourceId = scope_identity();
          end;
        end;        
      end;      
    end                    
    else 
    begin
      -- Format:
      -- Default Web Site/ShoppingCart
      set @eventSourceName = null;
      set @site = substring(@eventSource, 1, @appVirtualPathStartIdx - 1);
      set @virtualPath = substring(@eventSource, @appVirtualPathStartIdx, len(@eventSource) - @appVirtualPathStartIdx + 1);          
      
      set @eventSourceId = (select [Id] from [ASEventSourcesTable] with (repeatableread)
       where [Name] is null and 
        [Computer] = @computer and
        [Site] = @site and
        [VirtualPath] = @virtualPath);

      if (@eventSourceId is null)
      begin      
        merge [ASEventSourcesTable] with (serializable) as [target]
          using (values(@computer, @site, @virtualPath)) as source([Computer], [Site], [VirtualPath]) 
          on [target].[Name] is null and 
            [target].[Computer] = [source].[Computer] and
            [target].[Site] = [source].[Site] and
            [target].[VirtualPath] = [source].[VirtualPath]
          when not matched then 
            insert ([Name], [Computer], [Site], [VirtualPath]) values (null, @computer, @site, @virtualPath);       

        if (@@rowcount = 0)
        begin
          set @eventSourceId = (select [Id] from [ASEventSourcesTable]
           where [Name] is null and 
            [Computer] = @computer and
            [Site] = @site and
            [VirtualPath] = @virtualPath);
        end;
        else
        begin
          set @eventSourceId = scope_identity();
        end;          
      end;
    end;                    
  end;
end;