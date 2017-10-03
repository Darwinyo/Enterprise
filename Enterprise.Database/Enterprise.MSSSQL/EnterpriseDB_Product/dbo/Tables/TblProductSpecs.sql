CREATE TABLE [dbo].[TblProductSpecs] (
    [PSpecId]          VARCHAR (36)  NOT NULL,
    [ProductId]        VARCHAR (36)  NOT NULL,
    [ProductSpecTitle] VARCHAR (200) NOT NULL,
    [ProductSpecValue] VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Tbl_Product_Specs] PRIMARY KEY CLUSTERED ([PSpecId] ASC),
    CONSTRAINT [FK_Tbl_Product_Specs_Tbl_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[TblProduct] ([ProductId])
);

