CREATE TABLE [dbo].[Tbl_Product_Specs] (
    [P_Spec_Id]          VARCHAR (36)  NOT NULL,
    [Product_Id]         VARCHAR (36)  NOT NULL,
    [Product_Spec_Title] VARCHAR (200) NOT NULL,
    [Product_Spec_Value] VARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Tbl_Product_Specs] PRIMARY KEY CLUSTERED ([P_Spec_Id] ASC),
    CONSTRAINT [FK_Tbl_Product_Specs_Tbl_Product] FOREIGN KEY ([Product_Id]) REFERENCES [dbo].[Tbl_Product] ([Product_Id])
);



