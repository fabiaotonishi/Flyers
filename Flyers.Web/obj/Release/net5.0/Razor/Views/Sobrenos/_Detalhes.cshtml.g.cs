#pragma checksum "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Sobrenos\_Detalhes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8bf73b92f648d0474756d61ad555c15c755d27c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sobrenos__Detalhes), @"mvc.1.0.view", @"/Views/Sobrenos/_Detalhes.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8bf73b92f648d0474756d61ad555c15c755d27c", @"/Views/Sobrenos/_Detalhes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1236e91af1441e75fadd78bcf3ad5a7a7c4b5722", @"/Views/_ViewImports.cshtml")]
    public class Views_Sobrenos__Detalhes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DominioEntity>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div id=\"detalhes-sobrenos\" class=\"container\">\r\n");
#nullable restore
#line 4 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Sobrenos\_Detalhes.cshtml"
     if (string.IsNullOrWhiteSpace(@Model.Video))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""row row-cols-1 my-5"">
            <div class=""col"" data-aos=""fade-down"">
                <div class=""text-center"">
                    <h3 class=""h1 mb-3 font-weight-bold"">
                        <strong class=""d-block h5 text-uppercase"">Sobre-nós</strong>
                        ");
#nullable restore
#line 11 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Sobrenos\_Detalhes.cshtml"
                   Write(Model.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h3>\r\n                </div>\r\n            </div>\r\n            <div class=\"col\" data-aos=\"fade-up\">\r\n                <div class=\"lead text-center\">\r\n                    ");
#nullable restore
#line 17 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Sobrenos\_Detalhes.cshtml"
               Write(Html.Raw(Model.Descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 21 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Sobrenos\_Detalhes.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row row-cols-1 row-cols-md-2 my-5\">\r\n            <div class=\"col\" data-aos=\"fade-right\">\r\n                <div class=\"video-box rounded m-auto bg-dark pattern-texture\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 963, "\"", 982, 1);
#nullable restore
#line 27 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Sobrenos\_Detalhes.cshtml"
WriteAttributeValue("", 970, Model.Video, 970, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"venobox btn-play\" data-vbtype=\"video\" data-autoplay=\"true\"></a>\r\n                    <iframe");
            BeginWriteAttribute("src", " src=\"", 1083, "\"", 1101, 1);
#nullable restore
#line 28 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Sobrenos\_Detalhes.cshtml"
WriteAttributeValue("", 1089, Model.Video, 1089, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" title=""Vídeo institucional"" frameborder=""0"" allow=""encrypted-media; gyroscope; picture-in-picture"" allowfullscreen></iframe>
                </div>
            </div>
            <div class=""col"" data-aos=""fade-left"">
                <div class=""text-left"">
                    <h3 class=""h1 my-3 font-weight-bold"">
                        <strong class=""d-block h5 text-uppercase"">Sobre-nós</strong>
                        ");
#nullable restore
#line 35 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Sobrenos\_Detalhes.cshtml"
                   Write(Model.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h3>\r\n                    <div class=\"lead text-left\">\r\n                        ");
#nullable restore
#line 38 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Sobrenos\_Detalhes.cshtml"
                   Write(Html.Raw(Model.Descricao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 43 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Sobrenos\_Detalhes.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
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
