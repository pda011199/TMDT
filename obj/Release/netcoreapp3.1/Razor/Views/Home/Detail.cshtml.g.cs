#pragma checksum "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4e29d4a294912c07a761886178315945deaddf27"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Detail), @"mvc.1.0.view", @"/Views/Home/Detail.cshtml")]
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
#line 1 "D:\Bài tập\Thương mại điện tử\ghj\Views\_ViewImports.cshtml"
using DoAn;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Bài tập\Thương mại điện tử\ghj\Views\_ViewImports.cshtml"
using DoAn.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e29d4a294912c07a761886178315945deaddf27", @"/Views/Home/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a83c55cd82221897cc1898333fffa30a9b06739", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DoAn.Models.Domain.SanPham>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Buy", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color: white; border: 1px solid #0A98C0; background-color: #0A98C0; font-weight: bold;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
  
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
#line 29 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                                             Write(Model.HinhAnh);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "4e29d4a294912c07a761886178315945deaddf277048", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 971, "~/images/", 971, 9, true);
#nullable restore
#line 30 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
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
#line 38 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                   Write(Html.DisplayFor(model => model.TenSp));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                    <h2>Giá bìa: ");
#nullable restore
#line 39 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                            Write(Html.DisplayFor(model => model.Gia));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ</h2>\r\n                    <ul class=\"list\">\r\n                        <li>\r\n                            <a class=\"active\" href=\"#\">\r\n                                <span>Thể loại</span> : ");
#nullable restore
#line 43 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                                                   Write(Html.DisplayFor(model => model.LoaiSp.TenLoaiSp));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </a>\r\n                        </li>\r\n                        <li>\r\n");
#nullable restore
#line 47 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                             if (@Model.SoLuong == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a href=\"#\"> <span>Số lượng</span> : HẾT HÀNG</a>\r\n");
#nullable restore
#line 50 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a href=\"#\"> <span>Số lượng</span> : ");
#nullable restore
#line 53 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                                                                Write(Html.DisplayFor(model => model.SoLuong));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 54 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </li>\r\n                    </ul>\r\n                    <hr />\r\n                    <h3>Mô tả sản phẩm</h3>\r\n                    <p>                        \r\n                        ");
#nullable restore
#line 61 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                   Write(Html.DisplayFor(model => model.Mota));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                    <div class=\"card_area\">\r\n");
#nullable restore
#line 64 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                         if (@Model.SoLuong == 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a class=\"btn_3\" href=\"#\" style=\"background: red\">CHÁY HÀNG</a>\r\n");
#nullable restore
#line 67 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e29d4a294912c07a761886178315945deaddf2712206", async() => {
                WriteLiteral("\r\n                                <input class=\"input-number\" type=\"number\" name=\"soLuong\" value=\"1\" min=\"1\"");
                BeginWriteAttribute("max", " max=\"", 2881, "\"", 2901, 1);
#nullable restore
#line 71 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
WriteAttributeValue("", 2887, Model.SoLuong, 2887, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 2969, "\"", 2988, 1);
#nullable restore
#line 72 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
WriteAttributeValue("", 2977, Model.MaSp, 2977, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                                <input type=\"submit\" value=\"THÊM VÀO GIỎ HÀNG\" class=\"btn_3\" />\r\n                            ");
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
#line 70 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
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
#nullable restore
#line 75 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </div>

                </div>

            </div>

        </div>
    </div>
</div>

<!--================Product Description Area =================-->
<section class=""product_description_area"">
    <div class=""container"">
        <ul class=""nav nav-tabs"" id=""myTab"" role=""tablist"">
            <li class=""nav-item"">
                <a class=""nav-link active"" id=""review-tab"" data-toggle=""tab"" href=""#review"" role=""tab"" aria-controls=""review""
                   aria-selected=""false"">BÌNH LUẬN</a>
            </li>
        </ul>
        <div class=""tab-content"" id=""myTabContent"">
            <div class=""tab-pane fade show active"" id=""review"" role=""tabpanel"" aria-labelledby=""review-tab"">
                <div class=""row"">
                    <div class=""col-lg-6"">

                        <div class=""review_list"">
