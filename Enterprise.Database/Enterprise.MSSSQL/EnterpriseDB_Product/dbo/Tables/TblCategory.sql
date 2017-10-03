CREATE TABLE [dbo].[TblCategory] (
    [CategoryId]       VARCHAR (36)  NOT NULL,
    [CategoryName]     VARCHAR (200) NOT NULL,
    [CategoryImageUrl] VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Tbl_Category] PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);

