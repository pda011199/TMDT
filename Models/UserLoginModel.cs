using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models
{
    public class UserLoginModel
    {
        [Key]
        [Required]

        public string Email { get; set; }
        [Required]
        [DataType("Password")]
        public string Password { get; set; }
        public bool Rememberme { get; set; }
    }
}
