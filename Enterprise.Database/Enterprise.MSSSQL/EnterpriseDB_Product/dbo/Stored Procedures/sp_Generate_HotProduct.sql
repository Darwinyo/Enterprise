
CREATE PROC [dbo].[sp_Generate_HotProduct]
@periodeId varchar(36)
as begin
insert into TblProductHot (PHotId,PeriodeId,ProductId)
select top 10 NEWID(),@periodeId,ProductId from TblProduct order by ProductFavorite asc
end