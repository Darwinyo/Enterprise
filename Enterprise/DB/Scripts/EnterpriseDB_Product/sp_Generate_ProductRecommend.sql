USE [EnterpriseDB_Product]
GO
/****** Object:  StoredProcedure [dbo].[sp_Generate_ProductRecommend]    Script Date: 8/29/2017 10:29:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[sp_Generate_ProductRecommend]
@periodeId varchar(36)
as begin
insert into Tbl_Product_Recommended(P_Recommend_Id,Periode_Id,Product_Id)
select top 10 NEWID(),@periodeId,Product_Id from Tbl_Product order by Product_Rating asc
end