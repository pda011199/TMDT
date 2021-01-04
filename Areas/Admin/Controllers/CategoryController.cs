using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoAn.Models.Domain;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DoAn.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    [Authorize(Roles = "Employee")]

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
            var dssp = data.SanPham.Where(p => p.MaLoaiSp == id).ToList();
            foreach(SanPham item in dssp)
            {
                item.Deleted = true;
                data.Entry(item).State = EntityState.Modified;
                data.SaveChanges();
            }
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
