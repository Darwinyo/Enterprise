CREATE TABLE [dbo].[Tbl_City] (
    [City_Id]    INT           NOT NULL,
    [City_Name]  VARCHAR (MAX) NOT NULL,
    [Country_Id] INT           NOT NULL,
    CONSTRAINT [PK_City_Id] PRIMARY KEY CLUSTERED ([City_Id] ASC),
    CONSTRAINT [FK_City_Id_Country_Id] FOREIGN KEY ([Country_Id]) REFERENCES [dbo].[Tbl_Country] ([Country_Id])
);

