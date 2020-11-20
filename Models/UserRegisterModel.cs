using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models
{
    public class UserRegisterModel
    {
        [Required]
        public string HoTen { get; set; }
        [Key]
        [Required]
        public string Email { get; set; }
        [Required]
        public string DiaChi { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType("Password")]
        public string Password { get; set; }

        [Required]
        [NotMapped]
        [DataType("Password")]
        [Compare("Password", ErrorMessage = "Password and ConfirmPassword not correct")]
        public string ConfirmPassword { get; set; }
    }
}
