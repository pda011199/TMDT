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
        public string UserId { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public double TongTien { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public Nullable<bool> TrangThai { get; set; }
        public bool Deleted { get; set; }
        public List<CT_HoaDon> CT_HoaDon { get; set; }
        public User User { get; set; }
    }
}
