CREATE TABLE [dbo].[Tbl_Product] (
    [Product_Id]       INT           NOT NULL,
    [Product_Name]     VARCHAR (MAX) NOT NULL,
    [Product_Price]    DECIMAL (18)  NOT NULL,
    [Product_Rating]   DECIMAL (18)  CONSTRAINT [DF_Product_Rating] DEFAULT ((0)) NOT NULL,
    [Product_Review]   INT           CONSTRAINT [DF_Product_Review] DEFAULT ((0)) NOT NULL,
    [Product_Location] INT           NOT NULL,
    [Product_Stock]    INT           NOT NULL,
    [Product_Favorite] INT           NOT NULL,
    CONSTRAINT [PK_Product_Id] PRIMARY KEY CLUSTERED ([Product_Id] ASC)
);

