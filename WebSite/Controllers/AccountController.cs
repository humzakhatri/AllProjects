using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _UserManager;
        private readonly SignInManager<IdentityUser> _SignInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _UserManager = userManager;
            _SignInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PerformLogin(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
                return View(loginModel);
            var user = await _UserManager.FindByNameAsync(loginModel.UserName);
            if (user != null)
            {
                var result = await _SignInManager.PasswordSignInAsync(user, loginModel.Password, true, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginModel.ReturnUrl))
                        return RedirectToAction("Index", "Home");
                    return Redirect(loginModel.ReturnUrl);
                }
                ModelState.AddModelError("", "Unable to login with provided credentials.");
            }
            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> PerformRegister(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
                return View(registerModel);
            var user = new IdentityUser(registerModel.UserName);
            var result = await _UserManager.CreateAsync(user, registerModel.Password);
            if (result.Succeeded)
            {
                return await PerformLogin(new LoginModel() { UserName = registerModel.UserName, Password = registerModel.Password });
            }
            return RedirectToAction("Index");
        }
    }
}
