using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DoAn.Models;
using DoAn.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            this.context = context;
            _logger = logger;
        }

        public IActionResult Index(int? id)
        {
            int k = 0;
            if (id != null)
            {
                k = id.GetValueOrDefault() * 5;
            }
            List<SanPham> tr = context.SanPham.OrderBy(s => s.MaSp).Skip(k).Take(5).Include(l => l.LoaiSp).ToList();
            ViewBag.truyen = tr;
            ViewBag.count = context.SanPham.Count() / 5;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Find(string tensp)
        {
            List<SanPham> truyen = context.SanPham.Where(s => s.TenSp.Contains(tensp)).ToList();
            ViewBag.truyen = truyen;
            return View();
        }
        public IActionResult SortbyTheLoai()
        {
            context.LoaiSp.ToList();
            return View();
        }
        public IActionResult SortByName()
        {
            List<SanPham> truyen = context.SanPham.OrderBy(s => s.TenSp).ToList();
            ViewBag.truyen = truyen;
            return View();
        }
        public IActionResult SortByPrice()
        {
            List<SanPham> truyen = context.SanPham.OrderBy(s => s.Gia).ToList();
            ViewBag.truyen = truyen;
            return View();
        }

        public IActionResult SortByPriceDesc()
        {
            List<SanPham> truyen = context.SanPham.OrderByDescending(s => s.Gia).ToList();
            ViewBag.truyen = truyen;
            return View();
        }
        [HttpGet("Home/{id}/{name}")]
        public IActionResult Detail(int id)
        {
            SanPham sp = context.SanPham.FirstOrDefault(p => p.MaSp == id);
            sp.LoaiSp = context.LoaiSp.Find(sp.MaLoaiSp);
            return View(sp);
        }
    }
}
