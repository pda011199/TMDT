#pragma checksum "D:\Bài tập\Thương mại điện tử\DoAn\DoAn\Views\Product\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da7b4c41da50eb5582b0aaeecb2ecb577aebde3a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Detail), @"mvc.1.0.view", @"/Views/Product/Detail.cshtml")]
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
#line 1 "D:\Bài tập\Thương mại điện tử\DoAn\DoAn\Views\_ViewImports.cshtml"
using DoAn;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Bài tập\Thương mại điện tử\DoAn\DoAn\Views\_ViewImports.cshtml"
using DoAn.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da7b4c41da50eb5582b0aaeecb2ecb577aebde3a", @"/Views/Product/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a83c55cd82221897cc1898333fffa30a9b06739", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DoAn.Models.Domain.SanPham>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Buy", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\Bài tập\Thương mại điện tử\DoAn\DoAn\Views\Product\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    Layout = "~/Views/Shared/_UserLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- breadcrumb start-->
<section class=""breadcrumb breadcrumb_bg"">
    <div class=""container"">
        <div class=""row justify-content-center"">
            <div class=""col-lg-12"">
                <div class=""breadcrumb_iner"">
                    <div class=""breadcrumb_iner_item"">
                        <p>Home/Shop/Single product</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- breadcrumb start-->

<div class=""product_image_area section_padding"">
    <div class=""container"">
        <div class=""row s_product_inner"">
            <div class=""col-lg-5"">
                <div class=""product_slider_img"">
                    <div id=""vertical"">
                        <div data-thumb=""~/images/");
#nullable restore
#line 29 "D:\Bài tập\Thương mại điện tử\DoAn\DoAn\Views\Product\Detail.cshtml"
                                             Write(Model.HinhAnh);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "da7b4c41da50eb5582b0aaeecb2ecb577aebde3a5580", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 971, "~/images/", 971, 9, true);
#nullable restore
#line 30 "D:\Bài tập\Thương mại điện tử\DoAn\DoAn\Views\Product\Detail.cshtml"
AddHtmlAttributeValue("", 980, Model.HinhAnh, 980, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-5 offset-lg-1\">\r\n                <div class=\"s_product_text\">\r\n                    <h3>");
#nullable restore
#line 38 "D:\Bài tập\Thương mại điện tử\DoAn\DoAn\Views\Product\Detail.cshtml"
                   Write(Html.DisplayFor(model => model.TenSp));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                    <h2>Giá bìa: ");
#nullable restore
#line 39 "D:\Bài tập\Thương mại điện tử\DoAn\DoAn\Views\Product\Detail.cshtml"
                            Write(Html.DisplayFor(model => model.Gia));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ</h2>\r\n                    <ul class=\"list\">\r\n                        <li>\r\n                            <a class=\"active\" href=\"#\">\r\n                                <span>Thể loại</span> : ");
#nullable restore
#line 43 "D:\Bài tập\Thương mại điện tử\DoAn\DoAn\Views\Product\Detail.cshtml"
                                                   Write(Html.DisplayFor(model => model.LoaiSp.TenLoaiSp));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </a>\r\n                        </li>\r\n                        <li>\r\n                            <a href=\"#\"> <span>Số lượng</span> : ");
#nullable restore
#line 47 "D:\Bài tập\Thương mại điện tử\DoAn\DoAn\Views\Product\Detail.cshtml"
                                                            Write(Html.DisplayFor(model => model.SoLuong));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </li>\r\n                    </ul>\r\n                    <p>\r\n                        ");
#nullable restore
#line 51 "D:\Bài tập\Thương mại điện tử\DoAn\DoAn\Views\Product\Detail.cshtml"
                   Write(Html.DisplayFor(model => model.Mota));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                    <div class=\"card_area\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "da7b4c41da50eb5582b0aaeecb2ecb577aebde3a9257", async() => {
                WriteLiteral("\r\n                            <input class=\"input-number\" type=\"number\" name=\"soLuong\" value=\"1\" min=\"1\"");
                BeginWriteAttribute("max", " max=\"", 2219, "\"", 2239, 1);
#nullable restore
#line 55 "D:\Bài tập\Thương mại điện tử\DoAn\DoAn\Views\Product\Detail.cshtml"
WriteAttributeValue("", 2225, Model.SoLuong, 2225, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 2303, "\"", 2322, 1);
#nullable restore
#line 56 "D:\Bài tập\Thương mại điện tử\DoAn\DoAn\Views\Product\Detail.cshtml"
WriteAttributeValue("", 2311, Model.MaSp, 2311, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            <input type=\"submit\" value=\"THÊM VÀO GIỎ HÀNG\" class=\"btn_3\"/>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 54 "D:\Bài tập\Thương mại điện tử\DoAn\DoAn\Views\Product\Detail.cshtml"
                                                                       WriteLiteral(Model.MaSp);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            WriteLiteral(@"                        <div class=""social_icon"">
                            <a href=""#"" class=""fb""><i class=""ti-facebook""></i></a>
                            <a href=""#"" class=""tw""><i class=""ti-twitter-alt""></i></a>
                            <a href=""#"" class=""li""><i class=""ti-linkedin""></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!--================End Single Product Area =================-->
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DoAn.Models.Domain.SanPham> Html { get; private set; }
    }
}
#pragma warning restore 1591
