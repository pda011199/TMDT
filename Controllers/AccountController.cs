using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DoAn.Helper;
using DoAn.Models;
using DoAn.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DoAn.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly DataContext data;
        public AccountController(UserManager<User> userManager,IMapper mapper, SignInManager<User> signInManager, DataContext data)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            this.data = data;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterModel userModel)
        {
            if(!ModelState.IsValid)
            {
                return View(userModel);
            }
            var user = _mapper.Map<User>(userModel);
            user.UserName = userModel.Email;
            var result = await _userManager.CreateAsync(user, userModel.Password);
            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View(userModel);
            }
            await _userManager.AddToRoleAsync(user, "Customer");

            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginModel userModel, string returnUrl = null)
        {
            if(!ModelState.IsValid)
            {
                return View(userModel);
            }
            var resutl = await _signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, userModel.Rememberme, false);
            if(resutl.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("","Invalid Email or Password");
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        public async Task<IActionResult> DetailUserAsync()
        {
            User user = await _userManager.GetUserAsync(User);
            ViewBag.user = user;
            ViewBag.hoaDon = data.HoaDon.Where(p => p.UserId == user.Id).ToList();
            return View();
        }
        [HttpGet("Account/{id}")]
        public async Task<IActionResult> CancelPurchaseAsync(int id)
        {
            HoaDon hd = data.HoaDon.Where(p=> p.MaHD == id).FirstOrDefault();
            hd.TrangThai = false;
            data.Entry(hd).State = EntityState.Modified;
            data.SaveChanges();

            User user = await _userManager.GetUserAsync(User);
            ViewBag.user = user;
            ViewBag.hoaDon = data.HoaDon.Where(p => p.UserId == user.Id).ToList();
            return RedirectToAction("DetailUser","Account");
        }
        public async Task<IActionResult> EditUserAsync()
        {
            User user = await _userManager.GetUserAsync(User);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditUserConfirmAsync( User user)
        {
            if (ModelState.IsValid)
            {
                User us = await _userManager.GetUserAsync(User);
                us.HoTen = user.HoTen;
                us.DiaChi = user.DiaChi;
                us.PhoneNumber = user.PhoneNumber;
                await _userManager.UpdateAsync(us);
                ViewBag.Status = 1;

            }
            return View("EditUser",user);
        }
    }
}
