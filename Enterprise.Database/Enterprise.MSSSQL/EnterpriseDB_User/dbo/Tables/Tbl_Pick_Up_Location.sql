CREATE TABLE [dbo].[Tbl_Pick_Up_Location] (
    [Pick_Up_Location_Id] VARCHAR (36)  NOT NULL,
    [User_Detail_Id]      VARCHAR (36)  NOT NULL,
    [Pick_Up_Location_1]  VARCHAR (500) NOT NULL,
    [Pick_Up_Location_2]  VARCHAR (500) NOT NULL,
    [Pick_Up_Location_3]  VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_Tbl_Pick_Up_Location] PRIMARY KEY CLUSTERED ([Pick_Up_Location_Id] ASC),
    CONSTRAINT [FK_Tbl_Pick_Up_Location_Tbl_User_Details] FOREIGN KEY ([User_Detail_Id]) REFERENCES [dbo].[Tbl_User_Details] ([User_Details_Id])
);

