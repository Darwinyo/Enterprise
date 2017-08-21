USE EnterpriseDB_Product

IF EXISTS(SELECT 1 FROM sys.tables WHERE [name]='Tbl_Product_Specs')
BEGIN
	DROP TABLE Tbl_Product_Specs
END
GO

CREATE TABLE Tbl_Product_Specs
(
Product_Id INT NOT NULL,
Product_Spec_Title VARCHAR(MAX) NOT NULL,
Product_Spec_Value VARCHAR(MAX) NOT NULL,
CONSTRAINT FK_Product_Id_Specs FOREIGN KEY (Product_Id) REFERENCES Tbl_Product
)