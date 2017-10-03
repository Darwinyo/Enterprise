CREATE TABLE [dbo].[TblProductImage] (
    [PImageId]         VARCHAR (36)  NOT NULL,
    [ProductId]        VARCHAR (36)  NOT NULL,
    [ProductImageUrl]  VARCHAR (MAX) NOT NULL,
    [ProductImageName] VARCHAR (200) NOT NULL,
    [ProductImageSize] INT           NOT NULL,
    CONSTRAINT [PK_Tbl_Product_Image] PRIMARY KEY CLUSTERED ([PImageId] ASC),
    CONSTRAINT [FK_Tbl_Product_Image_Tbl_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[TblProduct] ([ProductId])
);

