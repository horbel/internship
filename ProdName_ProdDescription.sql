SELECT prod.Name, descr.Description 
 FROM SalesLT.Product prod, SalesLT.ProductModelProductDescription modDescr, SalesLT.ProductDescription descr
 WHERE prod.ProductModelID = modDescr.ProductModelID AND
 modDescr.ProductDescriptionID = descr.ProductDescriptionID;