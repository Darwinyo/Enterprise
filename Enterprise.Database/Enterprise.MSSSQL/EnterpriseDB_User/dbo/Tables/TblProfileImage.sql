CREATE TABLE [dbo].[TblProfileImage] (
    [ProfileImageId]   VARCHAR (36)  NOT NULL,
    [UserDetailId]     VARCHAR (36)  NOT NULL,
    [ProfileImageUrl]  VARCHAR (MAX) NOT NULL,
    [ProfileImageName] VARCHAR (200) NOT NULL,
    [ProfileImageSize] INT           NOT NULL,
    CONSTRAINT [PK_Tbl_Profile_Image] PRIMARY KEY CLUSTERED ([ProfileImageId] ASC),
    CONSTRAINT [FK_Tbl_Profile_Image_Tbl_User_Details] FOREIGN KEY ([UserDetailId]) REFERENCES [dbo].[TblUserDetails] ([UserDetailsId])
);

