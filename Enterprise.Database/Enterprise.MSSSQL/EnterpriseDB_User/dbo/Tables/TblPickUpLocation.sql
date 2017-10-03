CREATE TABLE [dbo].[TblPickUpLocation] (
    [PickUpLocationId] VARCHAR (36)  NOT NULL,
    [UserDetailId]     VARCHAR (36)  NOT NULL,
    [PickUpLocation1]  VARCHAR (500) NOT NULL,
    [PickUpLocation2]  VARCHAR (500) NOT NULL,
    [PickUpLocation3]  VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_Tbl_Pick_Up_Location] PRIMARY KEY CLUSTERED ([PickUpLocationId] ASC),
    CONSTRAINT [FK_Tbl_Pick_Up_Location_Tbl_User_Details] FOREIGN KEY ([UserDetailId]) REFERENCES [dbo].[TblUserDetails] ([UserDetailsId])
);

