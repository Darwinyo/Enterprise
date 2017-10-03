
CREATE PROC sp_Generate_Periode 
@periodeId varchar(36),@periodeDescription varchar(200)=NULL,@periodeStartDate date,@periodeEndDate date
as begin
insert into Tbl_Periode (Periode_Id,Periode_Description,Periode_StartDate,Periode_EndDate)
values(@periodeId,@periodeDescription,@periodeStartDate,@periodeEndDate)
exec EnterpriseDB_Product.dbo.[sp_Generate_HotProduct] @periodeId
exec EnterpriseDB_Product.[dbo].[sp_Generate_ProductRecommend] @periodeId
end