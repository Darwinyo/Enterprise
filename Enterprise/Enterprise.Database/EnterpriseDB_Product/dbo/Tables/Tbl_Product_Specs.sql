CREATE TABLE [dbo].[Tbl_Product_Specs] (
    [Product_Id]         INT           NOT NULL,
    [Product_Spec_Title] VARCHAR (MAX) NOT NULL,
    [Product_Spec_Value] VARCHAR (MAX) NOT NULL,
    CONSTRAINT [FK_Product_Id_Specs] FOREIGN KEY ([Product_Id]) REFERENCES [dbo].[Tbl_Product] ([Product_Id])
);

