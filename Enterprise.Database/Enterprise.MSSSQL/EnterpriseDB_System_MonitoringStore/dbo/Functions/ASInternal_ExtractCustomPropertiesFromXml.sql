create function [ASInternal_ExtractCustomPropertiesFromXml]
(@propertiesXml xml)
returns table
as
return
(
  select 
    T.p.value('@name', 'nvarchar(128)') as [Name],
    T.p.value('@type', 'nvarchar(128)') as [Type],
    case T.p.value('@type', 'nvarchar(128)')
      when N'System.Char' then cast(T.p.value('.', 'nvarchar(318)') as sql_variant)
      when N'System.DateTime' then cast(T.p.value('.', 'datetime2') as sql_variant)
      when N'System.DateTimeOffset' then cast(T.p.value('.', 'datetimeoffset') as sql_variant)
      when N'System.Guid' then cast(T.p.value('.', 'uniqueidentifier') as sql_variant)
      when N'System.Int16' then cast(T.p.value('.', 'smallint') as sql_variant)
      when N'System.Int32' then cast(T.p.value('.', 'int') as sql_variant)
      when N'System.Int64' then cast(T.p.value('.', 'bigint') as sql_variant)
      when N'System.UInt16' then cast(T.p.value('.', 'smallint') as sql_variant)
      when N'System.UInt32' then cast(T.p.value('.', 'int') as sql_variant)
      when N'System.UInt64' then cast(T.p.value('.', 'bigint') as sql_variant)
      when N'System.Single' then cast(T.p.value('.', 'float') as sql_variant)
      when N'System.Double' then cast(T.p.value('.', 'float') as sql_variant)
      when N'System.String' then cast(T.p.value('.', 'nvarchar(318)') as sql_variant)
      when N'System.Boolean' then cast(T.p.value('.', 'bit') as sql_variant)
      else null
    end as [Value],
    case T.p.value('@type', 'nvarchar(128)')
      when N'System.Char' then null
      when N'System.DateTime' then null
      when N'System.DateTimeOffset' then null
      when N'System.Guid' then null
      when N'System.Int16' then null
      when N'System.Int32' then null
      when N'System.Int64' then null
      when N'System.UInt16' then null
      when N'System.UInt32' then null
      when N'System.UInt64' then null
      when N'System.Single' then null
      when N'System.Double' then null
      when N'System.String' then null
      when N'System.Boolean' then null
      else cast(T.p.query('./*') as nvarchar(max))
    end as [ValueBlob]
    from @propertiesXml.nodes('/items/item') T(p)
);