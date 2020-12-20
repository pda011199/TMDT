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
using System.Security.Claims;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Identity;

namespace DoAn.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext context;

        public HomeController(ILogger<HomeController> logger, DataContext context, UserManager<User> _userManager)
        {
            this._userManager = _userManager;
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
            List<SanPham> tr = context.SanPham.OrderBy(s => s.MaSp).Skip(k).Take(5).Include(l => l.LoaiSp).Where(p=> p.Deleted == false).ToList();
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
       
        public IActionResult Detail(int id)
        {
            SanPham sp = context.SanPham.FirstOrDefault(p => p.MaSp == id);
            sp.LoaiSp = context.LoaiSp.Find(sp.MaLoaiSp);
            var cmt = context.Comment.Where(p => p.MaSp == id).ToList();
            foreach (var i in cmt)
            {
                i.User = _userManager.Users.Where(p => p.Id == i.UserId).FirstOrDefault();
            }
            ViewBag.dsdanhgia = cmt;
            return View(sp);
        }
        [HttpPost]
        public IActionResult CreateCmt(int maSp, string comment, int rating)
        {
            var cmt = new Comment();
            cmt.Text = comment;
            cmt.Ngay = DateTime.Now;
            cmt.MaSp = maSp;
            cmt.Rating = rating;
            cmt.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            context.Comment.Add(cmt);
            context.SaveChanges();
            return RedirectToAction("Detail", new RouteValueDictionary(new { Controller = "Home", action = "Detail", id = maSp }));
        }
        [HttpPost]
        public JsonResult AddFavorProduct(int maSp)
        {
            string userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var sp = context.SanPhamYeuThich.Where(p => p.UserId == userid && p.MaSp == maSp).FirstOrDefault();
            if (sp != null)
            {
                context.Entry(sp).State = EntityState.Deleted;
                context.SaveChanges();
                return Json(new
                {
                    status = "Đã xóa sản phẩm khỏi danh sách sản phẩm yêu thích."
                });
            }
            SanPhamYeuThich pFavor = new SanPhamYeuThich() { UserId = userid, MaSp = maSp };
            context.SanPhamYeuThich.Add(pFavor);
            context.SaveChanges();
            return Json(new
            {
                status = "Sản phẩm đã được thêm vào danh sách sản phẩm yêu thích."
            });
        }
        
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
