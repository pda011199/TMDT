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
            var cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.SanPham.Gia * item.SoLuong);
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
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.SanPham.Gia * item.SoLuong);
            return View();
        }
        public async Task<IActionResult> CheckOutWithSignInAsync()
        {
            User user = await userManager.GetUserAsync(User);
            if (SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart") != null)
            {
                var cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
                double sum = cart.Sum(item => item.SanPham.Gia * item.SoLuong);
                HoaDon hd = new HoaDon
                {
                    UserId = user.Id,
                    Deleted = false,
                    TongTien = sum,
                    Ngay = DateTime.Now,
                    SDT=user.PhoneNumber,
                    Email = user.Email,
                    DiaChi = user.DiaChi,
                    HoTen = user.HoTen,
                    LoaiTT = 1,
                    TinhTrang = false
                };
                data.HoaDon.Add(hd);
                data.SaveChanges();
                foreach (var item in cart)
                {
                    CT_HoaDon cthd = new CT_HoaDon
                    {
                        MaHD = hd.MaHD,
                        MaSp = item.SanPham.MaSp,
                        SoLuong = item.SoLuong             
                    };
                    var sp = data.SanPham.Find(item.SanPham.MaSp);
                    sp.SoLuong -= item.SoLuong;
                    data.Entry(sp).State = EntityState.Modified;

                    data.CTHoaDon.Add(cthd);
                    data.SaveChanges();
                }
                await SendMailAsync(user.HoTen, user.DiaChi, user.PhoneNumber, user.Email, hd);
            }
            return RedirectToAction(nameof(HomeController.Index),"Home");
        }
        public async Task<IActionResult> CheckOutWithoutSignInAsync(string hoTen, string diaChi, string sDT, string eMail)
        {
            if (SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart") != null)
            {
                var cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
                double sum = cart.Sum(item => item.SanPham.Gia * item.SoLuong);

                //tao hoa don
                HoaDon hd = new HoaDon
                {
                    HoTen = hoTen,
                    DiaChi = diaChi,
                    SDT = sDT,
                    Email = eMail,
                    Deleted = false,
                    TongTien = sum,
                    Ngay = DateTime.Now,
                    LoaiTT = 1,
                    TinhTrang = false
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
                await SendMailAsync(hoTen, diaChi, sDT, eMail, hd);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        private async Task SendMailAsync(string hoTen, string diaChi, string sDT, string eMail, HoaDon hd)
        {
            if (SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart") != null)
            {
                var cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
                double sum = cart.Sum(item => item.SanPham.Gia * item.SoLuong);

                string s = "<table>" + "<tr><th>Tên sản phẩm</th>" +
                    "<th>Số lượng</th>" +
                    "<th>Giá</th>" +
                    "<th>Thành tiền</th></tr><tr>";
                foreach (var item in cart)
                {
                    s = s + "<td>" + item.SanPham.TenSp + "</td>" +
                        "<td>" + item.SoLuong + "</td>" +
                        "<td>" + item.SanPham.Gia + "</td>" +
                        "<td>" + item.SoLuong * item.SanPham.Gia + "</td>";
                }
                s += "<tr><td>Tổng tiền</td><td>" + sum + " VNĐ</td></tr></tr>";
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
        [Authorize]
        public async Task<IActionResult> PaypalCheckout()
        {

            var cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            if(cart == null)
            {
                return View("Index");
            }
            

            var environment = new SandboxEnvironment(_clientId, _secretKey);
            var client = new PayPalHttpClient(environment);

            cart.Sum(item => item.SanPham.Gia * item.SoLuong);


            #region Create Paypal Order
            var itemList = new ItemList()
            {
                Items = new List<Item>()
            };
            var total = Math.Round(cart.Sum(item => item.SanPham.Gia * item.SoLuong) / TyGiaUSD, 2);
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

        public async Task<IActionResult> CheckoutFailAsync()
        {
            //Tạo đơn hàng trong database với trạng thái thanh toán là "Chưa thanh toán"
            List<ProductToCart> cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            User user = await userManager.GetUserAsync(User);
            
            if (SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart") != null)
            {
                double sum = cart.Sum(item => item.SanPham.Gia * item.SoLuong);
                HoaDon hd = new HoaDon
                {
                    UserId = user.Id,
                    Deleted = false,
                    TongTien = sum,
                    Ngay = DateTime.Now,
                    SDT = user.PhoneNumber,
                    Email = user.Email,
                    DiaChi = user.DiaChi,
                    HoTen = user.HoTen,
                    LoaiTT = 2,
                    TinhTrang = false,
                    TrangThai = false
                };
                data.HoaDon.Add(hd);
                data.SaveChanges();
                foreach (var item in cart)
                {
                    CT_HoaDon cthd = new CT_HoaDon
                    {
                        MaHD = hd.MaHD,
                        MaSp = item.SanPham.MaSp,
                        SoLuong = item.SoLuong
                    };
                    var sp = data.SanPham.Find(item.SanPham.MaSp);
                    sp.SoLuong -= item.SoLuong;
                    data.Entry(sp).State = EntityState.Modified;

                    data.CTHoaDon.Add(cthd);
                    data.SaveChanges();
                }
                
            }
            return View();
        }

        public async Task<IActionResult> CheckoutSuccessAsync()
        {
            //Tạo đơn hàng trong database với trạng thái thanh toán là "Paypal" và thành công
            List<ProductToCart> cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            User user = await userManager.GetUserAsync(User);

            if (SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart") != null)
            {
                double sum = cart.Sum(item => item.SanPham.Gia * item.SoLuong);
                HoaDon hd = new HoaDon
                {
                    UserId = user.Id,
                    Deleted = false,
                    TongTien = sum,
                    Ngay = DateTime.Now,
                    SDT = user.PhoneNumber,
                    Email = user.Email,
                    DiaChi = user.DiaChi,
                    HoTen = user.HoTen,
                    LoaiTT = 2,
                    TinhTrang = true,
                    TrangThai = true
                };
                data.HoaDon.Add(hd);
                data.SaveChanges();
                foreach (var item in cart)
                {
                    CT_HoaDon cthd = new CT_HoaDon
                    {
                        MaHD = hd.MaHD,
                        MaSp = item.SanPham.MaSp,
                        SoLuong = item.SoLuong
                    };
                    var sp = data.SanPham.Find(item.SanPham.MaSp);
                    sp.SoLuong -= item.SoLuong;
                    data.Entry(sp).State = EntityState.Modified;

                    data.CTHoaDon.Add(cthd);
                    data.SaveChanges();
                }
                await SendMailAsync(user.HoTen, user.DiaChi, user.PhoneNumber, user.Email, hd);
            }
            return View();
        }


    }
}
