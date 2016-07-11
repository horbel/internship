CREATE PROCEDURE convert_to_BYN (@factor FLOAT = 2)
AS
BEGIN
SELECT prod.Name as Product_Name, prod.ListPrice*@factor as BYN_Price
FROM SalesLT.Product prod
END;


EXECUTE convert_to_BYN;
