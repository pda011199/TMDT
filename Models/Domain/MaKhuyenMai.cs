using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models.Domain
{
    public class MaKhuyenMai
    {
        [Key]
        public string Id { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int GiaTri { get; set; }
    }
}
