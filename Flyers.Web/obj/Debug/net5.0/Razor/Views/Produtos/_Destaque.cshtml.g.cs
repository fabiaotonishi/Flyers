#pragma checksum "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\Produtos\_Destaque.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1f4fa925e137dddeec837193a6201bc8ad47755eb56930684abad59a44db362a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Produtos__Destaque), @"mvc.1.0.view", @"/Views/Produtos/_Destaque.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"1f4fa925e137dddeec837193a6201bc8ad47755eb56930684abad59a44db362a", @"/Views/Produtos/_Destaque.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"bcbc7f61e0607eb366f4a00fc6159a10854fc49ff10c548c31803fa326da5275", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Produtos__Destaque : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProdutoEntity>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detalhes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Produtos", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-action", new global::Microsoft.AspNetCore.Html.HtmlString("exibir"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("list-group-item list-group-item-action border-0 py-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"
<div id=""destaque-produto"" class=""row row-cols-1 my-5"">
    <div class=""col"" data-aos=""fade-down"">
        <div class=""text-center"">
            <h3 class=""h1 mb-3 font-weight-bold"">
                <strong class=""d-block h5 text-uppercase"">Produtos</strong>
                Em destaques
            </h3>
        </div>
    </div>
    <div class=""col"" data-aos=""fade-up"">
");
#nullable restore
#line 13 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\Produtos\_Destaque.cshtml"
         if (Model.Count() > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"d-flex flex-column justify-content-center align-items-center\">\r\n                <div class=\"owl-carousel owl-theme owl-loaded owl-drag list-group\">\r\n");
#nullable restore
#line 17 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\Produtos\_Destaque.cshtml"
                     foreach (var produto in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"item animated--fade-in rounded\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f4fa925e137dddeec837193a6201bc8ad47755eb56930684abad59a44db362a7286", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 21 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\Produtos\_Destaque.cshtml"
                                 if (produto.Imagem != null)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <img class=\"owl-lazy img-fluid rounded\" data-src=\"");
#nullable restore
#line 23 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\Produtos\_Destaque.cshtml"
                                                                                 Write(produto.Imagem.Url);

#line default
#line hidden
#nullable disable
                WriteLiteral("\"");
                BeginWriteAttribute("alt", " alt=\"", 1176, "\"", 1195, 1);
#nullable restore
#line 23 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\Produtos\_Destaque.cshtml"
WriteAttributeValue("", 1182, produto.Nome, 1182, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n");
#nullable restore
#line 24 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\Produtos\_Destaque.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <strong class=\"d-inline-block small text-muted text-uppercase mb-2\">");
#nullable restore
#line 25 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\Produtos\_Destaque.cshtml"
                                                                                               Write(produto.Categoria.Nome);

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong>\r\n                                <h4 class=\"h4 font-weight-bold mb-0\">");
#nullable restore
#line 26 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\Produtos\_Destaque.cshtml"
                                                                Write(produto.Nome);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 20 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\Produtos\_Destaque.cshtml"
                                                                                 WriteLiteral(produto.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 29 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\Produtos\_Destaque.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n");
#nullable restore
#line 32 "D:\Arquivos projetos\Empresa\Flyers\Flyers.Web\Views\Produtos\_Destaque.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProdutoEntity>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
