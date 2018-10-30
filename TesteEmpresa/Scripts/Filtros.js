$(document).ready(function () {
    var id = "";
    var descricao = "";
    var quantidade = "";
    var valor = "";

    $(function () {
        $("#tabela input").keyup(function () {
            var index = $(this).parent().index();
            var nth = "#tabela td:nth-child(" + (index + 1).toString() + ")";
            var valor = $(this).val().toUpperCase();
            $("#tabela tbody tr").show();
            $(nth).each(function () {
                if ($(this).text().toUpperCase().indexOf(valor) < 0) {
                    $(this).parent().hide();
                }
            });
        });
        $("#tabela input").blur(function () {
            $(this).val("");
        });
    });
    $("#edit").click(function () {
        $.ajax({
            url: "/Produto/EditarProduto/?id =" + id + "",
            sucess: function (data) {
                $.each(data, function (i, element) {
                    id = elemnt.Id,
                    descricao = element.Descricao,
                    quantidade = element.Quantidade,
                    valor = element.Valor


                })
            },

        });

    });
});