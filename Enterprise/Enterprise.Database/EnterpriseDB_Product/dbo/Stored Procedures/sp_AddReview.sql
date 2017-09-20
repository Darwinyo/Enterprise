
create proc sp_AddReview
@productId varchar(36)
as begin
	update Tbl_Product set Product_Review=Product_Review+1
	where Product_Id=@productId
end