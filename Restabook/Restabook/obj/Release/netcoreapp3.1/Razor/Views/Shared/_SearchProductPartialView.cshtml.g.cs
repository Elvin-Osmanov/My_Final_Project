#pragma checksum "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Views\Shared\_SearchProductPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa7f27769729bdc1aa0c8d1a39eb5b188666529b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SearchProductPartialView), @"mvc.1.0.view", @"/Views/Shared/_SearchProductPartialView.cshtml")]
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
#line 1 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Views\_ViewImports.cshtml"
using Restabook;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Views\_ViewImports.cshtml"
using Restabook.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Views\_ViewImports.cshtml"
using Restabook.Data.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Views\_ViewImports.cshtml"
using Restabook.Data.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa7f27769729bdc1aa0c8d1a39eb5b188666529b", @"/Views/Shared/_SearchProductPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65622561d8f6ff86be1824ed816334fddc74321e", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SearchProductPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Views\Shared\_SearchProductPartialView.cshtml"
 foreach (Product product in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li style=\"display:flex\">\r\n        <a");
            BeginWriteAttribute("href", " href=\"", 83, "\"", 116, 2);
            WriteAttributeValue("", 90, "/Product/Index/", 90, 15, true);
#nullable restore
#line 5 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Views\Shared\_SearchProductPartialView.cshtml"
WriteAttributeValue("", 105, product.Id, 105, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 5 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Views\Shared\_SearchProductPartialView.cshtml"
                                        Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n    </li>\r\n");
#nullable restore
#line 7 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Views\Shared\_SearchProductPartialView.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
