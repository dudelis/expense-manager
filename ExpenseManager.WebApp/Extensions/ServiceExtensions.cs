using ExpenseManager.Business.Concrete;
using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Concrete.EntityFramework;
using ExpenseManager.DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.WebApp.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["connectionStrings:expenseManagerDbConnectionString"];
            services.AddDbContext<ExpenseManagerDbContext>(c => c.UseSqlServer(connectionString));
        }
        public static void ConfigureIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ExpenseManagerDbContext>();
        }
        public static void ConfigureDataManagers(this IServiceCollection services)
        {
            //Adding Data Access for Repository - SQL Implementation
            services.AddScoped<IRepositoryWrapper, EfRepositoryWrapper>();
            //Adding all the Entity managers, which are to be used in the Controllers
            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IAccountTypeService, AccountTypeManager>();
            services.AddScoped<ICurrencyService, CurrencyManager>();
            services.AddScoped<IExpenseService, ExpenseDataManager>();
            services.AddScoped<IExpenseCategoryService, ExpenseCategoryManager>();
            services.AddScoped<IPayeeService, PayeeManager>();
        }
    }
}
