#pragma checksum "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Game\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4b90a1c60dfe710ec4a70d43ab063f2295943563"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game_Index), @"mvc.1.0.view", @"/Views/Game/Index.cshtml")]
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
#line 1 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\_ViewImports.cshtml"
using OnlineGameStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\_ViewImports.cshtml"
using OnlineGameStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b90a1c60dfe710ec4a70d43ab063f2295943563", @"/Views/Game/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86231a4649c01c84807eb31820428747a7f0653e", @"/Views/_ViewImports.cshtml")]
    public class Views_Game_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OnlineGameStore.Models.Game>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("    <div class=\"page\" style=\"background: white;   margin-top: 25px; margin-bottom: 20px;\">\r\n        <h1>");
#nullable restore
#line 3 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Game\Index.cshtml"
       Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n");
            WriteLiteral("\r\n        <table class=\"table\">\r\n            <thead>\r\n                <tr>\r\n                    <th>\r\n                        ");
#nullable restore
#line 13 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Game\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.GameName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 16 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Game\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.GameDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 19 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Game\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.GameDownloadLink));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 22 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Game\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.GamePrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 25 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Game\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.GameDiscount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 28 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Game\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.GameGenre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 34 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Game\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 38 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Game\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.GameName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 41 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Game\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.GameDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 44 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Game\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.GameDownloadLink));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 47 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Game\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.GamePrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 50 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Game\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.GameDiscount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 53 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Game\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.GameGenre.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b90a1c60dfe710ec4a70d43ab063f22959435639166", async() => {
                WriteLiteral("Details");
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
#nullable restore
#line 56 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Game\Index.cshtml"
                                                      WriteLiteral(item.GameId);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\r\n");
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 61 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Game\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OnlineGameStore.Models.Game>> Html { get; private set; }
    }
}
#pragma warning restore 1591