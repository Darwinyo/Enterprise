CREATE TABLE [dbo].[Tbl_Profile_Image] (
    [Profile_Image_Id]   VARCHAR (36)  NOT NULL,
    [User_Detail_Id]     VARCHAR (36)  NOT NULL,
    [Profile_Image_Url]  VARCHAR (MAX) NOT NULL,
    [Profile_Image_Name] VARCHAR (200) NOT NULL,
    [Profile_Image_Size] INT           NOT NULL,
    CONSTRAINT [PK_Tbl_Profile_Image] PRIMARY KEY CLUSTERED ([Profile_Image_Id] ASC),
    CONSTRAINT [FK_Tbl_Profile_Image_Tbl_User_Details] FOREIGN KEY ([User_Detail_Id]) REFERENCES [dbo].[Tbl_User_Details] ([User_Details_Id])
);

