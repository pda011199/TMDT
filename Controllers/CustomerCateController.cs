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
        private readonly DataContext data;
        public CustomerCateController(DataContext data)
        {

            this.data = data;
        }
        public IActionResult Index(int id)
        {
            //List<SanPham> details = data.SanPham.Include(l => l.LoaiSp).Where(l => l.LoaiSp.MaLoaiSp == id).ToList();
            //if (details.Count.Equals(0)) return NotFound();
            //ViewBag.truyen = details;
            //return View();
            List<SanPham> ds = data.SanPham.ToList();
            foreach (SanPham item in ds)
            {
                item.LoaiSp = data.LoaiSp.Find(item.MaLoaiSp);
            }
            return View(ds);
        }
    }
}
