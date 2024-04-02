/* Modulo ui: Plugin masonry */
webapp.ui.alvenaria = (function ($) {
    //instancia de namespace unica    
    "use strict";

    //membros privados
    //iniciar o modulo (construtor) 
    let inicia = function () {};
    $(inicia);

    function ativa(seletor) {
        //controle
        const $alvenaria = $(seletor);
        // container masonry apos load / ajax
        $alvenaria.masonry(function () {
            // inicializa masonry
            $alvenaria.masonry({
                itemSelector: '.grid-item',
                columnWidth: '.col',
                percentPosition: true
            });
            $alvenaria.masonry('reloadItems');
        });
    };

    return {
        ativa: ativa
    };
})(jQuery);