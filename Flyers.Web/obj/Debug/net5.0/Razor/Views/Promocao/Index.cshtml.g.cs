#pragma checksum "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\Promocao\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "99145e9d6eefe077915f2094a5ced0fd2debee336b9f9119ae780a72a06cf65f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Promocao_Index), @"mvc.1.0.view", @"/Views/Promocao/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Flyers.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Flyers.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Flyers.Web.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Flyers.Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Flyers.Core.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Flyers.Core.Dtos.DataTables;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Flyers.Core.Values;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Flyers.Core.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Flyers.Core.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"99145e9d6eefe077915f2094a5ced0fd2debee336b9f9119ae780a72a06cf65f", @"/Views/Promocao/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"bcbc7f61e0607eb366f4a00fc6159a10854fc49ff10c548c31803fa326da5275", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Promocao_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PromocaoViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<section id=\"index-promocao\" class=\"overflow-hidden\">\r\n    <div class=\"bg-01 text-dark\">\r\n        <div id=\"index-promocao-detalhes\" class=\"container-cover section-1\">\r\n            ");
#nullable restore
#line 6 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\Promocao\Index.cshtml"
       Write(await Html.PartialAsync("_Detalhes.cshtml", Model.Detalhes));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>
    </div>
    <div class=""bg-03 text-dark"">
        <div id=""index-promocao-catalogo"" class=""container px-5 section-5"">
            <div class=""row row-cols-1 my-5"">
                <div class=""col"" data-aos=""fade-down"">
                    <div class=""text-center"">
                        <h3 class=""h1 mb-3 font-weight-bold"">
                            <strong class=""d-block h5 text-uppercase"">Promoção</strong>
                            Produtos em Oferta
                        </h3>
                    </div>
                </div>
                <div id=""index-promocao-pesquisa"" class=""col mb-3"" data-aos=""fade-up"">
                    ");
#nullable restore
#line 21 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\Promocao\Index.cshtml"
               Write(await Html.PartialAsync("_Pesquisa.cshtml", Model.Pesquisa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div id=\"index-promocao-listagem\" class=\"col mb-3\" data-aos=\"fade-down\">\r\n                    ");
#nullable restore
#line 24 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\Promocao\Index.cshtml"
               Write(await Html.PartialAsync("_Listagem.cshtml", Model.Listagem));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(function () {
            const $indexPromocaoPesquisa = $('#index-promocao-pesquisa');
            const $indexPromocaoListagem = $('#index-promocao-listagem');

            $indexPromocaoPesquisa.on('change', 'form', function (evento) {
                evento.preventDefault();
                $indexPromocaoPesquisa.find('form').submit();
            });

            $indexPromocaoPesquisa.on('submit', 'form', function (evento) {
                evento.preventDefault();
                try {
                    webapp.formulario.envia(this)
                        .then(function (resposta) {
                            $indexPromocaoListagem.html(resposta);
                        });
                } catch (erro) {
                    console.log(erro);
                }
            });

            $indexPromocaoListagem.on('click', 'a[data-action=""exibir""]', function (evento) {
                evento.preventDefault();
                const url = $(this).at");
                WriteLiteral(@"tr('href');
                $(this).dialogoModal(""Produto"", url, false);
            });

            $indexPromocaoListagem.on('click', 'button[data-action=""voltar""], button[data-action=""seguir""]', function (evento) {
                evento.preventDefault();
                const index = $(this).data('index');
                $indexPromocaoPesquisa.find('input[name=""Index""]').val(index);
                $indexPromocaoPesquisa.find('form').submit();
            });

            $(document).ready(function () {
                webapp.ui.carrossel.ativa("".owl-carousel"");
                webapp.ui.alvenaria.ativa('.grid-group');
            });

            $(document).ajaxComplete(function () {
                webapp.ui.alvenaria.ativa('.grid-group');
            });
        });
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PromocaoViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
