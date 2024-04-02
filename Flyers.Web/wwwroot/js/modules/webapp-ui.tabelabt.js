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