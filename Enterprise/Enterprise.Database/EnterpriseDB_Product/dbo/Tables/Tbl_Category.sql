CREATE TABLE [dbo].[Tbl_Category] (
    [Category_Id]        VARCHAR (36)  NOT NULL,
    [Category_Name]      VARCHAR (200) NOT NULL,
    [Category_Image_Url] VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Tbl_Category] PRIMARY KEY CLUSTERED ([Category_Id] ASC)
);



