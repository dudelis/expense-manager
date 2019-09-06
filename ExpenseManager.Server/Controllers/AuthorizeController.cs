using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.Auth.Concrete;
using ExpenseManager.Server.ActionFilters;
using ExpenseManager.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthorizeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidateModelActionFilter))]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
                return BadRequest("User does not exist");
            var singInResult = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!singInResult.Succeeded)
                return BadRequest("Invalid password");

            await _signInManager.SignInAsync(user, model.RememberMe);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.UserName
            };
            user.UserName = model.UserName;
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError("errors", error.Description);
                return BadRequest(ModelState);
            }
            ///TODO: Return Success to redirect to Login page.
            return await Login(new LoginModel
            {
                UserName = model.UserName,
                Password = model.Password
            });
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}