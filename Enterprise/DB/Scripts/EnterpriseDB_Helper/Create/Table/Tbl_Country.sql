USE EnterpriseDB_Helper

IF EXISTS(SELECT 1 FROM sys.tables WHERE [name]='Tbl_Country')
BEGIN
	DROP TABLE Tbl_Country
END
GO

CREATE TABLE Tbl_Country
(
Country_Id INT NOT NULL,
Country_Name VARCHAR(MAX) NOT NULL,
CONSTRAINT PK_Country_Id PRIMARY KEY (Country_Id)
)