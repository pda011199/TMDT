using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAn.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using DoAn.Models;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace DoAn.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    [Authorize(Roles = "Employee")]

    public class UserController : Controller
    {
        DataContext data;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public UserController(DataContext data, UserManager<User> userManager,IMapper mapper)
        {
            this.data = data;
            this._userManager = userManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var user = data.Users.ToList();
            return View(user);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(UserRegisterModel userModel,string Role)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }
            var user = _mapper.Map<User>(userModel);
            user.UserName = userModel.Email;
            user.DiemTichLuy = 0;
            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View(userModel);
            }
            await _userManager.AddToRoleAsync(user, Role);

            return RedirectToAction("Index");
        }
        public IActionResult Edit(string id)
        {
            User us = data.Users.Find(id);
            return View(us);
        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                User us = data.Users.Find(user.Id);
                us.HoTen = user.HoTen;
                us.DiaChi = user.DiaChi;
                us.PhoneNumber = user.PhoneNumber;
                data.Entry(us).State = EntityState.Modified;
                data.SaveChanges();
                ViewBag.Status = 1;

            }
            return RedirectToAction("Index");
        }
    }
}
