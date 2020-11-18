using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoAn.Models.Domain;
using DoAn.Helper;
using DoAn.Models;

namespace DoAn.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext data;
        public CartController(DataContext data)
        {
            this.data = data;
        }
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.SanPham.Gia * item.SoLuong);
            return View();
        }
        [Route("buy/{id}")]
        public IActionResult Buy(int id, int soLuong)
        {
            if(SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session,"cart")==null)
            {
                List<ProductToCart> cart = new List<ProductToCart>();
                cart.Add(new ProductToCart { SanPham = data.SanPham.FirstOrDefault(p => p.MaSp == id), SoLuong = soLuong });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<ProductToCart> cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if(index != -1)
                {
                    cart[index].SoLuong += soLuong;
                }
                else
                {
                    cart.Add(new ProductToCart { SanPham = data.SanPham.FirstOrDefault(p => p.MaSp == id), SoLuong = soLuong });

                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }
        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<ProductToCart> cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
        private int isExist(int id)
        {
            List<ProductToCart> cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            for(int i = 0;i< cart.Count;i++)
            {
                if (cart[i].SanPham.MaSp == id)
                    return i;
            }
            return -1;
        }
        [Route("update/{id}")]
        public IActionResult Update(int id, int soLuong)
        {
            List<ProductToCart> cart = SessionHelper.GetObjectFromJson<List<ProductToCart>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart[index].SoLuong = soLuong;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
    }
}
