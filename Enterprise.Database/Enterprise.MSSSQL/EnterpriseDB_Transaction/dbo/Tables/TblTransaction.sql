CREATE TABLE [dbo].[TblTransaction] (
    [TransactionId]       VARCHAR (36)    NOT NULL,
    [UserDetailsId]       VARCHAR (36)    NOT NULL,
    [TypeTransaction]     VARCHAR (100)   NOT NULL,
    [TransactionMethod]   VARCHAR (100)   NOT NULL,
    [TransactionAmount]   DECIMAL (18, 5) NOT NULL,
    [TransactionCurrency] VARCHAR (100)   NOT NULL,
    [TransactionDate]     VARCHAR (100)   CONSTRAINT [DF_Tbl_Transaction_Transaction_Date] DEFAULT (getdate()) NOT NULL,
    [BalanceId]           VARCHAR (36)    NOT NULL,
    [TransactionStatus]   VARCHAR (50)    NOT NULL,
    CONSTRAINT [PK_Tbl_Transaction] PRIMARY KEY CLUSTERED ([TransactionId] ASC),
    CONSTRAINT [FK_Tbl_Transaction_Tbl_Balance] FOREIGN KEY ([BalanceId]) REFERENCES [dbo].[TblBalance] ([BalanceId])
);

