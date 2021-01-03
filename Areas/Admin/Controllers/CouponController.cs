using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAn.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CouponController : Controller
    {
        private readonly DataContext data;
        public CouponController(DataContext data)
        {
            this.data = data;
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
    }
}
