using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.Auth.Concrete;
using ExpenseManager.Business.Interfaces;
using ExpenseManager.Entities.Concrete;
using ExpenseManager.WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly IProfileService _profileManager;
        private readonly IProfileMemberService _profileMemberManager;
        //private readonly IProfileManager profileManager;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IProfileService profile,
            IProfileMemberService profileMember)
        {
            _userManager = userManager;
            _signinManager = signInManager;
            _profileManager = profile;
            _profileMemberManager = profileMember;
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
            if (!_profileMemberManager.ItemExists(newUser.UserName))
            {
                var profile = new Profile()
                {
                    Name = $"Profile for {newUser.UserName}",
                    ProfileOwner = newUser.UserName,
                    ProfileMembers = new List<ProfileMember>()
                    {
                        new ProfileMember()
                        {
                            UserId = newUser.UserName
                        }
                    }
                };
                _profileManager.Create(profile);
                _profileManager.SaveChanges();
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