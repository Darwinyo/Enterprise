CREATE TABLE [dbo].[Tbl_Transaction] (
    [Transaction_Id]       VARCHAR (36)    NOT NULL,
    [User_Details_Id]      VARCHAR (36)    NOT NULL,
    [Type_Transaction]     VARCHAR (100)   NOT NULL,
    [Transaction_Method]   VARCHAR (100)   NOT NULL,
    [Transaction_Amount]   DECIMAL (18, 5) NOT NULL,
    [Transaction_Currency] VARCHAR (100)   NOT NULL,
    [Transaction_Date]     VARCHAR (100)   CONSTRAINT [DF_Tbl_Transaction_Transaction_Date] DEFAULT (getdate()) NOT NULL,
    [Balance_Id]           VARCHAR (36)    NOT NULL,
    [Transaction_Status]   VARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_Tbl_Transaction] PRIMARY KEY CLUSTERED ([Transaction_Id] ASC),
    CONSTRAINT [FK_Tbl_Transaction_Tbl_Balance] FOREIGN KEY ([Balance_Id]) REFERENCES [dbo].[Tbl_Balance] ([Balance_Id])
);

