$(document).ready(function () {
    $("#salvar").click(function () {
        $.ajax({
            type: "POST",
            url: "/Produtos/Salvar",
            data: {
                "descricao": $("#descricao").val(),
                "valor": $("#valor").val()
            },
            success: function () {
                alert("Foi Inserido com sucesso !!")
                window.location = "/Produtos/Index";
            }
        })
    });
});