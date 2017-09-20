CREATE TABLE [dbo].[Tbl_Product] (
    [Product_Id]          VARCHAR (36)    NOT NULL,
    [Product_Favorite]    INT             NOT NULL,
    [Product_Location]    INT             NOT NULL,
    [Product_Name]        VARCHAR (200)   NOT NULL,
    [Product_Price]       DECIMAL (18, 2) NOT NULL,
    [Product_Rating]      DECIMAL (18, 1) NOT NULL,
    [Product_Review]      INT             NOT NULL,
    [Product_Stock]       INT             NOT NULL,
    [Product_Description] VARCHAR (MAX)   NULL,
    [Product_Front_Image] VARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Tbl_Product] PRIMARY KEY CLUSTERED ([Product_Id] ASC)
);







