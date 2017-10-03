CREATE TABLE [dbo].[Tbl_Periode] (
    [Periode_Id]          VARCHAR (36)  NOT NULL,
    [Periode_Description] VARCHAR (200) NOT NULL,
    [Periode_StartDate]   DATE          NOT NULL,
    [Periode_EndDate]     DATE          NOT NULL,
    CONSTRAINT [PK_Tbl_Periode] PRIMARY KEY CLUSTERED ([Periode_Id] ASC)
);

