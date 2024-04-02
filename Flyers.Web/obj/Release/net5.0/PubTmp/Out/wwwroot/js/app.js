/* escopo global */
"use strict";

(function ($, webapp) {
    // controle de exibicao do dialogo modal
    var $dialogoModal = $('#dialogo-modal');

    // click do botao confirma
    $dialogoModal.on('click', 'button[data-action="confirmar"]', function (evento) {
        evento.preventDefault();
        $dialogoModal.find('form').submit();
    });

    // extensao jquery do modal
    $.fn.dialogoModal = function (titulo = "", url, confirma = true) {
        $dialogoModal.find('.modal-title').html(titulo);
        $dialogoModal.find('.modal-body').load(url);
        $dialogoModal.modal('show');
        if (confirma == false) {
            $dialogoModal.find('button[data-action="confirmar"]').attr("disabled", true);
            $dialogoModal.find('button[data-action="confirmar"]').addClass("d-none");
        }
        else {
            $dialogoModal.find('button[data-action="confirmar"]').removeAttr("disabled");
            $dialogoModal.find('button[data-action="confirmar"]').removeClass("d-none");
        }
        return this;
    };

    $dialogoModal.on('submit', 'form', function (evento) {
        evento.preventDefault();
        try
        {
            $dialogoModal.find('button[data-action="confirmar"]').attr("disabled", true);
            webapp.formulario.envia(this)
                .then(function (resposta) {
                    if (resposta.retorno) {
                        webapp.ui.mensagem.sucesso("Sucesso", "Operação realizada com sucesso");
                        $dialogoModal.fadeOut(1000, function () {
                            if (resposta.carrega) {
                                const $seletor = $(resposta.seletor);
                                $seletor.load(resposta.url);
                            }
                            else {
                                if (resposta.url != null) {
                                    window.location.href = resposta.url;
                                }
                                else {
                                    window.location.reload(true);
                                }
                            }
                            $dialogoModal.modal('hide');
                        });
                    }
                    else {
                        webapp.ui.mensagem.atencao("Atenção", "Operação com problemas");
                        $dialogoModal.find('form').replaceWith(resposta);
                    }
                });
        }
        catch (erro)
        {
            console.log(erro);
        }
        finally
        {
            $dialogoModal.find('button[data-action="confirmar"]').removeAttr("disabled");
        }
    });


    // botoes com as acoes padroes do modal
    $(document).on('click', 'a[data-action="editar-modal"]', function (evento) {
        evento.preventDefault();
        const url = $(this).attr('href');
        $(this).dialogoModal("Editar", url);
    });

    $(document).on('click', 'a[data-action="apagar-modal"]', function (evento) {
        evento.preventDefault();
        const url = $(this).attr('href');
        $(this).dialogoModal("Apagar", url);
    });

    // document 
    $(document).ready(function () {
        inicia();
    });

    $(document).ajaxComplete(function () {
        inicia();
    });

    function inicia() {
        webapp.ui.mascaras.ativa();
        AOS.init();
        $('.scrollbars').overlayScrollbars(); 
        $('.summernote').summernote({
            lang: 'pt-BR',
            height: 120
        });
    }
})(jQuery, webapp);

// ajuste de inicializacao dos eventos na execucao do addEventListener
jQuery.event.special.mousewheel = {
    setup: function (_, ns, handle) {
        if (ns.includes("noPreventDefault")) {
            this.addEventListener("mousewheel", handle, { passive: false });
        }
        else {
            this.addEventListener("mousewheel", handle, { passive: true });
        }
    }
};

jQuery.event.special.touchstart = {
    setup: function (_, ns, handle) {
        if (ns.includes("noPreventDefault")) {
            this.addEventListener("touchstart", handle, { passive: false });
        }
        else {
            this.addEventListener("touchstart", handle, { passive: true });
        }
    }
};

jQuery.event.special.touchmove = {
    setup: function (_, ns, handle) {
        if (ns.includes("noPreventDefault")) {
            this.addEventListener("touchmove", handle, { passive: false });
        }
        else {
            this.addEventListener("touchmove", handle, { passive: true });
        }
    }
};