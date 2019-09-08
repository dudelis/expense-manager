using ExpenseManager.Auth.Concrete;
using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Concrete.EntityFramework;
using ExpenseManager.Shared.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExpenseManager.Server.Extensions
{
    public class CustomUserClaimsPrincipalFactory: UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        private readonly IUserSettingsService _userSettingsManager;
        public CustomUserClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor,
            IUserSettingsService service)
            : base(userManager, roleManager, optionsAccessor)
        {
            _userSettingsManager = service;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            var userSettings = await _userSettingsManager.GetAsync(x => x.UserId == user.UserName);
            if (userSettings != null)
            {
                identity.AddClaim(new Claim(CustomClaimTypes.DefaultProfileGuid, userSettings.DefaultProfileId.ToString() ?? ""));
            }            
            return identity;
        }
    }
}
