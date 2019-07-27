using ExpenseManager.DataAccess.Concrete.EntityFramework;
using ExpenseManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.WebApp
{
    public static class DbSeedingClass
    {
        public static void SeedData(this ExpenseManagerDbContext context)
        {
            var currencies = new List<Currency>
            {
                new Currency()
                {
                    Id  = "USD",
                    Name = "US Dollar"
                },
                new Currency()
                {
                    Id = "EUR",
                    Name = "Euro"
                },
                new Currency()
                {
                    Id = "UAH",
                    Name = "Ukrainian Hryvnya"
                },
                new Currency()
                {
                    Id  = "RUB",
                    Name = "Russian Rubbles"
                },
                new Currency()
                {
                    Id = "CHF",
                    Name = "Swiss Frank"
                }

            };
            context.Currencies.AddRange(currencies);
            context.SaveChanges();
        }
    }
}
