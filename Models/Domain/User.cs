using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models.Domain
{
    public class User:IdentityUser
    {
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public int DiemTichLuy { get; set; }
    }

}
