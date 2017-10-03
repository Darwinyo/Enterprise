CREATE TABLE [dbo].[Tbl_User_Login] (
    [User_Login_Id]  VARCHAR (36)  NOT NULL,
    [User_Login]     VARCHAR (200) NOT NULL,
    [Email]          VARCHAR (200) NOT NULL,
    [Phone_Number]   INT           NOT NULL,
    [Password]       VARCHAR (200) NOT NULL,
    [User_Detail_Id] VARCHAR (36)  NOT NULL,
    CONSTRAINT [PK_Tbl_User_Login] PRIMARY KEY CLUSTERED ([User_Login_Id] ASC),
    CONSTRAINT [FK_Tbl_User_Login_Tbl_User_Details] FOREIGN KEY ([User_Detail_Id]) REFERENCES [dbo].[Tbl_User_Details] ([User_Details_Id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tbl_User_Login_Phone_Number]
    ON [dbo].[Tbl_User_Login]([Phone_Number] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tbl_User_Login_Email]
    ON [dbo].[Tbl_User_Login]([Email] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tbl_User_Login]
    ON [dbo].[Tbl_User_Login]([User_Login] ASC);

