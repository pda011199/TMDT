using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DoAn.Controllers
{
    public class CustomerCateController : Controller
    {
        private readonly DataContext context;
        public CustomerCateController(DataContext data)
        {
            this.context = data;
        }
        public IActionResult Index(int id)
        {
            //List<SanPham> details = data.SanPham.Include(l => l.LoaiSp).Where(l => l.LoaiSp.MaLoaiSp == id).ToList();
            //if (details.Count.Equals(0)) return NotFound();
            //ViewBag.truyen = details;
            //return View();
            List<SanPham> ds = context.SanPham.Where(p=>p.MaLoaiSp == id && p.Deleted == false).ToList();
            foreach (SanPham item in ds)
            {
                item.LoaiSp = context.LoaiSp.Find(item.MaLoaiSp);
            }
            return View(ds);
        }
        public IActionResult OptionSort(int option)
        {
            switch(option)
            {
                case 1:
                    return RedirectToAction("SortByName");
                case 2:
                    return RedirectToAction("SortByPrice");
                case 3:
                    return RedirectToAction("SortByPriceDesc");
                default:
                    return View("Index");
            }
        }
        public IActionResult SortByName()
        {
            List<SanPham> truyen = context.SanPham.OrderBy(s => s.TenSp).Where(p => p.Deleted == false).ToList();
            ViewBag.truyen = truyen;
            return View("Index",truyen);
        }
        public IActionResult SortByPrice()
        {
            List<SanPham> truyen = context.SanPham.OrderBy(s => s.Gia).Where(p => p.Deleted == false).ToList();
            ViewBag.truyen = truyen;
            return View("Index",truyen);
        }

        public IActionResult SortByPriceDesc()
        {
            List<SanPham> truyen = context.SanPham.OrderByDescending(s => s.Gia).Where(p => p.Deleted == false).ToList();
            ViewBag.truyen = truyen;
            return View("Index",truyen);
        }
        public IActionResult Find(string tensp)
        {
            List<SanPham> truyen = context.SanPham.Where(s => s.TenSp.Contains(tensp) && s.Deleted == false).ToList();
            return View("Index",truyen);
        }
        [Route("id")]
        public IActionResult CateSearch(int id)
        {
            List<SanPham> truyen = context.SanPham.Where(s => s.MaLoaiSp == id && s.Deleted == false).ToList();
            return View("Index", truyen);
        }
        public IActionResult CateSearchOther()
        {
            List<SanPham> truyen = context.SanPham.Where(s => s.MaLoaiSp != 1 && s.MaLoaiSp != 2 && s.Deleted == false).ToList();
            return View("Index", truyen);
        }
    }
}
