CREATE TABLE [dbo].[TblBalance] (
    [UserDetailsId] VARCHAR (36)    NOT NULL,
    [BalanceId]     VARCHAR (36)    NOT NULL,
    [Balance]       DECIMAL (18, 5) NOT NULL,
    [Currency]      VARCHAR (200)   NOT NULL,
    CONSTRAINT [PK_Tbl_Balance] PRIMARY KEY CLUSTERED ([BalanceId] ASC)
);

