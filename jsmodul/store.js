var store = (function () {

    var _counterID = 0;

    //class
     function Product(nameParam) {
        var ID = _counterID;
        this.name = nameParam;
        var price = 0;
        this.getSetPrice = function (priceParam) {
            if (!arguments.length)
                return price;
            else {
                if (price < 0 || price == NaN) {
                    throw new Error("Price cant be less then 0 or NaN");
                }
                else {
                    price = priceParam
                }
            }
        }
        this.getID = function(){
            return ID;
        }
    }
    //array
    var _products = [];
   
     //interface
     
    function addProduct() {
        var name = $("#name").val();
        var price = $("#price").val();
        var prod = new Product(name);
        prod.getSetPrice(price);
        _products.push(prod);
        showProducts();
        _counterID++;
    }
   
    function showProducts() {
        var str = "<table><thead><tr><th>№</th><th>Name</th><th>Price</th><th>Action</th></tr></thead><tbody>";
        for (var i = 0; i < _products.length; i++) {
            str += "<tr><td>"+(i+1)+"</td><td>" + _products[i].name + "</td><td>" +
                _products[i].getSetPrice() + "</td><td><button id ='"+_products[i].getID()+"'class ='deleteBtn'>Delete</button></td></tr>";
        }
        str += "</tbody></table>";
        $("#results").html(str);
    }
    function deleteProduct(id) {
        var isExist = false;
        
        for(var i=0; i<_products.length; i++){
            if (_products[i].getID() == id) {                
                isExist = true;
                break;
            }
        }
        if (isExist) {
            _products.splice(i, 1);
            alert("product deleted");
            showProducts();
        }
        else {
            throw new Error("product does not exist in the store");
        }
    }

    function sortByPrice() {
        function comparePrice(prodA, prodB) {
            return prodA.getSetPrice() - prodB.getSetPrice();
        }
        _products.sort(comparePrice);
        showProducts();
    }
    function sortByName() {
        function compareName(prodA, prodB) {
            if (prodA.name.toLowerCase() > prodB.name.toLowerCase() )
                return 1;
            else
                return -1;
        }
        _products.sort(compareName);
        showProducts();
    }

    return {     
        addProduct: addProduct,
        showProducts: showProducts,
        deleteProduct: deleteProduct,
        sortByPrice: sortByPrice,
        sortByName: sortByName
    }
    
 }());

 $("#submit").click(function () { store.addProduct() });
 //$("#show").click(function () { store.showProducts() }); 
 $("#results").on("click", ".deleteBtn", function () { store.deleteProduct(parseInt($(this).attr("id"))) });
 $("#sortByPrice").click(function () { store.sortByPrice() });
 $("#sortByName").click(function () { store.sortByName() });

 