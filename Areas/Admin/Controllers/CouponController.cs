using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.Models.Domain;
using DoAn.Models.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator,Employee")]
    public class CouponController : Controller
    {
        private readonly DataContext data;
        private readonly ISendMailService sendMailService;
        public CouponController(DataContext data, ISendMailService sendMailService)
        {
            this.data = data;
            this.sendMailService = sendMailService;
        }
        public IActionResult Index()
        {
            var lmkm = data.MaKhuyenMai.OrderByDescending(p=> p.NgayKetThuc).ToList();
            return View(lmkm);
        }
        public IActionResult Create()
        {
            MaKhuyenMai mkm = new MaKhuyenMai();
            mkm.NgayBatDau = DateTime.Now;
            mkm.NgayKetThuc = DateTime.Now;
            return View(mkm);
        }
        [HttpPost]
        public IActionResult Create(MaKhuyenMai maKhuyenMai)
        {
            if (ModelState.IsValid)
            {
                MaKhuyenMai mkm = new MaKhuyenMai();
                mkm.Id = GenerateRandomString();
                mkm.NgayBatDau = DateTime.Now;
                mkm.NgayKetThuc = maKhuyenMai.NgayKetThuc;
                mkm.GiaTri = maKhuyenMai.GiaTri;
                data.MaKhuyenMai.Add(mkm);
                data.SaveChanges();
            }
            else
            {
                return View(maKhuyenMai);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(string id)
        {
            var mkm = data.MaKhuyenMai.Find(id);
            return View(mkm);
        }
        [HttpPost]
        public IActionResult Edit(string id , MaKhuyenMai maKhuyenMai)
        {
            if(ModelState.IsValid)
            {
                var mkm = data.MaKhuyenMai.Find(id);
                mkm.NgayBatDau = maKhuyenMai.NgayBatDau;
                mkm.NgayKetThuc = maKhuyenMai.NgayKetThuc;
                mkm.GiaTri = maKhuyenMai.GiaTri;
                data.Entry(mkm).State = EntityState.Modified;
                data.SaveChanges();
            }
            ViewBag.Status = 1;
            return View(maKhuyenMai);
        }
        public async Task<IActionResult> SendCouponAsync(string id,int option)
        {
            MaKhuyenMai coupon = data.MaKhuyenMai.Find(id);
            DateTime now = DateTime.Today;
            if(coupon == null || coupon.NgayKetThuc.CompareTo(now) < 0)
            {
                ViewBag.status = 1;
                return View("Index");
            } 
            switch(option)
            {
                case 1:
                    List<User> lus = data.Users.ToList();
                    foreach(var item in lus)
                    {
                        await SendCouponForUserAsync(coupon, item.Email);
                    }
                    return View("Index");
                case 2:
                    List<User> kus = data.Users.Where(p=>p.DiemTichLuy >= 5000 && p.DiemTichLuy < 10000).ToList();
                    foreach (var item in kus)
                    {
                        await SendCouponForUserAsync(coupon, item.Email);
                    }
                    return View("Index");
                case 3:
                    List<User> jus = data.Users.Where(p => p.DiemTichLuy >= 10000 && p.DiemTichLuy > 15000).ToList();
                    foreach (var item in jus)
                    {
                        await SendCouponForUserAsync(coupon, item.Email);
                    }
                    return View("Index");
                case 4:
                    List<User> hus = data.Users.Where(p => p.DiemTichLuy >= 15000).ToList();
                    foreach (var item in hus)
                    {
                        await SendCouponForUserAsync(coupon, item.Email);
                    }
                    return View("Index");
                default:
                    return View("Index");
            }
        }
        private string GenerateRandomString()
        {
            int length = 7;

            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;
            bool check = true; //true = str_build not already in database
            do
            {
                for (int i = 0; i < length; i++)
                {
                    double flt = random.NextDouble();
                    int shift = Convert.ToInt32(Math.Floor(25 * flt));
                    letter = Convert.ToChar(shift + 65);
                    str_build.Append(letter);
                }
                var coupon = data.MaKhuyenMai.Find(str_build.ToString());
                if (coupon != null)
                    check = false;
            }
            while (check == false);
            return str_build.ToString();
        }
        private async Task SendCouponForUserAsync(MaKhuyenMai maCoupon, string email)
        {
            MailContent content = new MailContent
            {
                To = email,
                Subject = "Tặng mã khuyến mãi mua sản phẩm.",
                Body ="Xin chào! Cảm ơn vì đã sử dụng ứng dụng của chúng tôi.Chúng tôi gửi tặng bạn mã khuyến mãi:'"+ maCoupon.Id+"' có giá trị "+maCoupon.GiaTri+"% bắt đầu từ ngày "+maCoupon.NgayBatDau+" và kết thúc ngày "+maCoupon.NgayKetThuc+".Chân thành cảm ơn." 
            };
            await sendMailService.SendMail(content);
        }
    }
}
