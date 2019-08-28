
    $('#dadosForm').on('submit', function () {
        var form = this;
        console.log(form);

    
    //var dados = document.getElementById('#dadosForm');
    //console.log(dados);

    $.ajax({
        url: "https://localhost:44335/api/values",
        type: 'POST',
        dataType: "json",
        data: $(form).serialize(),
        success: function (resposta) {
            console.log(resposta);
        },

        error: function (error) {
           // Console.log("Ocorreu algun problema");
        }
    });

    alert("executo");

        
    });


/*
 
 var CPF = document.getElementById('cpf');
    var NOME = document.getElementById('nome');
    var TELEFONE = document.getElementById('telefone');
    var DATANASC = document.getElementById('dataNasc');
    var SEXO = document.getElementById('sexo');

    $.ajax({
      url: 'https://localhost:44349/api/Clients',
      dataType: 'json',
      type: 'post',
      contentType: 'application/json',
      data: JSON.stringify({ "cpf": CPF.value, "nome": NOME.value, "telefone": TELEFONE.value, "dataNasc": DATANASC.value, "sexo": SEXO.value, "atividade": 1 }),
      processData: false,
      success: function (msg) {
        //alert(msg); // if the request be succesifully
      },
      error: function (xhr, textStatus, errorThrown) {
        //alert("error: \n" + xhr.catch); // if the request return error
      }
    });
meu código inteiro ta assim se quiser tentar
 
 */