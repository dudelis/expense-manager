using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.Auth.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.WebApp.ViewComponents
{
    public class LoginStatus : ViewComponent
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginStatus(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                return View("LoggedIn", user);
            }
            else
            {
                return View();
            }
        }
    }
}