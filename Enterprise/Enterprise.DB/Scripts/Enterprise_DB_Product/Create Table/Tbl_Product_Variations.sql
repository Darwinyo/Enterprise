USE Enterprise_DB

IF EXISTS(SELECT 1 FROM sys.tables WHERE [name]='Tbl_Product_Variations')
BEGIN
	DROP TABLE Tbl_Product_Variations
END
GO

CREATE TABLE Tbl_Product_Variations
(
Product_Variation_Id INT NOT NULL,
Product_Variation VARCHAR(MAX) NOT NULL,
Product_Variation_InStock BIT NOT NULL CONSTRAINT DF_Product_Variation_InStock DEFAULT 0,
Product_Id INT NOT NULL,
CONSTRAINT PK_Product_Variation_Id PRIMARY KEY (Product_Variation_Id),
CONSTRAINT FK_Product_Variation_Id_Product_Id FOREIGN KEY (Product_Id) REFERENCES Tbl_Product
)