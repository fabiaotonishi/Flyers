#pragma checksum "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Areas\App\Views\Membros\_Obtem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd4f6f8560ae54ef1d1acbf0dd8b503691c5670b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_App_Views_Membros__Obtem), @"mvc.1.0.view", @"/Areas/App/Views/Membros/_Obtem.cshtml")]
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
#line 1 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Flyers.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Flyers.Web.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Flyers.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Flyers.Web.Areas.App.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Flyers.Core.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Flyers.Core.Values;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Flyers.Core.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Flyers.Core.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd4f6f8560ae54ef1d1acbf0dd8b503691c5670b", @"/Areas/App/Views/Membros/_Obtem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"979b69c52b8335e8b55d88daf8f5bbad95a9719c", @"/Areas/App/Views/_ViewImports.cshtml")]
    public class Areas_App_Views_Membros__Obtem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MembroViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div id=\"obtem-membro\" class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <h4 class=\"h6 d-block text-uppercase font-weight-bold\">\r\n            Membro\r\n        </h4>\r\n        <hr />\r\n    </div>\r\n    <div class=\"col-md-3\">\r\n        ");
#nullable restore
#line 11 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Areas\App\Views\Membros\_Obtem.cshtml"
   Write(await Html.PartialAsync("~/Areas/App/Views/Midias/_Imagem.cshtml", Model.Imagem));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"col-md-9\">\r\n        ");
#nullable restore
#line 14 "D:\Arquivos Projetos\Empresa\Flyers\Flyers\Flyers.Web\Areas\App\Views\Membros\_Obtem.cshtml"
   Write(await Html.PartialAsync("_Edita.cshtml", Model.Conta));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MembroViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
