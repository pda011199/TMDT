using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DoAn.Models;
using DoAn.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator,Employee")]

    public class ProductController : Controller
    {
        DataContext data;
        public ProductController(DataContext data)
        {
            this.data = data;
        }
        public IActionResult Index()
        {
            List<SanPham> ds = data.SanPham.Where(p => p.Deleted == false).ToList();
            foreach(var item in ds)
            {
                item.LoaiSp = data.LoaiSp.Find(item.MaLoaiSp);
            }
            return View(ds);
        }
        
        public IActionResult Add()
        {
            SanPham sp = new SanPham();
            ViewBag.Category = data.LoaiSp.Where(p=> p.Deleted == false).ToList();
            return View(sp);
        }
        [HttpPost]
        public IActionResult Add(SanPham productModel, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                SanPham newProduct = new SanPham();
                if (photo == null || photo.Length == 0)
                {
                    newProduct.HinhAnh = "dragonball.jpg";
                }
                else
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", photo.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    photo.CopyToAsync(stream);
                    newProduct.HinhAnh = photo.FileName;
                }
                newProduct.TenSp = productModel.TenSp;
                newProduct.Mota = productModel.Mota;
                newProduct.MaLoaiSp = productModel.MaLoaiSp;
                newProduct.Gia = productModel.Gia;
                newProduct.SoLuong = productModel.SoLuong;
                newProduct.NgayTao = DateTime.Now;
                newProduct.Deleted = false;
                newProduct.LoaiSp = data.LoaiSp.Find(productModel.MaLoaiSp);
                newProduct.GiamGia = 0;
                data.SanPham.Add(newProduct);
                data.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View(productModel);
            }
        }
        public IActionResult Delete(int id)
        {
            SanPham sp = data.SanPham.Find(id);

            return View(sp);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            SanPham sp = data.SanPham.Find(id);
            sp.Deleted = true;
            data.Entry(sp).State = EntityState.Modified;
            data.SaveChanges();
            return RedirectToAction("Index","Product");
        }
        public IActionResult Edit(int id)
        {
            SanPham sp = data.SanPham.Find(id);
            return View(sp);
        }
        [HttpPost, ActionName("Edit")]
        public IActionResult EditConfirm(int id, SanPham sanPham)
        {
            if(ModelState.IsValid)
            {
                SanPham sp = data.SanPham.Find(id);
                sp.TenSp = sanPham.TenSp;
                sp.Mota = sanPham.Mota;
                sp.Gia = sanPham.Gia;
                sp.SpHot = sanPham.SpHot;
                sp.GiamGia = sanPham.GiamGia;
                ViewBag.Status = 1;
            }
            data.SaveChanges();
            return View(sanPham);
        }
    }
}
