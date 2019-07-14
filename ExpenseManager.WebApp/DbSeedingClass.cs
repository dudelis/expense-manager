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
                    Code = "USD",
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
                    Code = "RUB",
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
}
