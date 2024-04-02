#pragma checksum "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a3b846047123e8693243b807f1785c7a90c8b391"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3b846047123e8693243b807f1785c7a90c8b391", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1236e91af1441e75fadd78bcf3ad5a7a7c4b5722", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DominioEntity>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div id=""index-home"" class=""overflow-hidden"">
    <section class=""bg-01 text-dark"">
        <div id=""index-home-promocao"" class=""container-cover section-1"">
        </div>
    </section>
    <section class=""bg-02 text-white"">
        <div id=""index-home-sobrenos"" class=""container-fluid section-2"">
            ");
#nullable restore
#line 10 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Home\Index.cshtml"
       Write(await Html.PartialAsync("~/Views/Sobrenos/_Detalhes.cshtml", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>
    </section>
    <section class=""bg-03 text-dark"">
        <div id=""index-home-produtos"" class=""container-fluid section-3"">
        </div>
    </section>
    <section class=""bg-04 text-white"">
        <div id=""index-home-contatos"" class=""container-fluid section-4"">
            ");
#nullable restore
#line 19 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Home\Index.cshtml"
       Write(await Html.PartialAsync("~/Views/Contatos/_Detalhes.cshtml", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </section>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
    $(function () {
        const $indexHomePromocao = $('#index-home-promocao');
        const $indexHomeProdutos = $('#index-home-produtos');

        $indexHomeProdutos.on('click', 'a[data-action=""exibir""]', function (evento) {
            evento.preventDefault();
            const url = $(this).attr('href');
            $(this).dialogoModal(""Produto"", url, false);
        });

        $(document).ready(function () {
            $indexHomePromocao.load('");
#nullable restore
#line 37 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Home\Index.cshtml"
                                Write(Url.Action("Destaque", "Promocao"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n            $indexHomeProdutos.load(\'");
#nullable restore
#line 38 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Home\Index.cshtml"
                                Write(Url.Action("Destaque", "Produtos"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n            $(\'.venobox\').venobox();\r\n        });\r\n\r\n        $(document).ajaxComplete(function () {\r\n            webapp.ui.carrossel.ativaLoop(\".owl-carousel\");\r\n        });\r\n    });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DominioEntity> Html { get; private set; }
    }
}
#pragma warning restore 1591
