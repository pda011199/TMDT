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
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using DoAn.Models.Email;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DoAn.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly DataContext data;
        private readonly ISendMailService sendMailService;
        private readonly ILogger<AccountController> logger;

        public AccountController(UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager, DataContext data, ISendMailService sendMailService, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.sendMailService = sendMailService;
            _mapper = mapper;
            this.data = data;
            this.logger = logger;
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
            await _userManager.AddToRoleAsync(user, "Customer");

            return RedirectToAction("Index", "Home");
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
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }
            var resutl = await _signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, userModel.Rememberme, false);
            if (resutl.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Invalid Email or Password");
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
            var x = data.HoaDon.Where(p => p.UserId == user.Id).ToList();
            foreach(var item in x)
            {
                item.KhuyenMai = data.MaKhuyenMai.Find(item.MaKhuyenMai);
            }
            ViewBag.hoaDon = x;
            return View();
        }
        public IActionResult ProductFavor()
        {
            string user = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var dsspyt = data.SanPhamYeuThich.Where(p => p.UserId == user).ToList();
            foreach (var i in dsspyt)
            {
                i.SanPham = data.SanPham.Find(i.MaSp);
            }
            ViewBag.spyt = dsspyt;
            return View();
        }

        public async Task<IActionResult> CancelPurchaseAsync(int id)
        {
            HoaDon hd = data.HoaDon.Where(p => p.MaHD == id).FirstOrDefault();
            hd.TrangThai = false;
            data.Entry(hd).State = EntityState.Modified;
            data.SaveChanges();

            User user = await _userManager.GetUserAsync(User);
            ViewBag.user = user;
            ViewBag.hoaDon = data.HoaDon.Where(p => p.UserId == user.Id).ToList();
            return RedirectToAction("DetailUser", "Account");
        }
        [Authorize]
        public async Task<IActionResult> EditUserAsync()
        {
            User user = await _userManager.GetUserAsync(User);
            return View(user);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditUserConfirmAsync(User user)
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
            return View("EditUser", user);
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(UserChangePasswordModel userModel)
        {
            if (ModelState.IsValid)
            {
                var us = await _userManager.GetUserAsync(User);
                if (us == null)
                {
                    RedirectToAction("Login");
                }
                var result = await _userManager.ChangePasswordAsync(us, userModel.Password, userModel.NewPassword);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(userModel);
                }
                await _signInManager.RefreshSignInAsync(us);
                return View("ChangePasswordConfirmation");
            }

            return View(userModel);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string token, string email)
        {
            if (token == null || email == null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var us = await _userManager.FindByEmailAsync(model.Email);
                if (us != null)
                {
                    var result = await _userManager.ResetPasswordAsync(us, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return View("ResetPasswordConfirmation");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(model);
                }
                return View("ResetPasswordConfirmation");
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var us = await _userManager.FindByEmailAsync(model.Email);
            if (us == null)
            {
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(us);
            var callback = Url.Action(nameof(ResetPassword), "AccountController", new {  email = us.Email, token }, Request.Scheme);

            MailContent content = new MailContent
            {
                To = us.Email,
                Subject = "Reset Password Token",
                Body = callback
            };
            await sendMailService.SendMail(content);
            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }
    }
}
