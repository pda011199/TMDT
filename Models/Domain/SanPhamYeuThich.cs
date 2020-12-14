using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models.Domain
{
    public class SanPhamYeuThich
    {
        [Key]
        public string UserId { get; set; }
        public int MaSp { get; set; }
        public User User { get; set; }
        public SanPham SanPham { get; set; }
    }
}
