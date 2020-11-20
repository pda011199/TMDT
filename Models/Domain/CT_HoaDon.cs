using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models.Domain
{
    public class CT_HoaDon
    {
        [Key]
        public int MaCTHD { get; set; }
        public int MaHD { get; set; }
        public int MaSp { get; set; }
        public int SoLuong { get; set; }
        public HoaDon HoaDon { get; set; }
        public SanPham SanPham { get; set; }

    }
}
