CREATE TABLE [dbo].[TblProductVariations] (
    [PVariationId]     VARCHAR (36)  NOT NULL,
    [ProductId]        VARCHAR (36)  NOT NULL,
    [ProductVariation] VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Tbl_Product_Variations] PRIMARY KEY CLUSTERED ([PVariationId] ASC),
    CONSTRAINT [FK_Tbl_Product_Variations_Tbl_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[TblProduct] ([ProductId])
);

