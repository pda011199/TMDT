using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models
{
    public class UserChangePasswordModel
    {
        [Key]
        [Required]
        [DataType("Password")]
        [DisplayName("Mật khẩu cũ")]
        public string Password { get; set; }
        [Required]
        [DataType("Password")]
        [DisplayName("Mật khẩu mới")]
        public string NewPassword { get; set; }
        [Required]
        [NotMapped]
        [DataType("Password")]
        [DisplayName("Nhập lại mật khẩu mới")]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu mới và mật khẩu nhập lại không chính xác")]
        public string ConfirmNewPassword { get; set; }
    }
}
