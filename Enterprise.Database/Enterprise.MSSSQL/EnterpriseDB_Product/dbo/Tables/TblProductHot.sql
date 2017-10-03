CREATE TABLE [dbo].[TblProductHot] (
    [PHotId]    VARCHAR (36) NOT NULL,
    [PeriodeId] VARCHAR (36) NOT NULL,
    [ProductId] VARCHAR (36) NOT NULL,
    CONSTRAINT [PK_Tbl_Product_Hot] PRIMARY KEY CLUSTERED ([PHotId] ASC),
    CONSTRAINT [FK_Tbl_Product_Hot_Tbl_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[TblProduct] ([ProductId])
);

