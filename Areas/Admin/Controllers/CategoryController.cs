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
            ds = data.LoaiSp.ToList();
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
                data.LoaiSp.Add(lsp);
                data.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View(lsp);
            }
        }


    }
}
