using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn.Models.Domain;

namespace DoAn.Models
{
    public class ProductToCart
    {
        public SanPham SanPham { get; set; }
        public int SoLuong { get; set; }
    }
}
