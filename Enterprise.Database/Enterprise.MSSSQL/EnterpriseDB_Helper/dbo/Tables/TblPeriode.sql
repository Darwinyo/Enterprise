CREATE TABLE [dbo].[TblPeriode] (
    [PeriodeId]          VARCHAR (36)  NOT NULL,
    [PeriodeDescription] VARCHAR (200) NOT NULL,
    [PeriodeStartDate]   DATE          NOT NULL,
    [PeriodeEndDate]     DATE          NOT NULL,
    CONSTRAINT [PK_Tbl_Periode] PRIMARY KEY CLUSTERED ([PeriodeId] ASC)
);

