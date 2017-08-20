USE Enterprise_DB

IF EXISTS(SELECT 1 FROM sys.tables WHERE [name]='Tbl_Product')
BEGIN
	DROP TABLE Tbl_Product
END
GO

CREATE TABLE Tbl_Product
(
Product_Id INT NOT NULL,
Product_Name VARCHAR(MAX) NOT NULL,
Product_Price DECIMAL NOT NULL,
Product_Rating DECIMAL NOT NULL CONSTRAINT DF_Product_Rating DEFAULT 0,
Product_Review INT NOT NULL CONSTRAINT DF_Product_Review DEFAULT 0,
Product_Location INT NOT NULL,
Product_Stock INT NOT NULL,
Product_Favorite INT NOT NULL,
CONSTRAINT PK_Product_Id PRIMARY KEY (Product_Id),
CONSTRAINT FK_Product_Location FOREIGN KEY(Product_Location) REFERENCES Tbl_City
)