#pragma checksum "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Profile\MyFriends.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9944adb6b0e9269ed03303c735bcdd930c5e4514"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_MyFriends), @"mvc.1.0.view", @"/Views/Profile/MyFriends.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9944adb6b0e9269ed03303c735bcdd930c5e4514", @"/Views/Profile/MyFriends.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86231a4649c01c84807eb31820428747a7f0653e", @"/Views/_ViewImports.cshtml")]
    public class Views_Profile_MyFriends : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OnlineGameStore.Models.Profile>>
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
            WriteLiteral(@"

    <div class=""page"" style=""background: white;   margin-top: 25px; margin-bottom: 20px;"">
        <h2 style=""color: black;"" class=""entry-title"">Gamers I Follow</h2>
        <table class=""table"">
            <thead>
                <tr>
                    <th>
                        ");
#nullable restore
#line 10 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Profile\MyFriends.cshtml"
                   Write(Html.DisplayNameFor(model => model.ProfileName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 13 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Profile\MyFriends.cshtml"
                   Write(Html.DisplayNameFor(model => model.ProfileDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 16 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Profile\MyFriends.cshtml"
                   Write(Html.DisplayNameFor(model => model.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 19 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Profile\MyFriends.cshtml"
                   Write(Html.DisplayNameFor(model => model.FavouriteGameCategory));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 22 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Profile\MyFriends.cshtml"
                   Write(Html.DisplayNameFor(model => model.FavouritePlatform));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 25 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Profile\MyFriends.cshtml"
                   Write(Html.DisplayNameFor(model => model.PaidOrFree));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 30 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Profile\MyFriends.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 34 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Profile\MyFriends.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ProfileName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 37 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Profile\MyFriends.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ProfileDescription));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 40 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Profile\MyFriends.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 43 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Profile\MyFriends.cshtml"
                       Write(Html.DisplayFor(modelItem => item.FavouriteGameCategory));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 46 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Profile\MyFriends.cshtml"
                       Write(Html.DisplayFor(modelItem => item.FavouritePlatform));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 49 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Profile\MyFriends.cshtml"
                       Write(Html.DisplayFor(modelItem => item.PaidOrFree));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 52 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Profile\MyFriends.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9944adb6b0e9269ed03303c735bcdd930c5e45149450", async() => {
                WriteLiteral("View Profile");
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
#line 55 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Profile\MyFriends.cshtml"
                                                      WriteLiteral(item.ProfileId);

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
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 58 "C:\Users\sssmr\Source\Repos\Group 2 PROG3050-20F-Sec1\OnlineGameStore\OnlineGameStore\Views\Profile\MyFriends.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n        <div class=\"addtocart-bar\" style=\"  margin-top: 25px; margin-bottom: 20px;\">\r\n            <a href=\"javascript:history.back()\">Back</a>\r\n        </div>\r\n\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OnlineGameStore.Models.Profile>> Html { get; private set; }
    }
}
#pragma warning restore 1591
