using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoAn.Models.Domain;
using Microsoft.AspNetCore.Authorization;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    [Authorize(Roles = "Employee")]
    public class RevenueController : Controller
    {
        private readonly DataContext data;
        public RevenueController(DataContext data)
        {
            this.data = data;
        }
        public IActionResult Index(DateTime ngayBatDau, DateTime ngayKetThuc,int option)
        {
            ViewBag.ngayBatDau = ngayBatDau.ToString("yyyy-MM-dd");
            ViewBag.ngayKetThuc = ngayKetThuc.ToString("yyyy-MM-dd");
            switch (option)
            {
                case 1:
                    List<HoaDon> lhd = data.HoaDon.Where(p => p.TrangThai == true && p.Ngay.CompareTo(ngayBatDau) >= 0 && p.Ngay.CompareTo(ngayKetThuc) <= 0).ToList();
                    ViewBag.tongDoanhThu = lhd.Sum(p => p.TongTien);
                    ViewBag.hoaDon = lhd;
                    ViewBag.m = "Tất cả đơn hàng";
                    return View();
                case 2:
                    List<HoaDon> khd = data.HoaDon.Where(p => p.TinhTrang == true && p.Ngay.CompareTo(ngayBatDau) >= 0 && p.Ngay.CompareTo(ngayKetThuc) <= 0).ToList();
                    ViewBag.tongDoanhThu = khd.Sum(p => p.TongTien);
                    ViewBag.hoaDon = khd;
                    ViewBag.m = "Đơn hàng đã thanh toán";
                    return View();
                case 3:
                    List<HoaDon> jhd = data.HoaDon.Where(p =>p.LoaiTT == 1 && p.TinhTrang == true && p.Ngay.CompareTo(ngayBatDau) >= 0 && p.Ngay.CompareTo(ngayKetThuc) <= 0).ToList();
                    ViewBag.tongDoanhThu = jhd.Sum(p => p.TongTien);
                    ViewBag.hoaDon = jhd;
                    ViewBag.m = "Đơn hàng thanh toán khi nhận hàng";
                    return View();
                case 4:
                    List<HoaDon> hhd = data.HoaDon.Where(p =>p.LoaiTT == 2 && p.TinhTrang == true && p.Ngay.CompareTo(ngayBatDau) >= 0 && p.Ngay.CompareTo(ngayKetThuc) <= 0).ToList();
                    ViewBag.tongDoanhThu = hhd.Sum(p => p.TongTien);
                    ViewBag.hoaDon = hhd;
                    ViewBag.m = "Đơn hàng thanh toán trực tuyến";
                    return View();
                default:
                    DateTime a = DateTime.Today;
                    DateTime b = new DateTime(2020, 1, 1);
                    ViewBag.ngayBatDau = b.ToString("yyyy-MM-dd");
                    ViewBag.ngayKetThuc = a.ToString("yyyy-MM-dd");
                    List<HoaDon> hoaDon = data.HoaDon.Where(p => p.Ngay.CompareTo(b) >= 0 && p.TinhTrang == true).ToList();
                    ViewBag.hoaDon = hoaDon;
                    ViewBag.tongDoanhThu = hoaDon.Sum(p => p.TongTien);
                    return View();
            }
        }
    }
}

