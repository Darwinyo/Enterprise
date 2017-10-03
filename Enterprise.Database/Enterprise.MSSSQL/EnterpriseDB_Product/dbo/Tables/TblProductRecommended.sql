CREATE TABLE [dbo].[TblProductRecommended] (
    [PRecommendId] VARCHAR (36) NOT NULL,
    [PeriodeId]    VARCHAR (36) NOT NULL,
    [ProductId]    VARCHAR (36) NOT NULL,
    CONSTRAINT [PK_Tbl_Product_Recommended] PRIMARY KEY CLUSTERED ([PRecommendId] ASC),
    CONSTRAINT [FK_Tbl_Product_Recommended_Tbl_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[TblProduct] ([ProductId])
);

