using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Areas.Admin.Models
{
    public class EditRole
    {
        public EditRole()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }

        [Required(ErrorMessage = "Chưa nhập tên role")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
