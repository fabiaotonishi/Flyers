#pragma checksum "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\Usuarios\Exibe.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "d7cff794a37f599c53eae5182e980a15b7dd8a17ac23858c6052d56f67fba014"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_App_Views_Usuarios_Exibe), @"mvc.1.0.view", @"/Areas/App/Views/Usuarios/Exibe.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"d7cff794a37f599c53eae5182e980a15b7dd8a17ac23858c6052d56f67fba014", @"/Areas/App/Views/Usuarios/Exibe.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4bfb816eeb5ba81ddeaf30a684d4ebf36eccb183834ccb77c90e80c3692c3096", @"/Areas/App/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_App_Views_Usuarios_Exibe : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UsuarioEntity>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-action", new global::Microsoft.AspNetCore.Html.HtmlString("trocar-exibe-usuario"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Obtem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Usuarios", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link active disabled"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("tab"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("tab"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("aria-controls", new global::Microsoft.AspNetCore.Html.HtmlString("tab-exibe-usuario"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\Usuarios\Exibe.cshtml"
  
    ViewData["Title"] = "Usuário";
    Layout = "~/Areas/App/Views/Shared/_Dashboard.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""exibe-usuario"" class=""container-fluid"">
    <div class=""row"">
        <div class=""col-lg-12"">
            <div class=""card shadow my-4"">
                <div class=""card-header"">
                    <div class=""d-flex justify-content-between align-items-center"">
                        <div class=""row no-gutters align-items-center mt-3"">
                            <div class=""col-auto"">
                                <i class=""fas fa-user-cog fa-2x text-gray-300 p-2""></i>
                            </div>
                            <div class=""col mr-2"">
                                <h3 class=""h4 mb-0 font-weight-bold"">
                                    <small class=""d-block text-xs font-weight-bold text-gray-800 text-uppercase mb-1"">
                                        Controle
                                    </small>
                                    ");
#nullable restore
#line 22 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\Usuarios\Exibe.cshtml"
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
                                <a class=""accordion-toggle"" data-toggle=""collapse"" href=""#tab-exibe-usuario"" aria-expanded=""true"" aria-controls=""tab-exibe-usuario"">
                                    <i class=""fa"" aria-hidden=""true""></i>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""card-body"">
                    <ul class=""nav nav-tabs"">
                        <li class=""nav-item"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d7cff794a37f599c53eae5182e980a15b7dd8a17ac23858c6052d56f67fba0149764", async() => {
                WriteLiteral("\r\n                                <i class=\"fa-fw fas fa-user-cog\"></i>\r\n                                <h4 class=\"text-xs d-none d-md-inline text-uppercase font-weight-bold\">\r\n                                    ");
#nullable restore
#line 41 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\Usuarios\Exibe.cshtml"
                               Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </h4>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 38 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\Usuarios\Exibe.cshtml"
                                                                                                                 WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </li>
                    </ul>
                    <div id=""tab-exibe-usuario"" class=""tab-content collapse show mb-3"">
                        <div class=""tab-pane fade show active mt-3 mx-3"" role=""tabpanel"">
                            ");
#nullable restore
#line 48 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\Usuarios\Exibe.cshtml"
                       Write(await Html.PartialAsync("_Obtem.cshtml", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 58 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\Usuarios\Exibe.cshtml"
Write(await Html.PartialAsync("~/Views/Shared/_ValidationScriptsPartial.cshtml"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <script>
        $(function () {
            const $exibeUsuario = $('#exibe-usuario');

            $exibeUsuario.on('click', 'a[data-action=""trocar-exibe-usuario""]', async function (evento) {
                evento.preventDefault();
                const $tab = $(this);
                const url = $tab.attr('href');
                webapp.ui.bloqueio.ativa(true);
                $.get(url, async function (resposta, status, jqXHR) {
                    $exibeUsuario.find('#tab-exibe-usuario .tab-pane').html(resposta);
                }).then(function () {
                    webapp.ui.bloqueio.ativa(false);
                    $exibeUsuario.find('.nav-tabs a').removeClass('active disabled')
                    $tab.addClass('active disabled');
                    $tab.tab('show');
                });
            });

            $exibeUsuario.on('submit', 'form', function (evento) {
                evento.preventDefault();
                try {
                    $exibeUsuario.fi");
                WriteLiteral(@"nd('button[data-action=""salvar-edita""]').attr(""disabled"", true);
                    webapp.formulario.envia(this)
                        .then(function (resposta) {
                            if (resposta.retorno) {
                                webapp.ui.mensagem.sucesso(""Sucesso"", ""Operação realizada com sucesso"");
                                setTimeout(function () {
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
                           ");
                WriteLiteral(@"             }
                                    }
                                }, 1000);
                            }
                            else {
                                $exibeUsuario.find('form').replaceWith(resposta);
                                webapp.ui.mensagem.atencao(""Atenção"", ""Operação com problemas"");
                            }
                        });
                }
                catch (erro) {
                    console.log(erro);
                }
                finally {
                    $exibeUsuario.find('button[data-action=""salvar-edita""]').removeAttr(""disabled"");
                }
            });

            $(document).ready(function () {
                //$exibeUsuario.find('.nav-item a:first').click();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UsuarioEntity> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
