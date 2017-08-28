CREATE TABLE [dbo].[Tbl_Product_Hot] (
    [P_Hot_Id]   VARCHAR (36) NOT NULL,
    [Periode_Id] VARCHAR (36) NOT NULL,
    [Product_Id] VARCHAR (36) NOT NULL,
    CONSTRAINT [PK_Tbl_Product_Hot] PRIMARY KEY CLUSTERED ([P_Hot_Id] ASC),
    CONSTRAINT [FK_Tbl_Product_Hot_Tbl_Product] FOREIGN KEY ([Product_Id]) REFERENCES [dbo].[Tbl_Product] ([Product_Id])
);






GO
CREATE NONCLUSTERED INDEX [IX_Tbl_Product_Hot_Product_Id]
    ON [dbo].[Tbl_Product_Hot]([Product_Id] ASC);

