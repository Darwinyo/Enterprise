CREATE TABLE [dbo].[Tbl_Product_Image] (
    [P_Image_Id]    VARCHAR (36) NOT NULL,
    [Product_Id]    VARCHAR (36) NOT NULL,
    [Product_Image] IMAGE        NOT NULL,
    CONSTRAINT [PK_Tbl_Product_Image] PRIMARY KEY CLUSTERED ([P_Image_Id] ASC),
    CONSTRAINT [FK_Tbl_Product_Image_Tbl_Product] FOREIGN KEY ([Product_Id]) REFERENCES [dbo].[Tbl_Product] ([Product_Id])
);

