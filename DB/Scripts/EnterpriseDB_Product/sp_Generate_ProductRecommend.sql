USE [EnterpriseDB_Product]
GO
/****** Object:  StoredProcedure [dbo].[sp_Generate_ProductRecommend]    Script Date: 9/25/2017 1:54:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[sp_Generate_ProductRecommend]
@periodeId varchar(36)
as begin
insert into TblProductRecommended(PRecommendId,PeriodeId,ProductId)
select top 10 NEWID(),@periodeId,ProductId from TblProduct order by ProductRating asc
end