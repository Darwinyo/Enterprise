CREATE TABLE [dbo].[TblProductTransaction] (
    [ProductTransactionId] VARCHAR (36) NOT NULL,
    [ProductId]            VARCHAR (36) NOT NULL,
    [ProductAmount]        INT          NOT NULL,
    [TransactionId]        VARCHAR (36) NOT NULL,
    CONSTRAINT [PK_Tbl_Product_Transaction] PRIMARY KEY CLUSTERED ([ProductTransactionId] ASC),
    CONSTRAINT [FK_Tbl_Product_Transaction_Tbl_Transaction] FOREIGN KEY ([TransactionId]) REFERENCES [dbo].[TblTransaction] ([TransactionId])
);

