/* Modulo ui: Plugin blockUI */
webapp.ui.bloqueio = (function ($) {
    //instancia de namespace unica    
    "use strict";

    //membros privados
    //iniciar o modulo (construtor) 
    let inicia = function () {
        $.blockUI.defaults.message = $('#carregando');
        $.blockUI.defaults.css.border = 'none';
        $.blockUI.defaults.css.backgroundColor = 'none';
    };
    $(inicia);

    function ativa(ativo) {
        if (ativo === true) {
            return $.blockUI();
        } else {
            return $.unblockUI();
        }       
    };

    //membros publicos
    return {
        ativa: ativa
    };
})(jQuery);