#pragma checksum "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42ceeb993ab8638d8d8bbf3e6de8fb22b078b1db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Users), @"mvc.1.0.view", @"/Views/Admin/Users.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/Users.cshtml", typeof(AspNetCore.Views_Admin_Users))]
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
#line 1 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\_ViewImports.cshtml"
using Mini_Facebook;

#line default
#line hidden
#line 2 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\_ViewImports.cshtml"
using Mini_Facebook.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42ceeb993ab8638d8d8bbf3e6de8fb22b078b1db", @"/Views/Admin/Users.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa35431dfe0ecfa80e9e838a89356ead2488f371", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Users : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<User>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-method", new global::Microsoft.AspNetCore.Html.HtmlString("get"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-update", new global::Microsoft.AspNetCore.Html.HtmlString("#upmodal"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-mode", new global::Microsoft.AspNetCore.Html.HtmlString("replace"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-success", new global::Microsoft.AspNetCore.Html.HtmlString("func()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(26, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
  
    ViewData["Title"] = "Users";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
            BeginContext(121, 77, true);
            WriteLiteral("\r\n<h2>Users</h2>\r\n<table class=\"table table-striped\">\r\n    <tr>\r\n        <td>");
            EndContext();
            BeginContext(199, 43, false);
#line 11 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
       Write(Html.DisplayNameFor(item => item.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(242, 19, true);
            WriteLiteral("</td>\r\n        <td>");
            EndContext();
            BeginContext(262, 39, false);
#line 12 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
       Write(Html.DisplayNameFor(item => item.Email));

#line default
#line hidden
            EndContext();
            BeginContext(301, 19, true);
            WriteLiteral("</td>\r\n        <td>");
            EndContext();
            BeginContext(321, 41, false);
#line 13 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
       Write(Html.DisplayNameFor(item => item.Deleted));

#line default
#line hidden
            EndContext();
            BeginContext(362, 108, true);
            WriteLiteral("</td>\r\n        <td>\r\n            Blocked / Unblocked\r\n        </td>\r\n        <td>Roles</td>\r\n\r\n    </tr>\r\n\r\n");
            EndContext();
#line 21 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
      
        int i = 0;

        foreach (var item in Model)
        {
            i++;

#line default
#line hidden
            BeginContext(566, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(605, 37, false);
#line 28 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
               Write(Html.DisplayFor(ele => item.UserName));

#line default
#line hidden
            EndContext();
            BeginContext(642, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(670, 34, false);
#line 29 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
               Write(Html.DisplayFor(ele => item.Email));

#line default
#line hidden
            EndContext();
            BeginContext(704, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(732, 36, false);
#line 30 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
               Write(Html.DisplayFor(ele => item.Deleted));

#line default
#line hidden
            EndContext();
            BeginContext(768, 67, true);
            WriteLiteral("</td>\r\n                <td>\r\n                    <div id=\"radio\">\r\n");
            EndContext();
#line 33 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
                         if (item.Deleted == true)
                        {

#line default
#line hidden
            BeginContext(912, 28, true);
            WriteLiteral("<label>  <input type=\"radio\"");
            EndContext();
            BeginWriteAttribute("name", " name=\"", 940, "\"", 958, 2);
            WriteAttributeValue("", 947, "Isactive_", 947, 9, true);
#line 34 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
WriteAttributeValue("", 956, i, 956, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(959, 11, true);
            WriteLiteral(" value=true");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 970, "\"", 986, 1);
#line 34 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
WriteAttributeValue("", 978, item.Id, 978, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(987, 82, true);
            WriteLiteral(" checked>Block</label>\r\n                            <label>    <input type=\"radio\"");
            EndContext();
            BeginWriteAttribute("name", " name=\"", 1069, "\"", 1087, 2);
            WriteAttributeValue("", 1076, "Isactive_", 1076, 9, true);
#line 35 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
WriteAttributeValue("", 1085, i, 1085, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1088, 12, true);
            WriteLiteral(" value=false");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1100, "\"", 1116, 1);
#line 35 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
WriteAttributeValue("", 1108, item.Id, 1108, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1117, 18, true);
            WriteLiteral(">UnBlock</label>\r\n");
            EndContext();
#line 36 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
                        }

#line default
#line hidden
            BeginContext(1162, 24, true);
            WriteLiteral("                        ");
            EndContext();
#line 37 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
                         if (item.Deleted == false)
                        {

#line default
#line hidden
            BeginContext(1242, 56, true);
            WriteLiteral("                            <label>  <input type=\"radio\"");
            EndContext();
            BeginWriteAttribute("name", " name=\"", 1298, "\"", 1316, 2);
            WriteAttributeValue("", 1305, "Isactive_", 1305, 9, true);
#line 39 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
WriteAttributeValue("", 1314, i, 1314, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1317, 11, true);
            WriteLiteral(" value=true");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1328, "\"", 1344, 1);
#line 39 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
WriteAttributeValue("", 1336, item.Id, 1336, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1345, 74, true);
            WriteLiteral(">Block</label>\r\n                            <label>    <input type=\"radio\"");
            EndContext();
            BeginWriteAttribute("name", " name=\"", 1419, "\"", 1437, 2);
            WriteAttributeValue("", 1426, "Isactive_", 1426, 9, true);
#line 40 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
WriteAttributeValue("", 1435, i, 1435, 2, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1438, 12, true);
            WriteLiteral(" value=false");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1450, "\"", 1466, 1);
#line 40 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
WriteAttributeValue("", 1458, item.Id, 1458, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1467, 26, true);
            WriteLiteral(" checked>UnBlock</label>\r\n");
            EndContext();
#line 41 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
                        }

#line default
#line hidden
            BeginContext(1520, 93, true);
            WriteLiteral("                    </div>\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1614, 17, false);
#line 45 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
               Write(ViewBag.rolLst[0]);

#line default
#line hidden
            EndContext();
            BeginContext(1631, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1698, 222, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "35f41fa428b748548f423bb57ae6aecb", async() => {
                BeginContext(1912, 4, true);
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
#line 48 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
                                           WriteLiteral(item.Id);

#line default
#line hidden
            WriteLiteral(" ");
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1920, 46, true);
            WriteLiteral("\r\n                </td>\r\n\r\n            </tr>\r\n");
            EndContext();
#line 54 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
        }

    

#line default
#line hidden
            BeginContext(1986, 12, true);
            WriteLiteral("</table>\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(2021, 377, true);
                WriteLiteral(@"
    <script>
        function func() { $(""#editmodal"").modal(""toggle""); }
        $('input[type=""radio""]').change(function (e)
        {
            console.log(e);
            var radioValue = $(this).val();
            var classVal = $(this).attr('class');
            console.log(radioValue);
            console.log(classVal);


            window.location = """);
                EndContext();
                BeginContext(2399, 28, false);
#line 72 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
                          Write(Url.Action("Block", "Admin"));

#line default
#line hidden
                EndContext();
                BeginContext(2427, 374, true);
                WriteLiteral(@"?usStat="" + radioValue + ""&uID="" + classVal ;
        });
        $("".hh"").change(function () {
            var Selval = $(this).find("":selected"").val();
            var classVal = $(this).find("":selected"").attr('class');
            alert(""your selected option is "" + Selval);
            alert(""your selected option is "" + classVal);
            window.location = """);
                EndContext();
                BeginContext(2802, 37, false);
#line 79 "E:\ITI SD\MVC\Mini-Facbook Project\Register+Login+Admin\Mini_Facebook\Mini_Facebook\Views\Admin\Users.cshtml"
                          Write(Url.Action("changeUserRole", "Admin"));

#line default
#line hidden
                EndContext();
                BeginContext(2839, 74, true);
                WriteLiteral("?usRol=\" + classVal + \"&uID=\" + classVal ;\r\n        });\r\n\r\n    </script>\r\n");
                EndContext();
            }
            );
            BeginContext(3135, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(4025, 712, true);
            WriteLiteral(@"

<!-- Modal -->
<div class=""modal fade"" id=""editmodal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Modal title</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div id=""upmodal"">


                </div>
            </div>
        </div>
    </div>
</div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<User>> Html { get; private set; }
    }
}
#pragma warning restore 1591