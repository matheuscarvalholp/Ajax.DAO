$(document).ready(function () { /*QUANDO ELE ABRIR MEU ARQUIVO VAI LER TODO MEU CÓDIGO*/
    $("#salvar").click(function () {
        if ($("#descricao").val() === "" || $("#quantidade").val() === "" || $("#valor").val() === "") {
            alert("Digite algo !! ");
        } else {
            $.ajax({
                type: "POST",
                url: "/Produto/CadastrarProduto",
                data: {
                    "descricao": $("#descricao").val(),
                    "quantidade": $("#quantidade").val(),
                    "valor": $("#valor").val()

                },
                success:
                    function () {
                        alert("Salvo com sucesso");
                        window.location = "/Produto/Index"
                    }

            });
        }
    });
});