﻿$(function () {
    var casa_selecionada = null;
    var peca_selecionada = null;
    function MontarTabuleiro() {
        var i;
        for (i = 0; i < 10; i++) {
            $("#tabuleiro").append("<div id='linha_" + i.toString() + "' class='linha' >");
            for (j = 0; j < 10; j++) {
                var nome_casa = "casa_" + i.toString() + "_" + j.toString();
                var classe = (i % 2 == 0 ? (j % 2 == 0 ? "casa_branca" : "casa_preta") : (j % 2 != 0 ? "casa_branca" : "casa_preta"));
                $("#linha_" + i.toString()).append("<div id='" + nome_casa + "' class='casa " + classe + "' />");
            }
        }
    }
    MontarTabuleiro();
    $(".casa").click(function () {
        $("#" + casa_selecionada).removeClass("casa_selecionada");
        casa_selecionada = $(this).attr("id");
        $("#" + casa_selecionada).addClass("casa_selecionada");
        $("#info_casa_selecionada").text(casa_selecionada);

        peca_selecionada = $("#" + casa_selecionada).children("img:first").attr("id");
        if (peca_selecionada == null) {
            peca_selecionada = "NENHUMA PECA SELECIONADA";
        }
        $("#info_peca_selecionada").text(peca_selecionada.toString());
    });
});