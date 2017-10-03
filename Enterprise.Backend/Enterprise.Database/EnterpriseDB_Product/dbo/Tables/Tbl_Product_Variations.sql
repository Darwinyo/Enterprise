CREATE TABLE [dbo].[Tbl_Product_Variations] (
    [P_Variation_Id]    VARCHAR (36)  NOT NULL,
    [Product_Id]        VARCHAR (36)  NOT NULL,
    [Product_Variation] VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Tbl_Product_Variations] PRIMARY KEY CLUSTERED ([P_Variation_Id] ASC),
    CONSTRAINT [FK_Tbl_Product_Variations_Tbl_Product] FOREIGN KEY ([Product_Id]) REFERENCES [dbo].[Tbl_Product] ([Product_Id])
);








GO


