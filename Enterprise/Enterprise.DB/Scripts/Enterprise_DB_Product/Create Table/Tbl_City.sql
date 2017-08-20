USE Enterprise_DB

IF EXISTS(SELECT 1 FROM sys.tables WHERE [name]='Tbl_City')
BEGIN
	DROP TABLE Tbl_City
END
GO

CREATE TABLE Tbl_City
(
City_Id INT NOT NULL,
City_Name VARCHAR(MAX) NOT NULL,
Country_Id INT NOT NULL,
CONSTRAINT PK_City_Id PRIMARY KEY (City_Id),
CONSTRAINT FK_City_Id_Country_Id FOREIGN KEY (Country_Id) REFERENCES Tbl_Country
)