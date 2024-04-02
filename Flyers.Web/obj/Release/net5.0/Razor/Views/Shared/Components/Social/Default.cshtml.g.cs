#pragma checksum "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Shared\Components\Social\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ad1d50ff148fee6daf622cca198d764af6dd8bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Social_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Social/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ad1d50ff148fee6daf622cca198d764af6dd8bb", @"/Views/Shared/Components/Social/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1236e91af1441e75fadd78bcf3ad5a7a7c4b5722", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Social_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RedeSocialEntity>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Shared\Components\Social\Default.cshtml"
 if (Model.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"bg-dark py-3\">\r\n        <div class=\"d-flex justify-content-center align-content-center\">\r\n");
#nullable restore
#line 7 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Shared\Components\Social\Default.cshtml"
             foreach (var redeSocial in Model)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Shared\Components\Social\Default.cshtml"
                 switch (redeSocial.Canal)
                {
                    case CanalValue.Facebook:

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 373, "\"", 395, 1);
#nullable restore
#line 12 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Shared\Components\Social\Default.cshtml"
WriteAttributeValue("", 380, redeSocial.Url, 380, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\" class=\"btn btn-social-icon btn-facebook btn-rounded\">\r\n                            <i class=\"fab fa-facebook-f\"></i>\r\n                        </a>\r\n");
#nullable restore
#line 15 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Shared\Components\Social\Default.cshtml"
                        break;
                    case CanalValue.Instagram:

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 667, "\"", 689, 1);
#nullable restore
#line 17 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Shared\Components\Social\Default.cshtml"
WriteAttributeValue("", 674, redeSocial.Url, 674, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\" class=\"btn btn-social-icon btn-instagram btn-rounded\">\r\n                            <i class=\"fab fa-instagram\"></i>\r\n                        </a>\r\n");
#nullable restore
#line 20 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Shared\Components\Social\Default.cshtml"
                        break;
                    case CanalValue.Youtube:

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 959, "\"", 981, 1);
#nullable restore
#line 22 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Shared\Components\Social\Default.cshtml"
WriteAttributeValue("", 966, redeSocial.Url, 966, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\" class=\"btn btn-social-icon btn-youtube btn-rounded\">\r\n                            <i class=\"fab fa-youtube\"></i>\r\n                        </a>\r\n");
#nullable restore
#line 25 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Shared\Components\Social\Default.cshtml"
                        break;
                    case CanalValue.Twitter:

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 1247, "\"", 1269, 1);
#nullable restore
#line 27 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Shared\Components\Social\Default.cshtml"
WriteAttributeValue("", 1254, redeSocial.Url, 1254, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\" class=\"btn btn-social-icon btn-twitter btn-rounded\">\r\n                            <i class=\"fab fa-twitter\"></i>\r\n                        </a>\r\n");
#nullable restore
#line 30 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Shared\Components\Social\Default.cshtml"
                        break;
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Shared\Components\Social\Default.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n");
#nullable restore
#line 35 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Views\Shared\Components\Social\Default.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RedeSocialEntity>> Html { get; private set; }
    }
}
#pragma warning restore 1591
