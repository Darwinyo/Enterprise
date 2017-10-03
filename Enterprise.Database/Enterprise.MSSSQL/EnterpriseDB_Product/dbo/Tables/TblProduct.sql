CREATE TABLE [dbo].[TblProduct] (
    [ProductId]          VARCHAR (36)    NOT NULL,
    [ProductFavorite]    INT             NOT NULL,
    [ProductLocation]    INT             NOT NULL,
    [ProductName]        VARCHAR (200)   NOT NULL,
    [ProductPrice]       DECIMAL (18, 2) NOT NULL,
    [ProductRating]      DECIMAL (18, 1) NOT NULL,
    [ProductReview]      INT             NOT NULL,
    [ProductStock]       INT             NOT NULL,
    [ProductDescription] VARCHAR (MAX)   NULL,
    [ProductFrontImage]  VARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Tbl_Product] PRIMARY KEY CLUSTERED ([ProductId] ASC)
);

