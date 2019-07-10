using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Concrete.EntityFramework;
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
        public static void ConfigureDataManagers(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, EfAccountRepository>();
            services.AddScoped<IFunctionTypeService, FunctionTypeManager>();
        }
    }
}
