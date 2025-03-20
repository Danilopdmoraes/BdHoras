$(document).ready(function () {
    // Autocomplete
    $("#funcionarioInput").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Gestores/Buscar",
                type: "GET",
                data: { termo: request.term },
                success: function (data) {
                    // Limita o número de sugestões para 10
                    var suggestions = data.slice(0, 7);

                    // Mapeia os dados para o formato esperado pelo autocomplete
                    var mappedData = $.map(suggestions, function (item) {
                        return {
                            label: item.matriculaFuncionario + " - " + item.nomeFuncionario + " - " + item.emailFuncionario,
                            value: item.idFuncionario,
                            matricula: item.matriculaFuncionario,
                            nome: item.nomeFuncionario,
                            email: item.emailFuncionario
                        };
                    });

                    // Se houver mais de 7 resultados, adiciona uma mensagem para continuar digitando
                    if (data.length > 7) {
                        mappedData.push({
                            label: "Continue digitando para ver mais resultados...",
                            value: null,
                            matricula: null,
                            nome: null,
                            email: null
                        });
                    }

                    // Retorna os dados mapeados
                    response(mappedData);
                }
            });
        },
        select: function (event, ui) {
            // Verifica se o item selecionado não é a mensagem de continuar digitando
            if (ui.item.value !== null) {
                $("#funcionarioInput").val(ui.item.matricula + " - " + ui.item.nome + " - " + ui.item.email);
            }
            return false;
        }
    }); // até o 'select: function ()' está testado e funcionando






    // Adicionar funcionário à tabela
    $("#adicionarBtn").click(function () {
        var valores = $("#funcionarioInput").val().split(" - ");
        var matricula = valores[0];
        var nome = valores[1];
        var email = valores[2];

        if (matricula && nome && email) {
            var newRow =
                `<tr>
                    <td>${matricula}</td>
                    <td>${nome}</td>
                    <td>${email}</td>
                    <td><p>saldo aqui<p></td>
                    <td><button type="button" class="btn btn-danger">Remover</button></td>
                </tr>`;
            $("#tabelaSelecionados tbody").append(newRow);
            $("#funcionarioInput").val("");
        }
    });






    // Remover funcionário da tabela
    $("#removerBtn").click(function () {
        $("#tabelaSelecionados tbody tr:last").remove();
    });









    // Gravar selecionados
    $("#gravarBtn").click(function () {
        var selecionados = [];
        $("#tabelaSelecionados tbody tr").each(function () {
            var matricula = $(this).find("td:eq(0)").text();
            var nome = $(this).find("td:eq(1)").text();
            var email = $(this).find("td:eq(2)").text();
            selecionados.push({ MatriculaFuncionario: matricula, NomeFuncionario: nome, EmailFuncionario: email });
        });

        $.ajax({
            url: "/Selecionados/Gravar",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(selecionados),
            success: function () {
                alert("Dados gravados com sucesso!");
            }
        });
    });
});
