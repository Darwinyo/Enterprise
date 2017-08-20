USE Enterprise_DB

IF EXISTS(SELECT 1 FROM sys.tables WHERE [name]='Tbl_Product_Recommended')
BEGIN
	DROP TABLE Tbl_Product_Category
END
GO

CREATE TABLE Tbl_Product_Category
(
Product_Id INT NOT NULL,
Periode_Id INT NOT NULL,
CONSTRAINT FK_Product_Id FOREIGN KEY (Product_Id) REFERENCES Tbl_Product
)