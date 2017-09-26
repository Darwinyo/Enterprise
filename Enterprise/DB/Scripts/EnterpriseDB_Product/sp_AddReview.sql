USE [EnterpriseDB_Product]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddReview]    Script Date: 9/25/2017 1:51:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER proc [dbo].[sp_AddReview]
@productId varchar(36)
as begin
	update TblProduct set ProductReview=ProductReview+1
	where ProductId=@productId
end