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

namespace DoAn.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext data;
        private readonly UserManager<User> userManager;
        private readonly ISendMailService sendMailService;
        public CartController(DataContext data, UserManager<User> userManager, ISendMailService sendMailService)
        {
            this.data = data;
            this.userManager = userManager;
            this.sendMailService = sendMailService;
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
                };
                data.HoaDon.Add(hd);
                data.SaveChanges();
                string s = "<table>" + "<tr><th>Tên sản phẩm</th>" +
                    "<th>Số lượng</th>" +
                    "<th>Giá</th>" +
                    "<th>Thành tiền</th></tr><tr>";
                foreach (var item in cart)
                {
                    CT_HoaDon cthd = new CT_HoaDon
                    {
                        MaHD = hd.MaHD,
                        MaSp = item.SanPham.MaSp,
                        SoLuong = item.SoLuong             
                    };
                    s = s + "<td>"+item.SanPham.TenSp+"</td>" +
                        "<td>"+item.SoLuong+"</td>" +
                        "<td>" + item.SanPham.Gia + "</td>"+
                        "<td>" + item.SoLuong*item.SanPham.Gia + "</td>";
                    data.CTHoaDon.Add(cthd);
                    data.SaveChanges();
                }
                s += "<tr><td>Tổng tiền</td><td>"+sum+" VNĐ</td></tr></tr>";
                MailContent content = new MailContent
                {
                    To = user.Email,
                    Subject = "Thanks for purchase product",
                    Body = "Hello " + user.HoTen + "! Cảm ơn bạn đã mua sản phẩm tại website của chúng tôi. Ngày mua: "+DateTime.Now+", mã hóa đơn của bạn là:" + hd.MaHD + "<hr/>"+s
                };
                await sendMailService.SendMail(content);
            }
            return RedirectToAction(nameof(HomeController.Index),"Home");
        }
        public async Task<IActionResult> CheckOutWithoutSignInAsync(string hoTen, string diaChi, string sDT,string eMail)
        {
            if (SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart") != null)
            {
                var cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
                double sum = cart.Sum(item => item.SanPham.Gia * item.SoLuong);
                HoaDon hd = new HoaDon
                {
                    HoTen=hoTen,
                    DiaChi=diaChi,
                    SDT=sDT,
                    Email=eMail,
                    Deleted = false,
                    TongTien = sum,
                    Ngay = DateTime.Now,
                };
                data.HoaDon.Add(hd);
                data.SaveChanges();
                string s = "<table>" + "<tr><th>Tên sản phẩm</th>" +
                    "<th>Số lượng</th>" +
                    "<th>Giá</th>" +
                    "<th>Thành tiền</th></tr><tr>";
                foreach (var item in cart)
                {
                    CT_HoaDon cthd = new CT_HoaDon
                    {
                        MaHD = hd.MaHD,
                        MaSp = item.SanPham.MaSp,
                        SoLuong = item.SoLuong
                    };
                    s = s + "<td>" + item.SanPham.TenSp + "</td>" +
                        "<td>" + item.SoLuong + "</td>" +
                        "<td>" + item.SanPham.Gia + "</td>" +
                        "<td>" + item.SoLuong * item.SanPham.Gia + "</td>";
                    data.CTHoaDon.Add(cthd);
                    data.SaveChanges();
                }
                s += "<tr><td>Tổng tiền</td><td>" + sum + " VNĐ</td></tr></tr>";
                MailContent content = new MailContent
                {
                    To = eMail,
                    Subject = "Thanks for purchase product",
                    Body = "Hello " + hoTen + "! Cảm ơn bạn đã mua sản phẩm tại website của chúng tôi. Ngày mua: " + DateTime.Now + ", mã hóa đơn của bạn là:" + hd.MaHD + "<hr/>" + s
                };
                await sendMailService.SendMail(content);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
