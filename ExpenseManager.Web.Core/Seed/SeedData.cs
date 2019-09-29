using ExpenseManager.Auth.Concrete;
using ExpenseManager.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ExpenseManager.Web.Core.Seed
{
    public class SeedData
    {
        public static void SeedUsers(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ExpenseManagerDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (context.Set<ApplicationUser>().Any())

            {
                var user = new ApplicationUser()
                {
                    Email = "a@b.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "a@b.com"

                };
                userManager.CreateAsync(user, "K2pass!");
            }
        }

    }
}
