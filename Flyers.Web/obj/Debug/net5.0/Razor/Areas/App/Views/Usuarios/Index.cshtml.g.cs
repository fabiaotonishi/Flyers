#pragma checksum "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\Usuarios\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0b9cb175656c780ce9ec2931dd951689192158edfdc8b94b5c72dc12f375d6f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_App_Views_Usuarios_Index), @"mvc.1.0.view", @"/Areas/App/Views/Usuarios/Index.cshtml")]
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
#line 1 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Flyers.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Flyers.Web.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Flyers.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Flyers.Web.Areas.App.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Flyers.Core.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Flyers.Core.Values;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Flyers.Core.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Flyers.Core.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"0b9cb175656c780ce9ec2931dd951689192158edfdc8b94b5c72dc12f375d6f4", @"/Areas/App/Views/Usuarios/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4bfb816eeb5ba81ddeaf30a684d4ebf36eccb183834ccb77c90e80c3692c3096", @"/Areas/App/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_App_Views_Usuarios_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UsuarioEntity>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\Usuarios\Index.cshtml"
  
    ViewData["Title"] = "Usuários";
    Layout = "~/Areas/App/Views/Shared/_Dashboard.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""index-usuario"" class=""container-fluid"">
    <div class=""row"">
        <div class=""col-lg-12"">
            <div class=""card shadow my-4"">
                <div class=""card-header"">
                    <div class=""d-flex justify-content-between align-items-center"">
                        <div class=""row no-gutters align-items-center mt-3"">
                            <div class=""col-auto"">
                                <i class=""fas fa-users-cog fa-2x text-gray-300 p-2""></i>
                            </div>
                            <div class=""col mr-2"">
                                <h3 class=""h4 mb-0 font-weight-bold"">
                                    <small class=""d-block text-xs font-weight-bold text-gray-800 text-uppercase mb-1"">
                                        Controle
                                    </small>
                                    ");
#nullable restore
#line 22 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\Usuarios\Index.cshtml"
                               Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </h3>
                            </div>
                        </div>
                        <div class=""btn-toolbar"" role=""toolbar"">
                            <div role=""group"" class=""btn-group align-items-center"">
                                <a class=""accordion-toggle"" data-toggle=""collapse"" href=""#tab-index-usuario"" aria-expanded=""true"" aria-controls=""tab-index-usuario"">
                                    <i class=""fa"" aria-hidden=""true""></i>
                                </a>
                            </div>
                        </div>
                    </div>                    
                </div>
                <div class=""card-body"">
                    <ul class=""nav nav-tabs"">
                        <li class=""nav-item"">
                            <a data-action=""trocar-index-usuario"" class=""nav-link active disabled"" data-toggle=""tab"" role=""tab"" aria-controls=""tab-index-usuario"">
                                <i class=""fa-f");
            WriteLiteral("w fas fa-users-cog\"></i>\r\n                                <h4 class=\"text-xs d-none d-md-inline text-uppercase font-weight-bold\">\r\n                                    ");
#nullable restore
#line 41 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\Usuarios\Index.cshtml"
                               Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </h4>
                            </a>
                        </li>
                    </ul>
                    <div id=""tab-index-usuario"" class=""tab-content collapse show mb-3"">
                        <div class=""tab-pane fade show active mt-3 mx-3"" role=""tabpanel"">
                            ");
#nullable restore
#line 48 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\Usuarios\Index.cshtml"
                       Write(await Html.PartialAsync("_Lista.cshtml", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(function () {
            const $indexUsuario = $('#index-usuario');

            $(document).ready(function () {
                webapp.ui.tabelabt.ativa('.table');
            });

            $(document).ajaxComplete(function () { });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UsuarioEntity>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