");
#nullable restore
#line 101 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                             foreach (var a in ViewBag.dsdanhgia)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"review_item\">\r\n                                    <div class=\"media\">\r\n                                        <div class=\"media-body\">\r\n                                            <p class=\"text-muted\"> ");
#nullable restore
#line 106 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                                                              Write(a.Ngay.ToString("dd/MM/yyyy hh:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n");
#nullable restore
#line 107 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                                             for (int i = 0; i < @a.Rating; i++)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <i class=\"ratingStar fas fa-star\" style=\"color:#fd9727\"></i>");
#nullable restore
#line 109 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                                                                                                            ;
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 111 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                                             for (int i = @a.Rating; i < 5; i++)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <i class=\"ratingStar fas fa-star\" style=\"color:#dedddd\"></i>");
#nullable restore
#line 113 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                                                                                                            ;
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </div>\r\n                                    </div>\r\n                                    <p style=\"font-size:17px; color:black; font-weight:bold\">");
#nullable restore
#line 117 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                                                                                        Write(a.User.HoTen);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    <p style=\"font-size:15px;\">");
#nullable restore
#line 118 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                                                          Write(a.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                </div>\r\n");
#nullable restore
#line 120 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"col-lg-6\">\r\n                        <div class=\"review_box\">\r\n");
#nullable restore
#line 126 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                             if (User.Identity.IsAuthenticated)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <h4 style=\"font-weight: bold\">Thêm bình luận của bạn</h4>\r\n");
#nullable restore
#line 129 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                                 using (Html.BeginForm("CreateCmt", "Home", FormMethod.Post, new { onsubmit = "return VerifyRating()" }))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 5907, "\"", 5926, 1);
#nullable restore
#line 131 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
WriteAttributeValue("", 5915, Model.MaSp, 5915, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" name=""maSp"" />
                                    <div class=""form-group"">
                                        <div onmouseout=""CrateSelected()"">
                                            <p>Đánh giá:</p>
                                            <span class=""text-warning"">
                                                <i id=""span1"" onmouseout=""CrateOut(1)"" onmouseover=""CrateOver(1)"" onclick=""CrateClick(1)"" class=""ratingStar far fa-star""></i>
                                                <i id=""span2"" onmouseout=""CrateOut(2)"" onmouseover=""CrateOver(2)"" onclick=""CrateClick(2)"" class=""ratingStar far fa-star""></i>
                                                <i id=""span3"" onmouseout=""CrateOut(3)"" onmouseover=""CrateOver(3)"" onclick=""CrateClick(3)"" class=""ratingStar far fa-star""></i>
                                                <i id=""span4"" onmouseout=""CrateOut(4)"" onmouseover=""CrateOver(4)"" onclick=""CrateClick(4)"" class=""ratingStar far fa-star""></i>
                                  ");
            WriteLiteral(@"              <i id=""span5"" onmouseout=""CrateOut(5)"" onmouseover=""CrateOver(5)"" onclick=""CrateClick(5)"" class=""ratingStar far fa-star""></i>
                                            </span>
                                        </div>
                                        <br />
                                        <textarea rows=""8"" name=""comment"" class=""form-control"" placeholder=""Viết bình luận ở đây."" required></textarea>
                                    </div>
                                    <input type=""submit"" class=""btn btn-success"" value=""BÌNH LUẬN"" style=""border: 1px solid #0A98C0;
                                                                                                                    border-radius: 0;
                                                                                                                    background-color: white;
                                                                                                                    font-weigh");
            WriteLiteral(@"t: bold;
                                                                                                                    color: #0A98C0;
                                                                                                                    padding: 13px 19px"" />
                                    <div>
                                        <input type=""hidden"" name=""rating"" id=""lblRating"" value=""0"" />
                                    </div>
");
#nullable restore
#line 155 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 155 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                                 


                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <h4 style=\"font-weight: bold\">Bạn chưa đăng nhập! Hãy đăng nhập để bình luận.</h4>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4e29d4a294912c07a761886178315945deaddf2725097", async() => {
                WriteLiteral("ĐĂNG NHẬP");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 163 "D:\Bài tập\Thương mại điện tử\ghj\Views\Home\Detail.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!--================End Product Description Area =================-->
<!--================End Single Product Area =================-->
<script type=""text/javascript"">
    function CrateOut(rating) {
        for (var i = 1; i <= rating; i++) {
            $(""#span"" + i).attr('class', 'far fa-star');
        }
    }
    function CrateOver(rating) {
        for (var i = 1; i <= rating; i++) {
            $(""#span"" + i).attr('class', 'fas fa-star');
        }
    }
    function CrateClick(rating) {
        $(""#lblRating"").val(rating);
        for (var i = 1; i <= rating; i++) {
            $(""#span"" + i).attr('class', 'fas fa-star');
        }
        for (var i = rating + 1; i <= 5; i++) {
            $(""#span"" + i).attr('class', 'far fa-star');
        }
    }
    function CrateSelected() {
        var rating = $(""#lblRating"").val();
        for ");
            WriteLiteral(@"(var i = 1; i <= rating; i++) {
            $(""#span"" + i).attr('class', 'fas fa-star');
        }
    }
    function VerifyRating() {
        var rating = $(""#lblRating"").val();
        if (rating == ""0"") {
            alert(""chưa đánh giá chất lượng sản phẩm."");
            return false;
        }
    }
</script>");
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
