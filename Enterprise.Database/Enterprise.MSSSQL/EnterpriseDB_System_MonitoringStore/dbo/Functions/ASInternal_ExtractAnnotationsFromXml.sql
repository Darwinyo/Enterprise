create function [ASInternal_ExtractAnnotationsFromXml]
(@propertiesXml xml)
returns table
as
return
(
  select 
    T.p.value('@name', 'nvarchar(128)') as [Name],
    T.p.value('.', 'nvarchar(450)') as [Value]
    from @propertiesXml.nodes('/items/item') T(p)
);