using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models.Domain
{
    public class SanPham
    {
        [Key]
        public int MaSp { get; set; }
        public string TenSp { get; set; }
        public LoaiSp LoaiSp { get; set; }
        public int MaLoaiSp { get; set; }
        public string Mota { get; set; }
        public string HinhAnh { get; set; }
        public double Gia { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayTao { get; set; }
        public bool Deleted { get; set; }
    }
}
