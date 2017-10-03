CREATE TABLE [dbo].[Tbl_User_Card] (
    [User_Card_Id]    VARCHAR (36)  NOT NULL,
    [Card_Type]       VARCHAR (50)  NOT NULL,
    [Card_Provider]   VARCHAR (100) NOT NULL,
    [Card_Number]     INT           NOT NULL,
    [Card_Owner]      VARCHAR (100) NOT NULL,
    [User_Details_Id] VARCHAR (36)  NOT NULL,
    CONSTRAINT [PK_Tbl_User_Card] PRIMARY KEY CLUSTERED ([User_Card_Id] ASC),
    CONSTRAINT [FK_Tbl_User_Card_Tbl_User_Details] FOREIGN KEY ([User_Details_Id]) REFERENCES [dbo].[Tbl_User_Details] ([User_Details_Id])
);

