
CREATE PROC [dbo].[sp_Generate_ProductRecommend]
@periodeId varchar(36)
as begin
insert into TblProductRecommended(PRecommendId,PeriodeId,ProductId)
select top 10 NEWID(),@periodeId,ProductId from TblProduct order by ProductRating asc
end