#pragma checksum "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20824c78be900117d13d1f7eca291c68080ad323"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_CheckBill), @"mvc.1.0.view", @"/Views/Cart/CheckBill.cshtml")]
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
#line 1 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\_ViewImports.cshtml"
using DoAn;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\_ViewImports.cshtml"
using DoAn.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20824c78be900117d13d1f7eca291c68080ad323", @"/Views/Cart/CheckBill.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a83c55cd82221897cc1898333fffa30a9b06739", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_CheckBill : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DoAn.Models.Domain.User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row contact_form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
  
    ViewData["Title"] = "CheckBill";
    Layout = "~/Views/Shared/_UserLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section class=""breadcrumb breadcrumb_bg"">
    <div class=""container"">
        <div class=""row justify-content-center"">
            <div class=""col-lg-12"">
                <div class=""breadcrumb_iner"">
                    <div class=""breadcrumb_iner_item"">
                        <p>Home / checkout</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- breadcrumb end-->
<!--================Checkout Area =================-->
<section class=""checkout_area section_padding"">
    <div class=""container"">
        <h3>THANH TOÁN</h3>
        <hr />
        <div class=""billing_details"">
            <div class=""row"">
                <div class=""col-lg-6"">

                    <div class=""order_box"">
                        <h2>THÔNG TIN THANH TOÁN</h2>
                        <ul class=""list"">
                            <li>
                                <a href=""#"">HỌ TÊN <span>");
#nullable restore
#line 33 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
                                                    Write(ViewBag.user.HoTen);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></a>\r\n                            </li>\r\n                            <li>\r\n                                <a href=\"#\">EMAIL <span>");
#nullable restore
#line 36 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
                                                   Write(ViewBag.user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></a>\r\n                            </li>\r\n                            <li>\r\n                                <a href=\"#\">SĐT <span>");
#nullable restore
#line 39 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
                                                 Write(ViewBag.user.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></a>\r\n                            </li>\r\n                            <li>\r\n                                <a href=\"#\">ĐỊA CHỈ <span>");
#nullable restore
#line 42 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
                                                     Write(ViewBag.user.DiaChi);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></a>\r\n                            </li>\r\n                        </ul>\r\n                    </div>\r\n                    <div class=\"order_box\">\r\n                        <h3>MÃ COUPON</h3>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20824c78be900117d13d1f7eca291c68080ad3236910", async() => {
                WriteLiteral(@"
                            <div class=""col-md-6 form-group "">
                                <input type=""text"" class=""form-control"" name=""maKhuyenmai"" id=""maKhuyenMai"" placeholder=""Mã Khuyến Mãi"" />
                                <p id=""couponNotification""></p>
                            </div>
                            <div class=""col-md-6 form-group"">
                                <a href=""#"" class=""btn btn-light"" id=""btn-maKhuyenMai"">Áp dụng mã</a>
                                <a href=""#"" class=""btn btn-danger"" id=""btn-huyMaKhuyenMai"" style=""display:none"">Hủy</a>
                            </div>

                            <button type=""submit"" class=""btn_3"">ĐẶT MUA</button>
                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 48 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
                                                      WriteLiteral(ViewBag.action);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-action", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                    
                </div>
                <div class=""col-lg-6"">
                    <div class=""order_box"">
                        <h2>NỘI DUNG GIỎ HÀNG</h2>
                        <ul class=""list"">
                            <li>
                                <a href=""#"">
                                    Sản phẩm
                                    <span>Giá</span>
                                </a>
                            </li>
");
#nullable restore
#line 73 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
                             foreach (var item in ViewBag.cart)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li>\r\n                                    <a href=\"#\">\r\n                                        ");
#nullable restore
#line 77 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
                                   Write(item.SanPham.TenSp);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        <span class=\"middle\">x ");
#nullable restore
#line 78 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
                                                          Write(item.SoLuong);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                        <span class=\"last\">");
#nullable restore
#line 79 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
                                                      Write(item.SanPham.Gia);

#line default
#line hidden
#nullable disable
            WriteLiteral(" đ</span>\r\n                                    </a>\r\n                                </li>\r\n");
#nullable restore
#line 82 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </ul>\r\n");
#nullable restore
#line 84 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
                         foreach (var item in ViewBag.cart)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <ul class=\"list list_2\">\r\n                                <li>\r\n                                    <a href=\"#\">\r\n                                        Tạm tính\r\n                                        <span>");
#nullable restore
#line 90 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
                                          Write(item.SanPham.Gia * item.SoLuong);

#line default
#line hidden
#nullable disable
            WriteLiteral(" đ</span>\r\n                                    </a>\r\n");
#nullable restore
#line 92 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
                                     if (item.SanPham.GiamGia != 0)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a href=\"#\" class=\"product-sale\">\r\n");
            WriteLiteral("                                            Giảm giá\r\n                                            <span class=\"last\">");
#nullable restore
#line 97 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
                                                          Write(item.SanPham.GiamGia);

#line default
#line hidden
#nullable disable
            WriteLiteral(" đ</span>\r\n                                        </a>\r\n");
#nullable restore
#line 99 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </li>\r\n                            </ul>\r\n");
#nullable restore
#line 102 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <ul class=\"list list_2\">\r\n                            <li>\r\n                                <a href=\"#\">\r\n                                    VAT\r\n                                    <span>");
#nullable restore
#line 107 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
                                     Write(ViewBag.vat);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" đ</span>
                                </a>
                            </li>
                        </ul>
                        <ul class=""list list_2"" id=""detailCoupon"" style=""display:none"">
                            <li>
                                <a href=""#"">
                                    Mã giảm giá
                                    <span><label id=""coupon"">0</label> đ</span>
                                    <input type=""number"" id=""oldCoupon"" value=""0"" hidden />
                                </a>
                            </li>
                        </ul>

                        <ul class=""list list_2"">
                            <li>
                                <a href=""#"">
                                    Tổng đơn
");
            WriteLiteral("                                    <span><label id=\"total\">");
#nullable restore
#line 126 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
                                                       Write(ViewBag.total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label> đ</span>\r\n                                    <input type=\"number\" id=\"oldTotal\"");
            BeginWriteAttribute("value", " value=", 5964, "", 5985, 1);
#nullable restore
#line 127 "D:\Study\4TH YEAR\Thương mại điện tử\New folder\TMDT\Views\Cart\CheckBill.cshtml"
WriteAttributeValue("", 5971, ViewBag.total, 5971, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" hidden />
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>

            </div>
        </div>
    </div>
</section>
<!--================End Checkout Area =================-->
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DoAn.Models.Domain.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
