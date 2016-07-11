SELECT prod.Name, prod.Size, prod.Color, prod.ListPrice, cat.Name
FROM SalesLT.Product prod 
JOIN SalesLT.ProductCategory cat
ON cat.ProductCategoryID = prod.ProductCategoryID
WHERE prod.ListPrice>500
AND NOT prod.Color='NULL';

