using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.Auth.Concrete;
using ExpenseManager.Business.Interfaces;
using ExpenseManager.Entities.Concrete;
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
        private readonly IUserSettingsService _userSettingsManager;
        private readonly IProfileService _profileServiceManager;

        public AuthorizeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IUserSettingsService userService, IProfileService profileService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userSettingsManager = userService;
            _profileServiceManager = profileService;
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
                return BadRequest(result.Errors.FirstOrDefault()?.Description);
            ///TODO: Return Success to redirect to Login page.
            ///

            var profile = new Profile()
            {
                Name = $"Default profile for {user.UserName}",
                ProfileOwner = user.UserName,
                ProfileMembers = new List<ProfileMember>()
                {
                    new ProfileMember()
                    {
                        UserId = user.UserName
                    }
                },
                ProfileConfiguration = new ProfileConfiguration(),
                UserSettings = new List<UserSettings>()
                {
                    new UserSettings()
                    {
                        UserId = user.UserName
                    }
                }
                
            };
            await _profileServiceManager.CreateAsync(profile);
            await _profileServiceManager.SaveChangesAsync();
            return Ok();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
        [HttpGet]
        public UserInfoModel UserInfo()
        {
            var model = new UserInfoModel()
            {
                IsAuthenticated = User.Identity.IsAuthenticated,
                UserName = User.Identity.Name,
                ExposedClaims = User.Claims
                    //Optionally: filter the claims you want to expose to the client
                    //.Where(c => c.Type == "test-claim")
                    .ToDictionary(c => c.Type, c => c.Value)
            };

            return model;
        }
    }
}