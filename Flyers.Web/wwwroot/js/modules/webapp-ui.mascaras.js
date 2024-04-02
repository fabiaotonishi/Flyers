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