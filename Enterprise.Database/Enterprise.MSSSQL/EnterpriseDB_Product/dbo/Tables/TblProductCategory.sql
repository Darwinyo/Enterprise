CREATE TABLE [dbo].[TblProductCategory] (
    [PCategoryId] VARCHAR (36) NOT NULL,
    [CategoryId]  VARCHAR (36) NOT NULL,
    [ProductId]   VARCHAR (36) NOT NULL,
    CONSTRAINT [PK_Tbl_Product_Category] PRIMARY KEY CLUSTERED ([PCategoryId] ASC),
    CONSTRAINT [FK_Tbl_Product_Category_Tbl_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[TblCategory] ([CategoryId]),
    CONSTRAINT [FK_Tbl_Product_Category_Tbl_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[TblProduct] ([ProductId])
);

