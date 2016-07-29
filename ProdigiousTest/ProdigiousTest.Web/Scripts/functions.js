function validateProduct() {

    var name = $("#Name").val();
    var productNumber = $("#ProductNumber").val();
    var productId = $("#ProductID").val();
    
    $.ajax({
        url: "isValidProduct",
        type: "GET",
        data: { name: name, productNumber: productNumber, productId: productId },
        cache: false,
        async: false,
        success: function (result) {
            alert("Product name and product number already exist");
            if (result === false) {
                return false;
            }
                
            return true;
        }
    });
}