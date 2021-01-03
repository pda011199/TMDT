using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models
{
    public class ResetPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType("Password")]
        public string Password { get; set; }
        [Required]
        [DataType("Password")]
        [Compare("Password",ErrorMessage ="Mật khẩu mới và mật khẩu nhập lại phải chính xác")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}
