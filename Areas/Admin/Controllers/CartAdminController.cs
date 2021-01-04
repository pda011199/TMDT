using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoAn.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Routing;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    [Authorize(Roles = "Employee")]
    public class CartAdminController : Controller
    {
        private readonly DataContext data;
        public CartAdminController(DataContext data)
        {
            this.data = data;
        }
        //Show list order
        public IActionResult Index(DateTime ngayBatDau, DateTime ngayKetThuc, int option)
        {
            ViewBag.option = option;
            switch (option)
            {
                case 1:
                    ViewBag.ngayBatDau = ngayBatDau.ToString("yyyy-MM-dd");
                    ViewBag.ngayKetThuc = ngayKetThuc.ToString("yyyy-MM-dd");
                    var lhd = data.HoaDon.Where(p => p.Ngay.CompareTo(ngayBatDau) >= 0 && p.Ngay.CompareTo(ngayKetThuc) <= 0).ToList();
                    foreach(var item in lhd)
                    {
                        item.KhuyenMai = data.MaKhuyenMai.Find(item.MaKhuyenMai);
                    }
                    ViewBag.waitHoaDon = lhd;
                    return View();
                case 2:
                    ViewBag.ngayBatDau = ngayBatDau.ToString("yyyy-MM-dd");
                    ViewBag.ngayKetThuc = ngayKetThuc.ToString("yyyy-MM-dd");
                    var khd = data.HoaDon.Where(p =>p.GiaoHang == 4 && p.Ngay.CompareTo(ngayBatDau) >= 0 && p.Ngay.CompareTo(ngayKetThuc) <= 0).ToList();
                    foreach (var item in khd)
                    {
                        item.KhuyenMai = data.MaKhuyenMai.Find(item.MaKhuyenMai);
                    }
                    ViewBag.waitHoaDon = khd;
                    return View();
                case 3:
                    ViewBag.ngayBatDau = ngayBatDau.ToString("yyyy-MM-dd");
                    ViewBag.ngayKetThuc = ngayKetThuc.ToString("yyyy-MM-dd");
                    var jhd = data.HoaDon.Where(p =>p.GiaoHang == 3 && p.TinhTrang == true && p.Ngay.CompareTo(ngayBatDau) >= 0 && p.Ngay.CompareTo(ngayKetThuc) <= 0).ToList();
                    foreach (var item in jhd)
                    {
                        item.KhuyenMai = data.MaKhuyenMai.Find(item.MaKhuyenMai);
                    }
                    ViewBag.waitHoaDon = jhd;
                    return View();
                case 4:
                    ViewBag.ngayBatDau = ngayBatDau.ToString("yyyy-MM-dd");
                    ViewBag.ngayKetThuc = ngayKetThuc.ToString("yyyy-MM-dd");
                    var hhd = data.HoaDon.Where(p => p.GiaoHang == 3 && p.TinhTrang == false && p.Ngay.CompareTo(ngayBatDau) >= 0 && p.Ngay.CompareTo(ngayKetThuc) <= 0).ToList();
                    foreach (var item in hhd)
                    {
                        item.KhuyenMai = data.MaKhuyenMai.Find(item.MaKhuyenMai);
                    }
                    ViewBag.waitHoaDon = hhd;
                    return View();
                case 5:
                    ViewBag.ngayBatDau = ngayBatDau.ToString("yyyy-MM-dd");
                    ViewBag.ngayKetThuc = ngayKetThuc.ToString("yyyy-MM-dd");
                    var ghd = data.HoaDon.Where(p =>p.TrangThai == false && p.Ngay.CompareTo(ngayBatDau) >= 0 && p.Ngay.CompareTo(ngayKetThuc) <= 0).ToList();
                    foreach (var item in ghd)
                    {
                        item.KhuyenMai = data.MaKhuyenMai.Find(item.MaKhuyenMai);
                    }
                    ViewBag.waitHoaDon = ghd;
                    return View();
                case 6:
                    ViewBag.ngayBatDau = ngayBatDau.ToString("yyyy-MM-dd");
                    ViewBag.ngayKetThuc = ngayKetThuc.ToString("yyyy-MM-dd");
                    var fhd = data.HoaDon.Where(p => p.TrangThai == null && p.Ngay.CompareTo(ngayBatDau) >= 0 && p.Ngay.CompareTo(ngayKetThuc) <= 0).ToList();
                    foreach (var item in fhd)
                    {
                        item.KhuyenMai = data.MaKhuyenMai.Find(item.MaKhuyenMai);
                    }
                    ViewBag.waitHoaDon = fhd;
                    return View();
                case 7:
                    ViewBag.ngayBatDau = ngayBatDau.ToString("yyyy-MM-dd");
                    ViewBag.ngayKetThuc = ngayKetThuc.ToString("yyyy-MM-dd");
                    var dhd = data.HoaDon.Where(p => p.TrangThai == true && p.GiaoHang == 1 && p.Ngay.CompareTo(ngayBatDau) >= 0 && p.Ngay.CompareTo(ngayKetThuc) <= 0).ToList();
                    foreach (var item in dhd)
                    {
                        item.KhuyenMai = data.MaKhuyenMai.Find(item.MaKhuyenMai);
                    }
                    ViewBag.waitHoaDon = dhd;
                    return View();
                case 8:
                    ViewBag.ngayBatDau = ngayBatDau.ToString("yyyy-MM-dd");
                    ViewBag.ngayKetThuc = ngayKetThuc.ToString("yyyy-MM-dd");
                    var shd = data.HoaDon.Where(p => p.TrangThai == true && p.GiaoHang == 2 && p.Ngay.CompareTo(ngayBatDau) >= 0 && p.Ngay.CompareTo(ngayKetThuc) <= 0).ToList();
                    foreach (var item in shd)
                    {
                        item.KhuyenMai = data.MaKhuyenMai.Find(item.MaKhuyenMai);
                    }
                    ViewBag.waitHoaDon = shd;
                    return View();
                default:
                    DateTime a = DateTime.Today;
                    DateTime b = new DateTime(2020, 1, 1);
                    ViewBag.ngayBatDau = b.ToString("yyyy-MM-dd");
                    ViewBag.ngayKetThuc = a.ToString("yyyy-MM-dd");
                    var ahd = data.HoaDon.Where(p =>p.TrangThai == null && p.Ngay.CompareTo(b) >= 0).ToList();
                    foreach (var item in ahd)
                    {
                        item.KhuyenMai = data.MaKhuyenMai.Find(item.MaKhuyenMai);
                    }
                    ViewBag.waitHoaDon = ahd;
                    return View();
            }

        }
        [HttpGet("CartAdmin/Cancel/{id}")]
        public IActionResult Cancel(int id, int option, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            HoaDon hd = data.HoaDon.Find(id);
            hd.TrangThai = false;
            data.Entry(hd).State = EntityState.Modified;
            data.SaveChanges();

            List<CT_HoaDon> ct_hd = data.CTHoaDon.Where(p => p.MaHD == id).ToList();
            foreach (var item in ct_hd)
            {
                SanPham sp = data.SanPham.Find(item.MaSp);
                sp.SoLuong += item.SoLuong;
                data.Entry(sp).State = EntityState.Modified;
                data.SaveChanges();
            }

            ViewBag.hoaDon = data.HoaDon.ToList();
            ViewBag.waitHoaDon = data.HoaDon.Where(p => p.TrangThai == null).ToList();
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "CartAdmin", action = "Index", ngayBatDau = ngayBatDau, ngayKetThuc = ngayKetThuc,option=option }));
        }
        [HttpGet]
        public IActionResult Accept(int id, int option, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            HoaDon hd = data.HoaDon.Find(id);
            hd.TrangThai = true;
            data.Entry(hd).State = EntityState.Modified;
            data.SaveChanges();
            ViewBag.hoaDon = data.HoaDon.ToList();
            ViewBag.waitHoaDon = data.HoaDon.Where(p => p.TrangThai == null).ToList();
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "CartAdmin", action = "Index", ngayBatDau = ngayBatDau, ngayKetThuc = ngayKetThuc, option = option }));
        }
        [HttpGet("CartAdmin/DaThanhToan/{id}")]
        public IActionResult DaThanhToan(int id, int option, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            HoaDon hd = data.HoaDon.Find(id);
            hd.NgayThuTien = DateTime.Today;
            hd.TinhTrang = true;
            User us = data.Users.Find(hd.UserId);
            us.DiemTichLuy = (int)(hd.TongTien / 10000);
            data.Entry(us).State = EntityState.Modified;
            data.Entry(hd).State = EntityState.Modified;
            data.SaveChanges();
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "CartAdmin", action = "Index", ngayBatDau = ngayBatDau, ngayKetThuc = ngayKetThuc, option = option }));
        }
        [HttpGet("CartAdmin/DangGiaoHang/{id}")]
        public IActionResult DangGiaoHang(int id, int option, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            HoaDon hd = data.HoaDon.Find(id);
            hd.GiaoHang = 2;
            data.Entry(hd).State = EntityState.Modified;
            data.SaveChanges();
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "CartAdmin", action = "Index", ngayBatDau = ngayBatDau, ngayKetThuc = ngayKetThuc, option = option }));
        }
        [HttpGet("CartAdmin/GiaoHangThanhCong/{id}")]
        public IActionResult GiaoHangThanhCong(int id, int option, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            HoaDon hd = data.HoaDon.Find(id);
            hd.GiaoHang = 3;
            data.Entry(hd).State = EntityState.Modified;
            data.SaveChanges();
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "CartAdmin", action = "Index", ngayBatDau = ngayBatDau, ngayKetThuc = ngayKetThuc, option = option }));
        }
        [HttpGet("CartAdmin/GiaoHangThatBai/{id}")]
        public IActionResult GiaoHangThatBai(int id, int option, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            HoaDon hd = data.HoaDon.Find(id);
            hd.GiaoHang = 4;
            data.Entry(hd).State = EntityState.Modified;
            data.SaveChanges();
            return RedirectToAction("Index", new RouteValueDictionary(new { Controller = "CartAdmin", action = "Index", ngayBatDau = ngayBatDau, ngayKetThuc = ngayKetThuc, option = option }));
        }
    }
}
