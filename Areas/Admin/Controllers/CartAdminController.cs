using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoAn.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CartAdminController : Controller
    {
        private readonly DataContext data;
        public CartAdminController(DataContext data)
        {
            this.data = data;
        }
        //Show list order
        public IActionResult Index()
        {
            ViewBag.hoaDon = data.HoaDon.OrderByDescending(p=> p.MaHD).ToList();
            ViewBag.waitHodDon = data.HoaDon.Where(p => p.TrangThai == null).ToList();
            return View();
        }
        [HttpGet("CartAdmin/Cancel/{id}")]
        public IActionResult Cancel(int id)
        {
            HoaDon hd = data.HoaDon.Find(id);
            hd.TrangThai = false;
            data.Entry(hd).State = EntityState.Modified;
            data.SaveChanges();

            List<CT_HoaDon> ct_hd = data.CTHoaDon.Where(p => p.MaHD == id).ToList();
            foreach (var item in ct_hd)
            {
                SanPham sp = data.SanPham.Find(item.MaSp);
                sp.SoLuong += item.SoLuong;
                data.Entry(sp).State = EntityState.Modified;
                data.SaveChanges();
            }

            ViewBag.hoaDon = data.HoaDon.ToList();
            return View("Index");
        }
        [HttpGet("CartAdmin/Accept/{id}")]
        public IActionResult Accept(int id)
        {
            HoaDon hd = data.HoaDon.Find(id);
            hd.TrangThai = true;
            data.Entry(hd).State = EntityState.Modified;
            data.SaveChanges();
            ViewBag.hoaDon = data.HoaDon.ToList();
            return View("Index");
        }
    }
}
