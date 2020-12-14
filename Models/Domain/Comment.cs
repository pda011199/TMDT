using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models.Domain
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public virtual SanPham SanPham { get; set; }
        public Nullable<int> MaSp { get; set; }
        public string Text { get; set; }
        public DateTime Ngay { get; set; }
        public int Rating { get; set; }
        public virtual User User { get; set; }
        public string UserId { get; set; }
    }
}
