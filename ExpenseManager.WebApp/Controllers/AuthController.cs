using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.Auth.Concrete;
using ExpenseManager.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signinManager = signInManager;
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registration)
        {
            if (!ModelState.IsValid)
                return View(registration);
            var newUser = new ApplicationUser()
            {
                FirstName = registration.FirstName,
                LastName = registration.LastName,
                Email = registration.EmailAddress,
                UserName = registration.EmailAddress
            };

            var result = await _userManager.CreateAsync(newUser, registration.Password);
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors.Select(x => x.Description))
                {
                    ModelState.AddModelError("", error);
                }
                return View();
            }
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login, string ReturnUrl)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _signinManager.PasswordSignInAsync(login.EmailAddress, login.Password, login.RememberMe, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Login error!");
                return View();
            }
            if (string.IsNullOrWhiteSpace(ReturnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(ReturnUrl);               
        }
        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signinManager.SignOutAsync();
            if (string.IsNullOrWhiteSpace(returnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(returnUrl);
        }

    }
}