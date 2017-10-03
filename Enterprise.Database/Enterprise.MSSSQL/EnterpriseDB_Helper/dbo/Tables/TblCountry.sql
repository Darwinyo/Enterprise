CREATE TABLE [dbo].[TblCountry] (
    [CountryId]   INT           NOT NULL,
    [CountryName] VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Country_Id] PRIMARY KEY CLUSTERED ([CountryId] ASC)
);

