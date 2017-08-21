CREATE TABLE [dbo].[Tbl_Product_Hot] (
    [Product_Id] INT NOT NULL,
    [Periode_Id] INT NOT NULL,
    CONSTRAINT [FK_Product_Id_Hot] FOREIGN KEY ([Product_Id]) REFERENCES [dbo].[Tbl_Product] ([Product_Id])
);

