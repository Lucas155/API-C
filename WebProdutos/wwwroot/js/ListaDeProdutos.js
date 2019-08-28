
$.ajax({
    url: "https://localhost:44335/api/values",
    type: 'GET',
    dataType: "json",
    success: function (data) {
        console.log(data);

        var ListaDeProdutos = document.getElementById("produto");

        data.forEach(obj => {
            console.log(obj);
            ListaDeProdutos.innerHTML += `<li>${obj.produto}</li>`

        });
    },
});