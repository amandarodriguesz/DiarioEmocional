#pragma checksum "C:\Users\Amanda Rodrigues\Desktop\DiarioEmocional\DiarioEmocional\Views\Emocaos\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7bac52787b0c220f0f55f86522fabc673a03e182"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Emocaos_Details), @"mvc.1.0.view", @"/Views/Emocaos/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Emocaos/Details.cshtml", typeof(AspNetCore.Views_Emocaos_Details))]
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
#line 1 "C:\Users\Amanda Rodrigues\Desktop\DiarioEmocional\DiarioEmocional\Views\_ViewImports.cshtml"
using DiarioEmocional;

#line default
#line hidden
#line 2 "C:\Users\Amanda Rodrigues\Desktop\DiarioEmocional\DiarioEmocional\Views\_ViewImports.cshtml"
using DiarioEmocional.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7bac52787b0c220f0f55f86522fabc673a03e182", @"/Views/Emocaos/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96345c88948406dbb885d768920303ccd9a9db0d", @"/Views/_ViewImports.cshtml")]
    public class Views_Emocaos_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DiarioEmocional.Models.Emocao>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(38, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Amanda Rodrigues\Desktop\DiarioEmocional\DiarioEmocional\Views\Emocaos\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(83, 129, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Emocao</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(213, 45, false);
#line 14 "C:\Users\Amanda Rodrigues\Desktop\DiarioEmocional\DiarioEmocional\Views\Emocaos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Descricao));

#line default
#line hidden
            EndContext();
            BeginContext(258, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(322, 41, false);
#line 17 "C:\Users\Amanda Rodrigues\Desktop\DiarioEmocional\DiarioEmocional\Views\Emocaos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Descricao));

#line default
#line hidden
            EndContext();
            BeginContext(363, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(426, 41, false);
#line 20 "C:\Users\Amanda Rodrigues\Desktop\DiarioEmocional\DiarioEmocional\Views\Emocaos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Ativo));

#line default
#line hidden
            EndContext();
            BeginContext(467, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(531, 37, false);
#line 23 "C:\Users\Amanda Rodrigues\Desktop\DiarioEmocional\DiarioEmocional\Views\Emocaos\Details.cshtml"
       Write(Html.DisplayFor(model => model.Ativo));

#line default
#line hidden
            EndContext();
            BeginContext(568, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(631, 48, false);
#line 26 "C:\Users\Amanda Rodrigues\Desktop\DiarioEmocional\DiarioEmocional\Views\Emocaos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DataInclusao));

#line default
#line hidden
            EndContext();
            BeginContext(679, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(743, 44, false);
#line 29 "C:\Users\Amanda Rodrigues\Desktop\DiarioEmocional\DiarioEmocional\Views\Emocaos\Details.cshtml"
       Write(Html.DisplayFor(model => model.DataInclusao));

#line default
#line hidden
            EndContext();
            BeginContext(787, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(850, 49, false);
#line 32 "C:\Users\Amanda Rodrigues\Desktop\DiarioEmocional\DiarioEmocional\Views\Emocaos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DataAlteracao));

#line default
#line hidden
            EndContext();
            BeginContext(899, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(963, 45, false);
#line 35 "C:\Users\Amanda Rodrigues\Desktop\DiarioEmocional\DiarioEmocional\Views\Emocaos\Details.cshtml"
       Write(Html.DisplayFor(model => model.DataAlteracao));

#line default
#line hidden
            EndContext();
            BeginContext(1008, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1071, 51, false);
#line 38 "C:\Users\Amanda Rodrigues\Desktop\DiarioEmocional\DiarioEmocional\Views\Emocaos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UsuarioInclusao));

#line default
#line hidden
            EndContext();
            BeginContext(1122, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1186, 47, false);
#line 41 "C:\Users\Amanda Rodrigues\Desktop\DiarioEmocional\DiarioEmocional\Views\Emocaos\Details.cshtml"
       Write(Html.DisplayFor(model => model.UsuarioInclusao));

#line default
#line hidden
            EndContext();
            BeginContext(1233, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1296, 52, false);
#line 44 "C:\Users\Amanda Rodrigues\Desktop\DiarioEmocional\DiarioEmocional\Views\Emocaos\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UsuarioAlteracao));

#line default
#line hidden
            EndContext();
            BeginContext(1348, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1412, 48, false);
#line 47 "C:\Users\Amanda Rodrigues\Desktop\DiarioEmocional\DiarioEmocional\Views\Emocaos\Details.cshtml"
       Write(Html.DisplayFor(model => model.UsuarioAlteracao));

#line default
#line hidden
            EndContext();
            BeginContext(1460, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1507, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7bac52787b0c220f0f55f86522fabc673a03e1829586", async() => {
                BeginContext(1553, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 52 "C:\Users\Amanda Rodrigues\Desktop\DiarioEmocional\DiarioEmocional\Views\Emocaos\Details.cshtml"
                           WriteLiteral(Model.ID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1561, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1569, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7bac52787b0c220f0f55f86522fabc673a03e18211922", async() => {
                BeginContext(1591, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1607, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DiarioEmocional.Models.Emocao> Html { get; private set; }
    }
}
#pragma warning restore 1591