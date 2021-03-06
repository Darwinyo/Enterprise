USE [EnterpriseDB_Product]
GO
/****** Object:  StoredProcedure [dbo].[sp_Generate_HotProduct]    Script Date: 9/25/2017 1:53:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[sp_Generate_HotProduct]
@periodeId varchar(36)
as begin
insert into TblProductHot (PHotId,PeriodeId,ProductId)
select top 10 NEWID(),@periodeId,ProductId from TblProduct order by ProductFavorite asc
end