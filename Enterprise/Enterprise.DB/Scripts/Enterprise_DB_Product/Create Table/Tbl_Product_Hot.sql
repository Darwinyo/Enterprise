USE Enterprise_DB

IF EXISTS(SELECT 1 FROM sys.tables WHERE [name]='Tbl_Product_Hot')
BEGIN
	DROP TABLE Tbl_Product_Hot
END
GO

CREATE TABLE Tbl_Product_Hot
(
Product_Id INT NOT NULL,
Periode_Id INT NOT NULL,
CONSTRAINT FK_Product_Id_Hot FOREIGN KEY (Product_Id) REFERENCES Tbl_Product
)