CREATE TABLE [dbo].[Tbl_User_Details] (
    [User_Details_Id]   VARCHAR (36)  NOT NULL,
    [First_Name]        VARCHAR (200) NULL,
    [Middle_Name]       VARCHAR (200) NULL,
    [Last_Name]         VARCHAR (200) NULL,
    [Email_Main]        VARCHAR (200) NULL,
    [Email_Secondary]   VARCHAR (200) NULL,
    [Phone_Main]        INT           NULL,
    [Phone_Secondary]   INT           NULL,
    [Address_Main]      VARCHAR (200) NULL,
    [Address_Secondary] VARCHAR (200) NULL,
    [Address_Third]     VARCHAR (200) NULL,
    CONSTRAINT [PK_Tbl_User_Details] PRIMARY KEY CLUSTERED ([User_Details_Id] ASC)
);

