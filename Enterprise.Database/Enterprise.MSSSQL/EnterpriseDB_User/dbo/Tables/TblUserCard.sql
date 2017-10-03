CREATE TABLE [dbo].[TblUserCard] (
    [UserCardId]    VARCHAR (36)  NOT NULL,
    [CardType]      VARCHAR (50)  NOT NULL,
    [CardProvider]  VARCHAR (100) NOT NULL,
    [CardNumber]    INT           NOT NULL,
    [CardOwner]     VARCHAR (100) NOT NULL,
    [UserDetailsId] VARCHAR (36)  NOT NULL,
    CONSTRAINT [PK_Tbl_User_Card] PRIMARY KEY CLUSTERED ([UserCardId] ASC),
    CONSTRAINT [FK_Tbl_User_Card_Tbl_User_Details] FOREIGN KEY ([UserDetailsId]) REFERENCES [dbo].[TblUserDetails] ([UserDetailsId])
);

