/* Modulo ui: Plugin owlCarousel */
webapp.ui.carrossel = (function ($) {
    //instancia de namespace unica    
    "use strict";

    //membros privados   
    let inicia = function () {};
    $(inicia);

    function ativa(seletor, itens = 4, mostra = false) {
        //controle
        const $carrossel = $(seletor);
        $carrossel.owlCarousel({
            margin: 10,
            loop: false,    
            autoplay: mostra,
            responsiveClass: true,
            nav: false,
            responsive: {
                0: {
                    items: 1      
                },
                540: {
                    items: 2                    
                },
                720: {
                    items: 3
                },
                900: {
                    items: itens
                }
            }
        });
    };

    function ativaLoop(seletor) {
        const $carrossel = $(seletor);
        $carrossel.owlCarousel({
            items: 4,
            loop: true,
            margin: 120,
            center: true,
            lazyLoad: true,
            smartSpeed: 1000,
            nav: true,
            dots: true,
            responsiveClass: true,
            responsive: {
                0: {
                    items: 1,
                    nav: false
                },
                600: {
                    items: 2,
                    nav: false,
                    loop: true,
                    autoplay: true,
                    autoplayTimeout: 1500
                },
                1000: {
                    items: 4,
                    nav: false,
                    loop: true,
                    autoplay: true,
                    autoplayTimeout: 2000
                }
            }
        });
    };

    //membros publicos
    return {
        ativa: ativa,
        ativaLoop: ativaLoop
    };
})(jQuery);