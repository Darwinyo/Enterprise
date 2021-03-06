USE [EnterpriseDB_Helper]
GO
/****** Object:  StoredProcedure [dbo].[sp_Generate_Periode]    Script Date: 9/25/2017 1:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[sp_Generate_Periode] 
@periodeId varchar(36),@periodeDescription varchar(200)=NULL,@periodeStartDate date,@periodeEndDate date
as begin
insert into TblPeriode (PeriodeId,PeriodeDescription,PeriodeStartDate,PeriodeEndDate)
values(@periodeId,@periodeDescription,@periodeStartDate,@periodeEndDate)
exec EnterpriseDB_Product.dbo.[sp_Generate_HotProduct] @periodeId
exec EnterpriseDB_Product.[dbo].[sp_Generate_ProductRecommend] @periodeId
end