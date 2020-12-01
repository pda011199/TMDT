using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoAn.Models.Domain;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        DataContext data;
        public CategoryController(DataContext data)
        {
            this.data = data;
        }
        public IActionResult Index()
        {
            List<LoaiSp> ds = new List<LoaiSp>();
            ds = data.LoaiSp.Where(p => p.Deleted == false).ToList();
            return View(ds);
        }
        [HttpGet]
        public IActionResult Add()
        {
            LoaiSp lsp = new LoaiSp();
            return View(lsp);
        }
        [HttpPost]
        public IActionResult Add(LoaiSp lsp)
        {
            if(ModelState.IsValid)
            {
                lsp.Deleted = false;
                data.LoaiSp.Add(lsp);
                data.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View(lsp);
            }
        }
        public IActionResult Delete(int id)
        {
            LoaiSp lsp = data.LoaiSp.Find(id);

            return View(lsp);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            LoaiSp lsp = data.LoaiSp.Find(id);
            lsp.Deleted = true;
            data.Entry(lsp).State = EntityState.Modified;
            data.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
        public IActionResult Edit(int id)
        {
            LoaiSp lsp = data.LoaiSp.Find(id);
            return View(lsp);
        }
        [HttpPost, ActionName("Edit")]
        public IActionResult EditConfirm(int id, LoaiSp loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                LoaiSp lsp = data.LoaiSp.Find(id);
                lsp.TenLoaiSp = loaiSanPham.TenLoaiSp;

                ViewBag.Status = 1;
            }
            data.SaveChanges();
            return View(loaiSanPham);
        }

    }
}
