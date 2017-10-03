CREATE TABLE [dbo].[Tbl_Balance] (
    [User_Details_Id] VARCHAR (36)    NOT NULL,
    [Balance_Id]      VARCHAR (36)    NOT NULL,
    [Balance]         DECIMAL (18, 5) NOT NULL,
    [Currency]        VARCHAR (200)   NOT NULL,
    CONSTRAINT [PK_Tbl_Balance] PRIMARY KEY CLUSTERED ([Balance_Id] ASC)
);

