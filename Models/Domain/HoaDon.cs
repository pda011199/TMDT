using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models.Domain
{
    public class HoaDon
    {
        [Key]
        public int MaHD { get; set; }
        public DateTime Ngay { get; set; }
        public Nullable<DateTime> NgayThuTien { get; set; }
        public string UserId { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public double TamTinh { get; set; }
        public double TongTien { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string MaKhuyenMai { get; set; }
        public double VAT { get; set; } // 10%
        public byte GiaoHang { get; set; } //3-Da giao hang  //2-Dang giao hang  //1-chua giao hang
        public byte LoaiTT { get; set; }//1-thanh toan binh thuong 2-thanh toan bang paypal
        public bool TinhTrang { get; set; }//true-da thanh toan  //false-chua thanh toan
        public Nullable<bool> TrangThai { get; set; }//null-dang doi;  true-thanh cong ;false-da huy 
        public List<CT_HoaDon> CT_HoaDon { get; set; }
        public User User { get; set; }
        public MaKhuyenMai KhuyenMai { get; set; }
    }
}
