#pragma checksum "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Produtos\_Detalhes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5736079e3af2453ddd670d74ad25458fb55ac969"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Produtos__Detalhes), @"mvc.1.0.view", @"/Views/Produtos/_Detalhes.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5736079e3af2453ddd670d74ad25458fb55ac969", @"/Views/Produtos/_Detalhes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1236e91af1441e75fadd78bcf3ad5a7a7c4b5722", @"/Views/_ViewImports.cshtml")]
    public class Views_Produtos__Detalhes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProdutoEntity>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div id=\"detalhes-produto\" class=\"container\">\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 5 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Produtos\_Detalhes.cshtml"
         if (Model.Imagem != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col\">\r\n                <div class=\"easyzoom easyzoom--adjacent\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 253, "\"", 277, 1);
#nullable restore
#line 9 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Produtos\_Detalhes.cshtml"
WriteAttributeValue("", 260, Model.Imagem.Url, 260, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 309, "\"", 332, 1);
#nullable restore
#line 10 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Produtos\_Detalhes.cshtml"
WriteAttributeValue("", 315, Model.Imagem.Url, 315, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 333, "\"", 350, 1);
#nullable restore
#line 10 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Produtos\_Detalhes.cshtml"
WriteAttributeValue("", 339, Model.Nome, 339, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid rounded\" />\r\n                    </a>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 14 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Produtos\_Detalhes.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col\">\r\n            <strong class=\"d-inline-block small text-muted text-uppercase mb-2\">");
#nullable restore
#line 16 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Produtos\_Detalhes.cshtml"
                                                                           Write(Model.Categoria.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n            <h2 class=\"h3 font-weight-bold mb-0\">");
#nullable restore
#line 17 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Produtos\_Detalhes.cshtml"
                                            Write(Model.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n            <hr />\r\n            <div class=\"text-left\">\r\n                <strong class=\"h5\">Descrição</strong>\r\n                <p class=\"card-text text-justify mb-auto\">");
#nullable restore
#line 21 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Produtos\_Detalhes.cshtml"
                                                     Write(Model.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<script>\r\n    $(function () {\r\n        $(\'.easyzoom\').easyZoom();\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProdutoEntity> Html { get; private set; }
    }
}
#pragma warning restore 1591