/* Modulos */
window.webapp = window.webapp || {};
window.webapp.ui = window.webapp.ui || {};
window.webapp.utilidades = window.webapp.utilidades || {};
window.webapp.formulario = window.webapp.formulario || {};
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
/* Modulo ui: Plugin mask */
webapp.ui.mascaras = (function ($) {
    //instancia de namespace unica    
    "use strict";

    //membros privados
    //iniciar o modulo (construtor) 
    let inicia = function () {       
        ativa();
    };
    $(inicia);

    function ativa() {
        $('.data').mask('00/00/0000');
        $('.hora').mask('00:00:00');
        $('.data_hora').mask('00/00/0000 00:00:00');
        $('.cep').mask('00000-000');
        $('.tel').mask('(00) 0000-0000');
        $('.mixed').mask('AAA 000-S0S');
        $('.ip').mask('099.099.099.099');
        $('.porcento').mask('##0,00%', { reverse: true });
        $('.data_clear').mask("00/00/0000", { clearIfNotMatch: true });
        $('.data_placeholder').mask("00/00/0000", { placeholder: "__/__/____" });
        $('.fallback').mask("00r00r0000", {
            translation: {
                'r': {
                    pattern: /[\/]/,
                    fallback: '/'
                },
                placeholder: "__/__/____"
            }
        });
        $('.selectonfocus').mask("00/00/0000", { selectOnFocus: true });
        $('.cep_callback').mask('00000-000', {
            onComplete: function (cep) {
                console.log('Mask is done!:', cep);
            },
            onKeyPress: function (cep, event, currentField, options) {
                console.log('An key was pressed!:', cep, ' event: ', event, 'currentField: ', currentField.attr('class'), ' options: ', options);
            },
            onInvalid: function (val, e, field, invalid, options) {
                var error = invalid[0];
                console.log("Digit: ", error.v, " is invalid for the position: ", error.p, ". We expect something like: ", error.e);
            }
        });
        $('.ativa_cep').mask('00000-000', {
            onKeyPress: function (cep, e, field, options) {
                var masks = ['00000-000', '0-00-00-00'];
                var mask = (cep.length > 7) ? masks[1] : masks[0];
                $('.ativa_cep').mask(mask, options);
            }
        });
        $('.cnpj').mask('00.000.000/0000-00', { reverse: true });
        $('.cpf').mask('000.000.000-00', { reverse: true });
        $('.valor').mask('#.##0,00', { reverse: true });

        let BrMaskBehavior = function (val) {
            return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
        },
            spOptions = {
                onKeyPress: function (val, e, field, options) {
                    field.mask(BrMaskBehavior.apply({}, arguments), options);
                }
            };

        $('.tel_br').mask(BrMaskBehavior, spOptions);
        $(".bt-mask-it").click(function () {
            $(".mask-on-div").mask("000.000.000-00");
            $(".mask-on-div").fadeOut(500).fadeIn(500);
        });
    };

    return {
        ativa: ativa,
    };
})(jQuery);
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
/* Modulo ui: Plugin bootstrap-table */
webapp.ui.tabelabt = (function ($) {
    //instancia de namespace unica    
    "use strict";

    //membros privados
    let inicia = function () { };
    $(inicia);

    function ativa(seletor) {
        const $tabela = $(seletor);
        $tabela.bootstrapTable({
            classes: 'table table-bordered table-hover table-striped table-borderless',
            toolbar: '.table-toolbar',
            locale: 'pt-BR',
            search: true,
            showRefresh: false,
            showToggle: true,
            showFullscreen: true,
            showColumns: false,
            pagination: true,
            striped: true,
            sortable: true,
            pageSize: 8,
            pageList: [8, 10, 25, 50, 100],
            searchAlign: 'left',
            buttonsAlign: 'right',
            formatShowingRows: function (pageFrom, pageTo, totalRows) {
                return '';
            },
            formatRecordsPerPage: function (pageNumber) {
                return pageNumber + ' rows visible';
            }
        });
    };

    //membros publicos
    return {
        ativa: ativa
    };
})(jQuery);
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