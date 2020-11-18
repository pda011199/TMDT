using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DoAn.Models;
using DoAn.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAn.Controllers
{
    public class ProductController : Controller
    {
        DataContext data;
        public ProductController(DataContext data)
        {
            this.data = data;
        }
        public IActionResult Index()
        {
            List<SanPham> ds = data.SanPham.ToList();
            foreach(SanPham item in ds)
            {
                item.LoaiSp = data.LoaiSp.Find(item.MaLoaiSp);
            }
            return View(ds);
        }
        
        public IActionResult Add()
        {
            SanPham sp = new SanPham();
            ViewBag.Category = data.LoaiSp.ToList();
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

                data.SanPham.Add(newProduct);
                data.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View(productModel);
            }
        }
        [HttpGet("Product/{id}/{name}")]
        public IActionResult Detail(int id)
        {
            SanPham sp = data.SanPham.FirstOrDefault(p => p.MaSp == id);
            sp.LoaiSp = data.LoaiSp.Find(sp.MaLoaiSp);
            return View(sp);
        }
    }
}
