USE EnterpriseDB_Product

IF EXISTS (SELECT 1 FROM sys.procedures WHERE name='sp_Generate_HotProduct')
BEGIN
DROP PROC sp_Generate_HotProduct
END

GO

CREATE PROC sp_Generate_HotProduct
@periodeId varchar(36)
as begin
insert into Tbl_Product_Hot (P_Hot_Id,Periode_Id,Product_Id)
select top 10 NEWID(),@periodeId,Product_Id from Tbl_Product order by Product_Favorite asc
end