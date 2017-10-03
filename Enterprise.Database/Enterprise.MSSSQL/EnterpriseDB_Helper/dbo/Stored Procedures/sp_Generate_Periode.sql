
CREATE PROC [dbo].[sp_Generate_Periode] 
@periodeId varchar(36),@periodeDescription varchar(200)=NULL,@periodeStartDate date,@periodeEndDate date
as begin
insert into TblPeriode (PeriodeId,PeriodeDescription,PeriodeStartDate,PeriodeEndDate)
values(@periodeId,@periodeDescription,@periodeStartDate,@periodeEndDate)
exec EnterpriseDB_Product.dbo.[sp_Generate_HotProduct] @periodeId
exec EnterpriseDB_Product.[dbo].[sp_Generate_ProductRecommend] @periodeId
end