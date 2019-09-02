
function DeleteProduto() {

        $.ajax({
            url: 'https://localhost:44372/api/values' + arguments[0], // url
            type: 'DELETE', // request type
            success: function (msg) {
                alert(msg); // if the request be succesifully 
            },
            error: function (xhr, textStatus, errorThrown) {
                alert("error: \n" + xhr.catch); // if the request return error
            }
        });

}