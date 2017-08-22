CREATE TABLE [dbo].[Tbl_User] (
    [User_Id]        VARCHAR (36)  NOT NULL,
    [User_FirstName] VARCHAR (200) NULL,
    [User_LastName]  VARCHAR (200) NULL,
    CONSTRAINT [PK_Tbl_User] PRIMARY KEY CLUSTERED ([User_Id] ASC)
);

