// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ajaxGetFn(url, parameters, divbefore, sucessCallback, showloading) {
    $.ajax({
        type: "GET",
        datatype: "json",
        url: url,
        data: parameters,
        beforeSend: function () {
            if (divbefore != "")
                $("#" + divbefore).empty("");
            //if (showloading == undefined || showloading)
            //    alert("Foi!")
        },
        success: sucessCallback,
        error: function () { PaginaErro(); }
    }).always(function () { pageLoadingFrame("hide"); });
}

$('.searchCep').on('click', function (e) {
    var cep = $("#searchCep").val()
    if (validInput(cep)) {
        //alert(cep)
        ajaxGetFn('CEPSearch/GetSearchCep', { cep: cep }, "", function (dados) {
            if (dados) {
                //alert("Sucesso!");
                document.location.reload(true);
            }
            else {
                alert("Deu ruimS!");
            }
        });
    }
    else {
        alert("Campo de CEP inválido.")
    }
})

function validInput(val) {
    return val !== "" && val !== undefined && val !== null && val !== -1 && val !== "-1";
}

function root() {
    return $("#localsite").attr("url")
}
