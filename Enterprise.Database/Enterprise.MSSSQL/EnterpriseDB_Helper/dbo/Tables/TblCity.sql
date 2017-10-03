CREATE TABLE [dbo].[TblCity] (
    [CityId]    INT           NOT NULL,
    [CityName]  VARCHAR (MAX) NOT NULL,
    [CountryId] INT           NOT NULL,
    CONSTRAINT [PK_City_Id] PRIMARY KEY CLUSTERED ([CityId] ASC),
    CONSTRAINT [FK_City_Id_Country_Id] FOREIGN KEY ([CountryId]) REFERENCES [dbo].[TblCountry] ([CountryId])
);

