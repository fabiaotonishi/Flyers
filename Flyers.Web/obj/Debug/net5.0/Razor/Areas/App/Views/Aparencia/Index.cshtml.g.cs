#pragma checksum "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\Aparencia\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "563b5cfdec225148d366e4f7de92cdc068bbd2f1e2de46e5d3e137dee7914865"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_App_Views_Aparencia_Index), @"mvc.1.0.view", @"/Areas/App/Views/Aparencia/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"563b5cfdec225148d366e4f7de92cdc068bbd2f1e2de46e5d3e137dee7914865", @"/Areas/App/Views/Aparencia/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"4bfb816eeb5ba81ddeaf30a684d4ebf36eccb183834ccb77c90e80c3692c3096", @"/Areas/App/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_App_Views_Aparencia_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LayoutViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-action", new global::Microsoft.AspNetCore.Html.HtmlString("trocar-index-aparencia"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Obtem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Aparencia", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link active disabled"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("tab"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("tab"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("aria-controls", new global::Microsoft.AspNetCore.Html.HtmlString("tab-index-aparencia"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\Aparencia\Index.cshtml"
  
    ViewData["Title"] = "Aparência";
    Layout = "~/Areas/App/Views/Shared/_Dashboard.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""index-aparencia"" class=""container-fluid"">
    <div class=""row"">
        <div class=""col-lg-12"">
            <div class=""card shadow my-4"">
                <div class=""card-header"">
                    <div class=""d-flex justify-content-between align-items-center"">
                        <div class=""row no-gutters align-items-center mt-3"">
                            <div class=""col-auto"">
                                <i class=""fas fa-palette fa-2x text-gray-300 p-2""></i>
                            </div>
                            <div class=""col mr-2"">
                                <h3 class=""h4 mb-0 font-weight-bold"">
                                    <small class=""d-block text-xs font-weight-bold text-gray-800 text-uppercase mb-1"">
                                        Controle
                                    </small>
                                    ");
#nullable restore
#line 22 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\Aparencia\Index.cshtml"
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
                                <a class=""accordion-toggle"" data-toggle=""collapse"" href=""#tab-index-aparencia"" aria-expanded=""true"" aria-controls=""tab-index-aparencia"">
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "563b5cfdec225148d366e4f7de92cdc068bbd2f1e2de46e5d3e137dee79148659785", async() => {
                WriteLiteral(@"
                                <i class=""fas fa-paint-roller""></i>
                                <h4 class=""text-xs d-none d-md-inline text-uppercase font-weight-bold"">
                                    Website
                                </h4>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
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
                    <div id=""tab-index-aparencia"" class=""tab-content collapse show mb-3"">
                        <div class=""tab-pane fade show active mt-3 mx-3"" role=""tabpanel"">
                            ");
#nullable restore
#line 48 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\Aparencia\Index.cshtml"
                       Write(await Html.PartialAsync("_Obtem.cshtml", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 58 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Areas\App\Views\Aparencia\Index.cshtml"
Write(await Html.PartialAsync("~/Areas/App/Views/Shared/_ValidationScriptsPartial.cshtml"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <script>
        $(function () {
            const $indexAparencia = $('#index-aparencia');

            $indexAparencia.on('click', 'a[data-action=""trocar-index-aparencia""]', async function (evento) {
                evento.preventDefault();
                const $tab = $(this);
                const url = $tab.attr('href');
                webapp.ui.bloqueio.ativa(true);
                $.get(url, async function (resposta, status, jqXHR) {
                    $indexAparencia.find('#tab-index-aparencia .tab-pane').html(resposta);
                }).then(function () {
                    webapp.ui.bloqueio.ativa(false);
                    $indexAparencia.find('.nav-tabs a').removeClass('active disabled')
                    $tab.addClass('active disabled');
                    $tab.tab('show');
                });
            });

            $indexAparencia.on('submit', 'form', function (evento) {
                evento.preventDefault();
                try {
                    ");
                WriteLiteral(@"$indexAparencia.find('button[data-action=""salvar-edita""]').attr(""disabled"", true);
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
                WriteLiteral(@"                               }
                                    }
                                }, 1000);
                            }
                            else {
                                $indexAparencia.find('form').replaceWith(resposta);
                                webapp.ui.mensagem.atencao(""Atenção"", ""Operação com problemas"");
                            }
                        });
                }
                catch (erro) {
                    console.log(erro);
                }
                finally {
                    $indexAparencia.find('button[data-action=""salvar-edita""]').removeAttr(""disabled"");
                }
            });

            $(document).ready(function () {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LayoutViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
