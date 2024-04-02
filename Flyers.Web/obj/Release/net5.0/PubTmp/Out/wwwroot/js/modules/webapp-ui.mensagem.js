/* Modulo ui: Plugin toast */
webapp.ui.mensagem = (function ($) {
    //instancia de namespace unica    
    "use strict";

    //membros privados
    let inicia = function () {};
    $(inicia);

    function ativa(tipo, titulo, html) {
        $.toast({
            heading: titulo,
            text: html,
            showHideTransition: 'fade',
            icon: tipo,
            position: 'bottom-center',
            stack: false,
            hideAfter: 1000
        });
    };

    function ativaAtencao(titulo, html) {
        ativa('warning', titulo, html);
    };

    function ativaNegacao(titulo, html) {
        ativa('error', titulo, html);
    };

    function ativaSolucao(titulo, html) {
        ativa('info', titulo, html);
    };

    function ativaQuestao(titulo, html) {
        ativa('question', titulo, html);
    };

    function ativaSucesso(titulo, html) {
        ativa('success', titulo, html);
    };

    //membros publicos
    return {
        atencao: ativaAtencao,
        negacao: ativaNegacao,
        solucao: ativaSolucao,
        questao: ativaQuestao,
        sucesso: ativaSucesso
    };
})(jQuery);