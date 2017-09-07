if exists(select 1 from sys.procedures where [name]='sp_AddReview')
begin
	drop proc sp_AddReview
end
go

create proc sp_AddReview
@productId varchar(36)
as begin
	update Tbl_Product set Product_Review=Product_Review+1
	where Product_Id=@productId
end