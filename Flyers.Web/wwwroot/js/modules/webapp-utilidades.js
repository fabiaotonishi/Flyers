/* Modulo ui: Funcoes gerais */
webapp.utilidades = (function ($) {
    //instancia de namespace unica    
    "use strict";

    //membros privados
    //iniciar o modulo (construtor) 
    let inicia = function () {};
    $(inicia);

    //id unico
    const uuid = function () {
        /* jshint bitwise:false */
        let i, random;
        let uuid = '';

        for (i = 0; i < 32; i++) {
            random = Math.random() * 16 | 0;
            if (i === 8 || i === 12 || i === 16 || i === 20) {
                uuid += '-';
            }
            uuid += (i === 12 ? 4 : (i === 16 ? (random & 3 | 8) : random)).toString(16);
        }
        return uuid;
    };

    //funcao para verificacao de url expressao regular
    function checaUrl(url) {
        if (url && url.match(/^http([s]?):\/\/.*/)) {
            return true;
        }
        return false;
    };

    //membros publicos
    return {
        uuid: uuid,
        checaUrl: checaUrl,
    };
})(jQuery);