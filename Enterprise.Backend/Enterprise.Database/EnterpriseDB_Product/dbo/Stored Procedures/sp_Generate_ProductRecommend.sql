
CREATE PROC [dbo].[sp_Generate_ProductRecommend]
@periodeId varchar(36)
as begin
insert into Tbl_Product_Recommended(P_Recommend_Id,Periode_Id,Product_Id)
select top 10 NEWID(),@periodeId,Product_Id from Tbl_Product order by Product_Rating asc
end