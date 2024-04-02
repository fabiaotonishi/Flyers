/* Modulo formulario: Requisicoes ajax */
webapp.formulario = (function ($) {
    //instancia de namespace unica    
    "use strict";

    //membros privados
    //iniciar o modulo (construtor) 
    let inicia = function () {};
    $(inicia);

    //funcao para requisicoes de partils com formularios
    function envia(form) {
        const $form = $(form);
        const action = $form.attr("action");
        const method = $form.attr("method");
        const modelo = new FormData(form);
        try {
            return $.ajax({
                url: action,
                type: method,
                data: modelo,
                contentType: false,
                cache: false,
                processData: false,
                beforeSend: function () {
                    $form.find('button').attr("disabled", true);
                    webapp.ui.bloqueio.ativa(true);
                },
                error: function (erro) {
                    if (erro.status == 404) {
                        webapp.ui.mensagem.atencao("Atenção", "Nenhum registro encontrado");
                    }
                    else {
                        if (erro.responseText == null) {
                            webapp.ui.mensagem.negacao("Erro", "Operação inválida");
                        }
                        webapp.ui.mensagem.negacao("Erro", erro.responseText);
                    }
                },
                complete: function () {
                    $form.find('button').removeAttr("disabled");
                    webapp.ui.bloqueio.ativa(false);
                }
            });
        } catch (erro) {
            console.log(erro);
        }
    };

     //membros publicos
    return {
        envia: envia
    };
})(jQuery);