CREATE TABLE [dbo].[TblUserLogin] (
    [UserLoginId]  VARCHAR (36)  NOT NULL,
    [UserLogin]    VARCHAR (200) NOT NULL,
    [Email]        VARCHAR (200) NOT NULL,
    [PhoneNumber]  VARCHAR (15)  NOT NULL,
    [Password]     VARCHAR (200) NOT NULL,
    [UserDetailId] VARCHAR (36)  NOT NULL,
    CONSTRAINT [PK_Tbl_User_Login] PRIMARY KEY CLUSTERED ([UserLoginId] ASC),
    CONSTRAINT [FK_Tbl_User_Login_Tbl_User_Details] FOREIGN KEY ([UserDetailId]) REFERENCES [dbo].[TblUserDetails] ([UserDetailsId])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tbl_User_Login_Phone_Number]
    ON [dbo].[TblUserLogin]([PhoneNumber] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tbl_User_Login_Email]
    ON [dbo].[TblUserLogin]([Email] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Tbl_User_Login]
    ON [dbo].[TblUserLogin]([UserLogin] ASC);

