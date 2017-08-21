CREATE TABLE [dbo].[Tbl_Product_Variations] (
    [Product_Variation_Id]      INT           NOT NULL,
    [Product_Variation]         VARCHAR (MAX) NOT NULL,
    [Product_Variation_InStock] BIT           CONSTRAINT [DF_Product_Variation_InStock] DEFAULT ((0)) NOT NULL,
    [Product_Id]                INT           NOT NULL,
    CONSTRAINT [PK_Product_Variation_Id] PRIMARY KEY CLUSTERED ([Product_Variation_Id] ASC),
    CONSTRAINT [FK_Product_Variation_Id_Product_Id] FOREIGN KEY ([Product_Id]) REFERENCES [dbo].[Tbl_Product] ([Product_Id])
);

