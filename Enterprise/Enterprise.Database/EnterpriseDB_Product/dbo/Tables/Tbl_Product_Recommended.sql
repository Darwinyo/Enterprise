CREATE TABLE [dbo].[Tbl_Product_Recommended] (
    [P_Recommend_Id] VARCHAR (36) NOT NULL,
    [Periode_Id]     VARCHAR (36) NOT NULL,
    [Product_Id]     VARCHAR (36) NOT NULL,
    CONSTRAINT [PK_Tbl_Product_Recommended] PRIMARY KEY CLUSTERED ([P_Recommend_Id] ASC),
    CONSTRAINT [FK_Tbl_Product_Recommended_Tbl_Product] FOREIGN KEY ([Product_Id]) REFERENCES [dbo].[Tbl_Product] ([Product_Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_Tbl_Product_Recommended_Product_Id]
    ON [dbo].[Tbl_Product_Recommended]([Product_Id] ASC);

