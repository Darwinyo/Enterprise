USE EnterpriseDB_Product

IF EXISTS(SELECT 1 FROM sys.tables WHERE [name]='Tbl_Product_Category')
BEGIN
	DROP TABLE Tbl_Product_Category
END
GO

CREATE TABLE Tbl_Product_Category
(
Category_Id INT NOT NULL,
Category_Name VARCHAR NOT NULL,
CONSTRAINT PK_Category_Id PRIMARY KEY (Category_Id)
)