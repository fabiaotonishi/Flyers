#pragma checksum "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Promocao\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "acd8d5d9e95f3c9cba3aab659c8e0667c31d877b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Promocao_Index), @"mvc.1.0.view", @"/Views/Promocao/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Flyers.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Flyers.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Flyers.Web.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Flyers.Web.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Flyers.Core.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Flyers.Core.Dtos.DataTables;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Flyers.Core.Values;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Flyers.Core.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Flyers.Core.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acd8d5d9e95f3c9cba3aab659c8e0667c31d877b", @"/Views/Promocao/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1236e91af1441e75fadd78bcf3ad5a7a7c4b5722", @"/Views/_ViewImports.cshtml")]
    public class Views_Promocao_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PromocaoViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<section id=\"index-promocao\" class=\"overflow-hidden\">\r\n    <div class=\"bg-01 text-dark\">\r\n        <div id=\"index-promocao-detalhes\" class=\"container-cover section-1\">\r\n            ");
#nullable restore
#line 6 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Promocao\Index.cshtml"
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
#line 21 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Promocao\Index.cshtml"
               Write(await Html.PartialAsync("_Pesquisa.cshtml", Model.Pesquisa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div id=\"index-promocao-listagem\" class=\"col mb-3\" data-aos=\"fade-down\">\r\n                    ");
#nullable restore
#line 24 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Promocao\Index.cshtml"
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
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PromocaoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
