CREATE TABLE [dbo].[Tbl_Product] (
    [Product_Id]       VARCHAR (36)  NOT NULL,
    [Product_Name]     VARCHAR (200) NOT NULL,
    [Product_Price]    DECIMAL (18)  NOT NULL,
    [Product_Rating]   DECIMAL (18)  NOT NULL,
    [Product_Review]   VARCHAR (36)  NOT NULL,
    [Product_Location] INT           NOT NULL,
    [Product_Stock]    INT           NULL,
    [Product_Favorite] INT           NULL,
    CONSTRAINT [PK_Tbl_Product] PRIMARY KEY CLUSTERED ([Product_Id] ASC)
);



