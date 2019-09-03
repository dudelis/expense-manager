using ExpenseManager.Auth.Concrete;
using ExpenseManager.Business.Concrete;
using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Concrete.EntityFramework;
using ExpenseManager.DataAccess.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseManager.Web.Core.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void ConfigureDataManagers(this IServiceCollection services)
        {
            //Adding Data Access for Repository - SQL Implementation
            services.AddScoped<IAccountRepository, EfAccountRepository>();
            services.AddScoped<IAccountTypeRepository, EfAccountTypeRepository>();
            services.AddScoped<ICurrencyRepository, EfCurrencyRepository>();
            services.AddScoped<IExpenseRepository, EfExpenseRepository>();
            services.AddScoped<IExpenseCategoryRepository, EfExpenseCategoryRepository>();
            services.AddScoped<IPayeeRepository, EfPayeeRepository>();
            services.AddScoped<IProfileRepository, EfProfileRepository>();
            services.AddScoped<IProfileMemberRepository, EfProfileMemberRepository>();
            //Adding all the Entity managers, which are to be used in the Controllers
            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IAccountTypeService, AccountTypeManager>();
            services.AddScoped<ICurrencyService, CurrencyManager>();
            services.AddScoped<IExpenseService, ExpenseDataManager>();
            services.AddScoped<IExpenseCategoryService, ExpenseCategoryManager>();
            services.AddScoped<IPayeeService, PayeeManager>();
            services.AddScoped<IProfileService, ProfileManager>();
            services.AddScoped<IProfileMemberService, ProfileMemberManager>();
        }
        public static void ConfigureIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ExpenseManagerDbContext>();
            
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;
                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;
                // User settings
                options.User.RequireUniqueEmail = true;
            });
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(150);
                options.LoginPath = "/Login";
                options.AccessDeniedPath = "/Login";
                options.SlidingExpiration = true;
            });
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["connectionStrings:expenseManagerDbConnectionString"];
            services.AddDbContext<ExpenseManagerDbContext>(c => c.UseSqlServer(connectionString));
        }
    }
}
