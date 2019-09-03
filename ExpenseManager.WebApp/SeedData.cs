using ExpenseManager.Auth.Concrete;
using ExpenseManager.DataAccess.Concrete.EntityFramework;
using ExpenseManager.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.WebApp
{
    public static class SeedData
    {
        public static void SeedCurrency(IServiceProvider provider)
        {
            var context = provider.GetRequiredService<ExpenseManagerDbContext>();
            if (!context.Currencies.Any())
            {
                var currencies = new List<Currency>
            {
                new Currency()
                {
                    Code  = "USD",
                    Name = "US Dollar"
                },
                new Currency()
                {
                    Code = "EUR",
                    Name = "Euro"
                },
                new Currency()
                {
                    Code = "UAH",
                    Name = "Ukrainian Hryvnya"
                },
                new Currency()
                {
                    Code  = "RUB",
                    Name = "Russian Rubbles"
                },
                new Currency()
                {
                    Code = "CHF",
                    Name = "Swiss Frank"
                }
            };
                context.Currencies.AddRange(currencies);
                context.SaveChanges();

            }
        }
        public static void SeedUsers(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ExpenseManagerDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (!context.Users.Any())
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
