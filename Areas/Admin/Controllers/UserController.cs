using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("ADMINISTRATOR")]
    [Authorize("EMPLOYEE")]
    public class UserController : Controller
    {
        DataContext data;
        public UserController(DataContext data)
        {
            this.data = data;
        }
        public IActionResult Index()
        {
            var user = data.Users.ToList();
            return View(user);
        }
    }
}
