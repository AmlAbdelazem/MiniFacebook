#pragma checksum "E:\MVC\MiniFacebook\Mini_Facebook\Views\UserHome\Posts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38e124deb7c8bae7e9e70ab57126e38d2c8dfd69"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserHome_Posts), @"mvc.1.0.view", @"/Views/UserHome/Posts.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/UserHome/Posts.cshtml", typeof(AspNetCore.Views_UserHome_Posts))]
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
#line 1 "E:\MVC\MiniFacebook\Mini_Facebook\Views\_ViewImports.cshtml"
using Mini_Facebook;

#line default
#line hidden
#line 2 "E:\MVC\MiniFacebook\Mini_Facebook\Views\_ViewImports.cshtml"
using Mini_Facebook.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38e124deb7c8bae7e9e70ab57126e38d2c8dfd69", @"/Views/UserHome/Posts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa35431dfe0ecfa80e9e838a89356ead2488f371", @"/Views/_ViewImports.cshtml")]
    public class Views_UserHome_Posts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Post>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteComment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-method", new global::Microsoft.AspNetCore.Html.HtmlString("Get"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-update", new global::Microsoft.AspNetCore.Html.HtmlString("#posts"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-mode", new global::Microsoft.AspNetCore.Html.HtmlString("replace"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddComment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-method", new global::Microsoft.AspNetCore.Html.HtmlString("Post"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(26, 70, true);
            WriteLiteral("\r\n\r\n    <div id=\"posts\">\r\n        <table style=\"margin-left:150px;\">\r\n");
            EndContext();
#line 6 "E:\MVC\MiniFacebook\Mini_Facebook\Views\UserHome\Posts.cshtml"
             foreach (var item in Model)
            {
                

#line default
#line hidden
#line 8 "E:\MVC\MiniFacebook\Mini_Facebook\Views\UserHome\Posts.cshtml"
                 if (item.Deleted == false)
                {

#line default
#line hidden
            BeginContext(217, 88, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 305, "\"", 343, 1);
#line 12 "E:\MVC\MiniFacebook\Mini_Facebook\Views\UserHome\Posts.cshtml"
WriteAttributeValue("", 311, Url.Content(item.User.PhotoSrc), 311, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(344, 107, true);
            WriteLiteral(" style=\"width:30px;height:30px;border-radius:50%\" />\r\n                            <a href=\"www.google.com\">");
            EndContext();
            BeginContext(452, 19, false);
#line 13 "E:\MVC\MiniFacebook\Mini_Facebook\Views\UserHome\Posts.cshtml"
                                                Write(item.User.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(471, 217, true);
            WriteLiteral("</a>\r\n                        </td>\r\n                    </tr>\r\n                    <tr style=\"border:1px solid blue;\">\r\n                        <td>\r\n                            <div style=\"width:300px;height:100px\">");
            EndContext();
            BeginContext(689, 9, false);
#line 18 "E:\MVC\MiniFacebook\Mini_Facebook\Views\UserHome\Posts.cshtml"
                                                             Write(item.Body);

#line default
#line hidden
            EndContext();
            BeginContext(698, 144, true);
            WriteLiteral("</div>\r\n                            <hr>\r\n                            <div style=\"margin-left:70px;\">\r\n                                <table>\r\n");
            EndContext();
#line 22 "E:\MVC\MiniFacebook\Mini_Facebook\Views\UserHome\Posts.cshtml"
                                     foreach (var com in item.Comments)
                                    {
                                        

#line default
#line hidden
#line 24 "E:\MVC\MiniFacebook\Mini_Facebook\Views\UserHome\Posts.cshtml"
                                         if (com.Deleted == false)
                                        {

#line default
#line hidden
            BeginContext(1065, 160, true);
            WriteLiteral("                                            <tr>\r\n                                                <td>\r\n                                                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1225, "\"", 1263, 1);
#line 28 "E:\MVC\MiniFacebook\Mini_Facebook\Views\UserHome\Posts.cshtml"
WriteAttributeValue("", 1231, Url.Content(item.User.PhotoSrc), 1231, 32, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1264, 114, true);
            WriteLiteral(" style=\"width:30px;height:30px;\" />\r\n                                                    <a href=\"www.google.com\">");
            EndContext();
            BeginContext(1379, 19, false);
#line 29 "E:\MVC\MiniFacebook\Mini_Facebook\Views\UserHome\Posts.cshtml"
                                                                        Write(item.User.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(1398, 293, true);
            WriteLiteral(@"</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div style=""height:20px"">");
            EndContext();
            BeginContext(1692, 8, false);
#line 34 "E:\MVC\MiniFacebook\Mini_Facebook\Views\UserHome\Posts.cshtml"
                                                                        Write(com.Body);

#line default
#line hidden
            EndContext();
            BeginContext(1700, 123, true);
            WriteLiteral("</div>\r\n                                                    <div>\r\n                                                        ");
            EndContext();
            BeginContext(1823, 157, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "626240fec7114490bf3249970ac3e5ce", async() => {
                BeginContext(1970, 6, true);
                WriteLiteral("Delete");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-ComID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 36 "E:\MVC\MiniFacebook\Mini_Facebook\Views\UserHome\Posts.cshtml"
                                                                                           WriteLiteral(com.ID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ComID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-ComID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["ComID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1980, 168, true);
            WriteLiteral("\r\n                                                    </div>\r\n                                                </td>\r\n                                            </tr>\r\n");
            EndContext();
#line 40 "E:\MVC\MiniFacebook\Mini_Facebook\Views\UserHome\Posts.cshtml"
                                        }
                                        else
                                        {
                                            continue;
                                        }

#line default
#line hidden
#line 44 "E:\MVC\MiniFacebook\Mini_Facebook\Views\UserHome\Posts.cshtml"
                                         
                                    }

#line default
#line hidden
            BeginContext(2417, 184, true);
            WriteLiteral("                                </table>\r\n                            </div>\r\n                            <div style=\"padding:15px;margin-left:60px;\">\r\n                                ");
            EndContext();
            BeginContext(2601, 566, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d303a5b8331b496b83e515607a666a88", async() => {
                BeginContext(2751, 409, true);
                WriteLiteral(@"
                                    <div class=""input-group"">
                                        <textarea name=""CommentBody"" class=""form-control"" placeholder=""write a Comment.."" style=""width:600px;height:50px""></textarea>
                                    </div>
                                    <input type=""submit"" value=""Comment"" class=""btn btn-success"" />
                                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-postid", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 49 "E:\MVC\MiniFacebook\Mini_Facebook\Views\UserHome\Posts.cshtml"
                                            WriteLiteral(item.ID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["postid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-postid", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["postid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3167, 96, true);
            WriteLiteral("\r\n                            </div>\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 58 "E:\MVC\MiniFacebook\Mini_Facebook\Views\UserHome\Posts.cshtml"
                }
                else
                {
                    continue;
                }

#line default
#line hidden
#line 62 "E:\MVC\MiniFacebook\Mini_Facebook\Views\UserHome\Posts.cshtml"
                 
            }

#line default
#line hidden
            BeginContext(3388, 30, true);
            WriteLiteral("        </table>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Post>> Html { get; private set; }
    }
}
#pragma warning restore 1591
