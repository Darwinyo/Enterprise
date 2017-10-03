
CREATE proc [dbo].[sp_AddReview]
@productId varchar(36)
as begin
	update TblProduct set ProductReview=ProductReview+1
	where ProductId=@productId
end