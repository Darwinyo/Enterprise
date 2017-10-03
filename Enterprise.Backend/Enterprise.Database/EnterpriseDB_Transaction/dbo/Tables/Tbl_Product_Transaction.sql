CREATE TABLE [dbo].[Tbl_Product_Transaction] (
    [Product_Transaction_Id] VARCHAR (36) NOT NULL,
    [Product_Id]             VARCHAR (36) NOT NULL,
    [Product_Amount]         INT          NOT NULL,
    [Transaction_Id]         VARCHAR (36) NOT NULL,
    CONSTRAINT [PK_Tbl_Product_Transaction] PRIMARY KEY CLUSTERED ([Product_Transaction_Id] ASC),
    CONSTRAINT [FK_Tbl_Product_Transaction_Tbl_Transaction] FOREIGN KEY ([Transaction_Id]) REFERENCES [dbo].[Tbl_Transaction] ([Transaction_Id])
);

