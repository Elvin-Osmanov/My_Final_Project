#pragma checksum "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d98bc06154c1f45b3395d12db191bd55bff63ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Reservation_Index), @"mvc.1.0.view", @"/Areas/Manage/Views/Reservation/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d98bc06154c1f45b3395d12db191bd55bff63ed", @"/Areas/Manage/Views/Reservation/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fe8eff951cc74225ede8d790da0f6eff90491cb", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Reservation_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ReservationViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-page", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("tabindex", new global::Microsoft.AspNetCore.Html.HtmlString("-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
   ViewData["Title"] = "Index";
    Layout = "~/Areas/Manage/Views/Shared/_Layout.cshtml";
    int pageCount = ViewBag.PageCount;
    int selectedPage = ViewBag.SelectedPage;
    int counter = (selectedPage - 1) * 4 + 1; 
    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""d-flex justify-content-end mb-2"">
       

    </div>
    <table class=""table"">
        <thead>
            <tr>
                <th scope=""col"">#</th>
                <th scope=""col"">Fullname</th>
                <th scope=""col"">ReservationDate</th>
                <th scope=""col"">ReservationTime</th>
                <th scope=""col"">PhoneNumber</th>
                <th scope=""col"">EmailAddress</th>
                <th scope=""col"">Status</th>



                <th scope=""col""></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 31 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
             foreach (var item in Model.Reservations)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th scope=\"row\">");
#nullable restore
#line 34 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
                           Write(counter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <td>");
#nullable restore
#line 35 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
               Write(item.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 36 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
               Write(item.ReservationDate.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 37 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
               Write(item.ReservationTime.ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 38 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
               Write(item.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 39 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
               Write(item.EmailAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 40 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
               Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n                <td>\r\n\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d98bc06154c1f45b3395d12db191bd55bff63ed8846", async() => {
                WriteLiteral("Edit");
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
#line 45 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
                                           WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 49 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
                counter++;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </tbody>\r\n    </table>\r\n    <nav aria-label=\"Page navigation example\">\r\n        <ul class=\"pagination justify-content-center\">\r\n");
#nullable restore
#line 57 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
             if (selectedPage > 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"page-item \">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d98bc06154c1f45b3395d12db191bd55bff63ed11892", async() => {
                WriteLiteral(" <i class=\"fas fa-angle-double-left\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </li>\r\n                <li class=\"page-item \">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d98bc06154c1f45b3395d12db191bd55bff63ed13772", async() => {
                WriteLiteral("<i class=\"fas fa-angle-left\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
                                                                 WriteLiteral(selectedPage-1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </li>\r\n");
#nullable restore
#line 65 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 67 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
             for (int i = (selectedPage - 2 < 1 ? 1 : selectedPage - 2); i <= (selectedPage + 2 > pageCount ? pageCount : selectedPage + 2); i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li");
            BeginWriteAttribute("class", " class=\"", 2305, "\"", 2353, 2);
            WriteAttributeValue("", 2313, "page-item", 2313, 9, true);
#nullable restore
#line 69 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
WriteAttributeValue(" ", 2322, i==selectedPage?"active":"", 2323, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d98bc06154c1f45b3395d12db191bd55bff63ed17223", async() => {
#nullable restore
#line 69 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
                                                                                                                            Write(i);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 69 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
                                                                                                                 WriteLiteral(i);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 70 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 71 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
             if (selectedPage < pageCount)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"page-item\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d98bc06154c1f45b3395d12db191bd55bff63ed20367", async() => {
                WriteLiteral("\r\n                        <i class=\"fas fa-angle-right\"></i>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 74 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
                                                                 WriteLiteral(selectedPage+1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </li>\r\n                <li class=\"page-item\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d98bc06154c1f45b3395d12db191bd55bff63ed22916", async() => {
                WriteLiteral("\r\n                        <i class=\"fas fa-angle-double-right\"></i>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 79 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
                                                                WriteLiteral(pageCount);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </li>\r\n");
#nullable restore
#line 83 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Areas\Manage\Views\Reservation\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </nav>\r\n\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ReservationViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591