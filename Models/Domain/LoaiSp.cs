using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models.Domain
{
    public class LoaiSp
    {
        [Key]
        public int MaLoaiSp { get; set; }
        public string TenLoaiSp { get; set; }
        public bool Deleted { get; set; }
        public List<SanPham> SanPhams { get; set; }
    }
}
