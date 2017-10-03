CREATE TABLE [dbo].[Tbl_Product_Category] (
    [P_Category_Id] VARCHAR (36) NOT NULL,
    [Category_Id]   VARCHAR (36) NOT NULL,
    [Product_Id]    VARCHAR (36) NOT NULL,
    CONSTRAINT [PK_Tbl_Product_Category] PRIMARY KEY CLUSTERED ([P_Category_Id] ASC),
    CONSTRAINT [FK_Tbl_Product_Category_Tbl_Category] FOREIGN KEY ([Category_Id]) REFERENCES [dbo].[Tbl_Category] ([Category_Id]),
    CONSTRAINT [FK_Tbl_Product_Category_Tbl_Product] FOREIGN KEY ([Product_Id]) REFERENCES [dbo].[Tbl_Product] ([Product_Id])
);





