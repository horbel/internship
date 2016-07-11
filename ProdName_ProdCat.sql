SELECT prod.Name as Product_Name, prodCat.Name as Category_Name
 FROM SalesLT.Product prod INNER JOIN SalesLT.ProductCategory prodCat
 ON prod.ProductCategoryID = prodCat.ProductCategoryID; 