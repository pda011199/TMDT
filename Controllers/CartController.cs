using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoAn.Models.Domain;
using DoAn.Helper;
using DoAn.Models;
using Microsoft.AspNetCore.Identity;
using DoAn.Models.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using PayPal.Core;
using PayPal.v1.Payments;
using BraintreeHttp;
using Microsoft.AspNetCore.Routing;

namespace DoAn.Controllers
{

    public class CartController : Controller
    {
        private readonly DataContext data;
        private readonly UserManager<User> userManager;
        private readonly ISendMailService sendMailService;
        private readonly string _clientId;
        private readonly string _secretKey;
        public double TyGiaUSD = 23300;
        public string format = "dd/MM/yyyy";

        public CartController(DataContext data, UserManager<User> userManager, ISendMailService sendMailService, IConfiguration config)
        {
            this.data = data;
            this.userManager = userManager;
            this.sendMailService = sendMailService;
            _clientId = config["PaypalSettings:ClientID"];
            _secretKey = config["PaypalSettings:SecretKey"];
        }
        public IActionResult Index()
        {
            if(SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart") != null)
            {
                var cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => (item.SanPham.Gia - item.SanPham.GiamGia) * item.SoLuong);
            }    
            return View();
        }
        [Route("buy/{id}")]
        public IActionResult Buy(int id, int soLuong)
        {
            if(SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session,"cart")==null)
            {
                List<ProductToCart> cart = new List<ProductToCart>();
                cart.Add(new ProductToCart { SanPham = data.SanPham.FirstOrDefault(p => p.MaSp == id), SoLuong = soLuong });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<ProductToCart> cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if(index != -1)
                {
                    cart[index].SoLuong += soLuong;
                }
                else
                {
                    cart.Add(new ProductToCart { SanPham = data.SanPham.FirstOrDefault(p => p.MaSp == id), SoLuong = soLuong });

                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<ProductToCart> cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<ProductToCart> cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            for(int i = 0;i< cart.Count;i++)
            {
                if (cart[i].SanPham.MaSp == id)
                    return i;
            }
            return -1;
        }

        [Route("update/{id}")]
        public IActionResult Update(int id, int soLuong)
        {
            List<ProductToCart> cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart[index].SoLuong = soLuong;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        public IActionResult AddInformation()
        {
            var cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            double sum = cart.Sum(item => (item.SanPham.Gia - item.SanPham.GiamGia) * item.SoLuong);
            double vat = cart.Sum(item => item.SanPham.Gia * item.SoLuong) / 10;
            ViewBag.cart = cart;
            ViewBag.total = sum + vat;
            ViewBag.vat = vat;
            return View();
        }

        public async Task<IActionResult> CheckOutWithSignInAsync(string maKhuyenMai=null)
        {
            User user = await userManager.GetUserAsync(User);
            if (SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart") != null)
            {
                var cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
                double tamtinh = cart.Sum(item => (item.SanPham.Gia - item.SanPham.GiamGia) * item.SoLuong);
                double vat = cart.Sum(item => item.SanPham.Gia * item.SoLuong) / 10;
                var tongtien = tamtinh + vat;
                if (maKhuyenMai != null)
                {
                    var mkm = data.MaKhuyenMai.Find(maKhuyenMai);
                    tongtien = (tongtien * (100 - mkm.GiaTri)) / 100;
                }
                //tao hoa don
                HoaDon hd = new HoaDon
                {
                    HoTen = user.HoTen,
                    DiaChi = user.DiaChi,
                    UserId = user.Id,
                    SDT = user.PhoneNumber,
                    Email = user.Email,
                    TamTinh = tamtinh,
                    TongTien = tongtien,
                    Ngay = DateTime.Today,
                    GiaoHang = 1,
                    LoaiTT = 1,
                    VAT = vat,
                    TinhTrang = false,
                    MaKhuyenMai = maKhuyenMai
                };
                data.HoaDon.Add(hd);
                data.SaveChanges();
                foreach (var item in cart)
                {
                    //Tao chi tiet hoa don 
                    CT_HoaDon cthd = new CT_HoaDon
                    {
                        MaHD = hd.MaHD,
                        MaSp = item.SanPham.MaSp,
                        SoLuong = item.SoLuong
                    };
                    //Update so luong cua san pham
                    var sp = data.SanPham.Find(item.SanPham.MaSp);
                    sp.SoLuong -= item.SoLuong;
                    data.Entry(sp).State = EntityState.Modified;
                    data.CTHoaDon.Add(cthd);
                    data.SaveChanges();
                }
                //user.DiemTichLuy = (int)(hd.TamTinh / 10000);
                //await userManager.UpdateAsync(user);
                await SendMailAsync(user.HoTen, user.Email, hd);
            }
            return RedirectToAction(nameof(HomeController.Index),"Home");
        }

        public async Task<IActionResult> CheckOutWithoutSignInAsync(string hoTen, string diaChi, string sDT, string eMail, string maKhuyenMai)
        {
            if (SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart") != null)
            {
                var cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");

                double tamtinh = cart.Sum(item => (item.SanPham.Gia - item.SanPham.GiamGia) * item.SoLuong);
                double vat = cart.Sum(item => item.SanPham.Gia * item.SoLuong)/10;
                var tongtien = tamtinh + vat;
                if(maKhuyenMai != null)
                {
                    var mkm = data.MaKhuyenMai.Find(maKhuyenMai);
                    tongtien = (tongtien * (100 - mkm.GiaTri)) / 100;
                }    
                //tao hoa don
                HoaDon hd = new HoaDon
                {
                    HoTen = hoTen,
                    DiaChi = diaChi,
                    SDT = sDT,
                    Email = eMail,
                    TamTinh = tamtinh,
                    TongTien = tongtien,
                    Ngay = DateTime.Today,
                    GiaoHang = 1,
                    LoaiTT = 1,
                    VAT = vat ,
                    TinhTrang = false,
                    MaKhuyenMai = maKhuyenMai
                };
                data.HoaDon.Add(hd);
                data.SaveChanges();
                foreach (var item in cart)
                {
                    //Tao chi tiet hoa don 
                    CT_HoaDon cthd = new CT_HoaDon
                    {
                        MaHD = hd.MaHD,
                        MaSp = item.SanPham.MaSp,
                        SoLuong = item.SoLuong
                    };
                    //Update so luong cua san pham
                    var sp = data.SanPham.Find(item.SanPham.MaSp);
                    sp.SoLuong -= item.SoLuong;
                    data.Entry(sp).State = EntityState.Modified;
                    data.CTHoaDon.Add(cthd);
                    data.SaveChanges();
                }
                await SendMailAsync(hoTen, eMail, hd);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private async Task SendMailAsync(string hoTen, string eMail, HoaDon hd)
        {
            if (SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart") != null)
            {
                var cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");

                string s = "<table>" + "<tr><th>Tên sản phẩm</th>" +
                    "<th>Số lượng</th>" +
                    "<th>Giá</th>" +
                    "<th>Thành tiền</th></tr><tr>";
                foreach (var item in cart)
                {
                    s = s + "<td>" + item.SanPham.TenSp + "</td>" +
                        "<td>" + item.SoLuong + "</td>" +
                        "<td>" + (item.SanPham.Gia - item.SanPham.GiamGia) + "</td>" +
                        "<td>" + item.SoLuong * (item.SanPham.Gia - item.SanPham.GiamGia) + "VNĐ </td><br/>";
                }
                s+= "<tr><td>Tạm tính</td><td></td><td></td><td>"
                        + hd.TamTinh +
                        " VNĐ</td></tr></tr><br/>";
                s+= "<tr><td>VAT</td><td></td><td></td><td>"
                        + hd.VAT +
                        " VNĐ</td></tr></tr><br/>";
                if (hd.MaKhuyenMai != null)
                {
                    var km = data.MaKhuyenMai.Find(hd.MaKhuyenMai);
                    double tkm = ((hd.TamTinh+hd.VAT) * km.GiaTri) / 100;
                    s += "<tr><td>Giảm giá</td><td>" 
                        + tkm + 
                        " VNĐ</td></tr></tr><br/>";

                }    
                s += "<tr><td>Tổng tiền</td><td>"
                        + hd.TongTien +
                        " VNĐ</td></tr></tr><br/>";
                MailContent content = new MailContent
                {
                    To = eMail,
                    Subject = "Thanks for purchase product",
                    Body = "Hello " + hoTen + "! Cảm ơn bạn đã mua sản phẩm tại website của chúng tôi. Ngày mua: " + DateTime.Now + ", mã hóa đơn của bạn là:" + hd.MaHD + "<hr/>" + s
                };
                await sendMailService.SendMail(content);
                cart.Clear();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
        }
        
        
        public async Task<IActionResult> CheckBillAsync(int typePayment)
        {
            
            if (SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart") != null)
            {


                if (typePayment == 1)
                {
                    ViewBag.action = "CheckOutWithSignIn";
                }
                else if (typePayment == 2)
                {
                    ViewBag.action = "PaypalCheckout";
                }
                else
                {
                    ViewBag.action = "CheckOutWithoutSignIn";
                }
                var cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
                double sum = cart.Sum(item => (item.SanPham.Gia - item.SanPham.GiamGia) * item.SoLuong);
                double vat = cart.Sum(item => item.SanPham.Gia * item.SoLuong) / 10;
                ViewBag.cart = cart;
                ViewBag.total = sum + vat;
                ViewBag.vat = vat;

                User user = await userManager.GetUserAsync(User);
                ViewBag.user = user;
                return View();
            }
            ViewBag.status = 1;

            

            return View("Index");
        }

        [Authorize]
        public async System.Threading.Tasks.Task<IActionResult> PaypalCheckout()
        {
            var cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            var environment = new SandboxEnvironment(_clientId, _secretKey);
            var client = new PayPalHttpClient(environment);
            #region Create Paypal Order
            var itemList = new ItemList()
            {
                Items = new List<Item>()
            };
            var total = Math.Round(cart.Sum(p=>p.SanPham.Gia)/TyGiaUSD,2);
            foreach (var item in cart)
            {
                itemList.Items.Add(new Item()
                {
                    Name = item.SanPham.TenSp,
                    Currency = "USD",
                    Price = Math.Round(item.SanPham.Gia / TyGiaUSD, 2).ToString(),
                    Quantity = item.SoLuong.ToString(),
                    Sku = "sku",
                    Tax = "0"
                });
            }
            #endregion

            var paypalOrderId = DateTime.Now.Ticks;
            var hostname = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            var payment = new Payment()
            {
                Intent = "sale",
                Transactions = new List<Transaction>()
                {
                    new Transaction()
                    {
                        Amount = new Amount()
                        {
                            Total = total.ToString(),
                            Currency = "USD",
                            Details = new AmountDetails
                            {
                                Tax = "0",
                                Shipping = "0",
                                Subtotal = total.ToString()
                            }
                        },
                        ItemList = itemList,
                        Description = $"Invoice #{paypalOrderId}",
                        InvoiceNumber = paypalOrderId.ToString()
                    }
                },
                RedirectUrls = new RedirectUrls()
                {
                    CancelUrl = $"{hostname}/Cart/CheckoutFail",
                    ReturnUrl = $"{hostname}/Cart/CheckoutSuccess"
                },
                Payer = new Payer()
                {
                    PaymentMethod = "paypal"
                }
            };

            PaymentCreateRequest request = new PaymentCreateRequest();
            request.RequestBody(payment);

            try
            {
                var response = await client.Execute(request);
                var statusCode = response.StatusCode;
                Payment result = response.Result<Payment>();

                var links = result.Links.GetEnumerator();
                string paypalRedirectUrl = null;
                while (links.MoveNext())
                {
                    LinkDescriptionObject lnk = links.Current;
                    if (lnk.Rel.ToLower().Trim().Equals("approval_url"))
                    {
                        //saving the payapalredirect URL to which user will be redirected for payment  
                        paypalRedirectUrl = lnk.Href;
                    }
                }

                return Redirect(paypalRedirectUrl);
            }
            catch (HttpException httpException)
            {
                var statusCode = httpException.StatusCode;
                var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();

                //Process when Checkout with Paypal fails
                return Redirect("/Cart/CheckoutFail");
            }
        }
        public IActionResult CheckoutFail()
        {
            //Tạo đơn hàng trong database với trạng thái thanh toán là "Chưa thanh toán"
            //List<ProductToCart> cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            //User user = await userManager.GetUserAsync(User);

            //if (SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart") != null)
            //{
            //    double sum = cart.Sum(item => item.SanPham.Gia * item.SoLuong) + 30000;
            //    HoaDon hd = new HoaDon
            //    {
            //        UserId = user.Id,
            //        TongTien = sum ,
            //        Ngay = DateTime.Now,
            //        SDT = user.PhoneNumber,
            //        Email = user.Email,
            //        DiaChi = user.DiaChi,
            //        HoTen = user.HoTen,
            //        LoaiTT = 2,
            //        TinhTrang = false,
            //        TrangThai = false
            //    };
            //    data.HoaDon.Add(hd);
            //    data.SaveChanges();
            //    foreach (var item in cart)
            //    {
            //        CT_HoaDon cthd = new CT_HoaDon
            //        {
            //            MaHD = hd.MaHD,
            //            MaSp = item.SanPham.MaSp,
            //            SoLuong = item.SoLuong
            //        };
            //        var sp = data.SanPham.Find(item.SanPham.MaSp);
            //        sp.SoLuong -= item.SoLuong;
            //        data.Entry(sp).State = EntityState.Modified;

            //        data.CTHoaDon.Add(cthd);
            //        data.SaveChanges();
            //    }

            //}
            return View();
        }

        public async Task<IActionResult> CheckoutSuccess()
        {
            //Tạo đơn hàng trong database với trạng thái thanh toán là "Paypal" và thành công
            List<ProductToCart> cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            User user = await userManager.GetUserAsync(User);
            double tamtinh = cart.Sum(item => item.SanPham.Gia * item.SoLuong);
            var tongtien = tamtinh + tamtinh / 10;
            //tao hoa don
            HoaDon hd = new HoaDon
            {
                HoTen = user.HoTen,
                DiaChi = user.DiaChi,
                SDT = user.PhoneNumber,
                Email = user.Email,
                TamTinh = tamtinh,
                TongTien = tongtien,
                Ngay = DateTime.Today,
                GiaoHang = 1,
                LoaiTT = 2,
                VAT = tamtinh / 10,
                TinhTrang = true,
                TrangThai = true
            };
            data.HoaDon.Add(hd);
            data.SaveChanges();
            foreach (var item in cart)
            {
                //Tao chi tiet hoa don 
                CT_HoaDon cthd = new CT_HoaDon
                {
                    MaHD = hd.MaHD,
                    MaSp = item.SanPham.MaSp,
                    SoLuong = item.SoLuong
                };
                //Update so luong cua san pham
                var sp = data.SanPham.Find(item.SanPham.MaSp);
                sp.SoLuong -= item.SoLuong;
                data.Entry(sp).State = EntityState.Modified;
                data.CTHoaDon.Add(cthd);
                data.SaveChanges();
            }
            user.DiemTichLuy = (int)(hd.TamTinh / 10000);
            await userManager.UpdateAsync(user);
            await SendMailAsync(user.HoTen, user.Email, hd);

            return View();
        }

        [HttpPost]
        public JsonResult AddCoupon(string maKm)
        {
            var mkm = data.MaKhuyenMai.Find(maKm);
            if (mkm == null)
            {
                return Json(new
                {
                    status = 1
                }) ;

            }
            else
            {
                SessionHelper.SetObjectAsJson(HttpContext.Session, "coupon", mkm);
                return Json(new
                {
                    status = 2,
                    giatri = mkm.GiaTri
                });

            }
        }
        [HttpPost]
        public JsonResult RemoveCoupon()
        {
            SessionHelper.SetObjectAsJson(HttpContext.Session, "coupon", null);
            return Json(new
            {

            });
        }

    }
}
