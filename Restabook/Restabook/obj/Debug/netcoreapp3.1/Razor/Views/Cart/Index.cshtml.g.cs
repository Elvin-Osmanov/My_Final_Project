#pragma checksum "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "97377886afc5ea891c152fbc0032b728bd0d72a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97377886afc5ea891c152fbc0032b728bd0d72a1", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20b0d07db7ca31679466ec39176f177bacc769c1", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Elvin\Desktop\Final Project\Restabook\Restabook\Views\Cart\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- section intro starts -->
<section id=""cart-intro"" style=""        background-image: url(~/../assets/images/cart/bg.jpg)"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-6 offset-lg-3"">
                <div class=""title text-center"">
                    <p>Order food with home delivery</p>
                    <h1 class=""text-white"">Your Cart</h1>
                    <div class=""dots"">
                        <ul class=""list-unstyled justify-content-center"">
                            <li>.</li>
                            <li>.</li>
                            <li>.</li>
                            <li>.</li>
                            <li>.</li>
                        </ul>
                    </div>
                </div>
                <div class=""scroll-down d-flex justify-content-center"">
                    <div class=""text-white mouse"">
                        <div class=""yellow-dot""></div>
                    </div>
                <");
            WriteLiteral(@"/div>
            </div>
        </div>
    </div>
    <div class=""section-footer"" style=""        background-image: url(~/../assets/images/section-footer/brush-dec.png);""></div>
</section>
<!-- section intro ends -->
<!-- section cart starts -->
<section id=""cart"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-8"">
                <div class=""table"">
                    <p>Your Cart <span>3 items</span></p>
                    <table class=""table table-bordered"">
                        <thead>
                            <tr>
                                <th scope=""col"" class=""bg-light"">Item</th>
                                <th scope=""col"">Description</th>
                                <th scope=""col"" class=""bg-light"">Price</th>
                                <th scope=""col"">Count</th>
                                <th scope=""col"" class=""bg-light"">Total</th>
                                <th scope=""col""></th>
                         ");
            WriteLiteral(@"   </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th scope=""row"" class=""p-1 text-center bg-light"">
                                    <img src=""./assets/images/menu/1.jpg""
                                         class=""img-fluid"" style=""width: 50px; height: auto;""");
            BeginWriteAttribute("alt", " alt=\"", 2500, "\"", 2506, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                </th>
                                <td>Grilled Steaks</td>
                                <td class=""bg-light"">
                                    $22
                                </td>
                                <td><input type=""number"" style=""border: 0;width: 35px;"" value=""1""></td>
                                <td class=""bg-light"">$22.00</td>
                                <td><i class=""fas fa-times remove-btn""></i></td>
                            </tr>
                            <tr>
                                <th scope=""row"" class=""p-1 text-center bg-light"">
                                    <img src=""./assets/images/menu/2.jpg""
                                         class=""img-fluid"" style=""width: 50px; height: auto;""");
            BeginWriteAttribute("alt", " alt=\"", 3314, "\"", 3320, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                </th>
                                <td>Grilled Steaks</td>
                                <td class=""bg-light"">
                                    $22
                                </td>
                                <td><input type=""number"" style=""border: 0;width: 35px;"" value=""1""></td>
                                <td class=""bg-light"">$22.00</td>
                                <td><i class=""fas fa-times remove-btn""></i></td>
                            </tr>
                            <tr>
                                <th scope=""row"" class=""p-1 text-center bg-light"">
                                    <img src=""./assets/images/menu/3.jpg""
                                         class=""img-fluid"" style=""width: 50px; height: auto;""");
            BeginWriteAttribute("alt", " alt=\"", 4128, "\"", 4134, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                </th>
                                <td>Grilled Steaks</td>
                                <td class=""bg-light"">
                                    $22
                                </td>
                                <td><input type=""number"" style=""border: 0;width: 35px;"" value=""1""></td>
                                <td class=""bg-light"">$22.00</td>
                                <td><i class=""fas fa-times remove-btn""></i></td>
                            </tr>

                        </tbody>
                    </table>
                </div>
                <div class=""apply d-flex justify-content-between mt-5"">
                    <div class=""coupon d-flex"">
                        <input class=""form-control"" type=""text"" placeholder=""Coupon code""> <a href=""#""
                                                                                              class=""apply-btn btn"">Apply</a>
                    </div>
                    <a href=""#""");
            WriteLiteral(@" class=""update-btn btn"">Update Cart</a>
                </div>
            </div>
            <div class=""col-lg-4"">
                <div class=""totals"">
                    <div class=""total-inner"">
                        <h5>Cart totals</h5>
                        <ul class=""list-unstyled"">
                            <li class=""d-flex justify-content-between"">
                                <p>Cart Subtotal:</p><span>$240.00</span>
                            </li>
                            <li class=""d-flex justify-content-between"">
                                <p>Shipping Total:</p><span>$12.00</span>
                            </li>
                            <li class=""d-flex justify-content-between"">
                                <p>Total:</p><span>$252.00</span>
                            </li>
                        </ul>
                        <div class=""proceed"">
                            <a");
            BeginWriteAttribute("href", " href=\"", 6112, "\"", 6119, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""proceed-btn"">Proceed to Checkout</a>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <div class=""section-footer"" style=""background-image: url(~/../assets/images/section-footer/brush-dec_2.png);"">
    </div>
</section>
<!-- section cart ends -->
");
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
