#pragma checksum "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b8c4f1359c0990aacff248b22489ad1e9c78736"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Product_Delete), @"mvc.1.0.view", @"/Areas/Manage/Views/Product/Delete.cshtml")]
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
#line 1 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\_ViewImports.cshtml"
using Restabook.Areas.Manage.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\_ViewImports.cshtml"
using Restabook.Data.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\_ViewImports.cshtml"
using Restabook.Data.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b8c4f1359c0990aacff248b22489ad1e9c78736", @"/Areas/Manage/Views/Product/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fe8eff951cc74225ede8d790da0f6eff90491cb", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Product_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("max-width:150px;margin-right:10px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("slider"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mt-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
  
    ViewData["Title"] = "Delete";
    Layout = "~/Areas/Manage/Views/Shared/_Layout.cshtml";
    List<Tag> tags = ViewBag.Tags;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <h2>Detail</h2>
    <div class=""card-group"">
        <div class=""card pl-3"">
            <div class=""inner pl-3 pt-2"">
             
               

                <p>Photos</p>
                <div class=""images d-flex"">
");
#nullable restore
#line 18 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
                     foreach (var item in Model.ProductPhotos)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1b8c4f1359c0990aacff248b22489ad1e9c787366656", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 545, "~/uploads/products/", 545, 19, true);
#nullable restore
#line 20 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
AddHtmlAttributeValue("", 564, item.Name, 564, 10, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 21 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\">Title: ");
#nullable restore
#line 25 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
                                         Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <p class=\"card-text\">Desc: ");
#nullable restore
#line 26 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
                                      Write(Html.Raw(Model.Desc));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Small Desc: ");
#nullable restore
#line 27 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
                                            Write(Model.SmallDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Rate: ");
#nullable restore
#line 28 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
                                      Write(Model.Rate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Price: ");
#nullable restore
#line 29 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
                                       Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Discounted Price: ");
#nullable restore
#line 30 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
                                                  Write(Model.DiscountedPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Discount Percent: ");
#nullable restore
#line 31 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
                                                  Write(Model.DiscountPercent);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Is Chef Selecetion: ");
#nullable restore
#line 32 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
                                                    Write(Model.IsChefSelecetion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\"> Has Seen: ");
#nullable restore
#line 33 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
                                           Write(Model.HasSeen);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Has Shopped: ");
#nullable restore
#line 34 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
                                             Write(Model.HasShopped);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Category: ");
#nullable restore
#line 35 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
                                          Write(Model.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <div class=\"card-text bg-light\" style=\"border-radius:5px\">\r\n                    Tags:\r\n\r\n");
#nullable restore
#line 39 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
                     foreach (var item in tags)
                    {
                        if (tags[tags.Count - 1] != item)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<p class=\"d-inline\">");
#nullable restore
#line 42 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
                                        Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(",</p> ");
#nullable restore
#line 42 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
                                                             }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<p class=\"d-inline\">");
#nullable restore
#line 44 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
                                    Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>");
#nullable restore
#line 44 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
                                                       }

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b8c4f1359c0990aacff248b22489ad1e9c7873614234", async() => {
                WriteLiteral("\r\n        <input name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 2113, "\"", 2130, 1);
#nullable restore
#line 55 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Product\Delete.cshtml"
WriteAttributeValue("", 2121, Model.Id, 2121, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" hidden />\r\n        <button type=\"submit\" class=\"btn btn-outline-danger\"> Delete</button>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
