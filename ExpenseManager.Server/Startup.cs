using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using ExpenseManager.Auth.Concrete;
using ExpenseManager.Auth.Interfaces;
using ExpenseManager.Business.Concrete;
using ExpenseManager.Business.Interfaces;
using ExpenseManager.DataAccess.Concrete.EntityFramework;
using ExpenseManager.DataAccess.Interfaces;
using ExpenseManager.Server.ActionFilters;
using ExpenseManager.Server.CustomMiddlewares;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExpenseManager.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ValidateModelActionFilter>();
            services.AddAutoMapper(typeof(Startup));
            services.AddMvc().AddNewtonsoftJson();
            services.AddControllers();



            services.AddDbContext<ExpenseManagerDbContext>(
                c => c.UseSqlServer(Configuration["connectionStrings:expenseManagerDbConnectionString"]));
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
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            services.AddScoped<IGetClaimsProvider, GetClaimsFromUser>();

            services.AddScoped<IAccountRepository, EfAccountRepository>();
            services.AddScoped<IAccountTypeRepository, EfAccountTypeRepository>();
            services.AddScoped<ICurrencyRepository, EfCurrencyRepository>();
            services.AddScoped<IExpenseRepository, EfExpenseRepository>();
            services.AddScoped<IExpenseCategoryRepository, EfExpenseCategoryRepository>();
            services.AddScoped<IPayeeRepository, EfPayeeRepository>();
            services.AddScoped<IProfileRepository, EfProfileRepository>();
            services.AddScoped<IProfileMemberRepository, EfProfileMemberRepository>();
            services.AddScoped<IUserSettingsRepository, EfUserSettingsRepository>();
            //Adding all the Entity managers, which are to be used in the Controllers
            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IAccountTypeService, AccountTypeManager>();
            services.AddScoped<ICurrencyService, CurrencyManager>();
            services.AddScoped<IExpenseService, ExpenseDataManager>();
            services.AddScoped<IExpenseCategoryService, ExpenseCategoryManager>();
            services.AddScoped<IPayeeService, PayeeManager>();
            services.AddScoped<IProfileService, ProfileManager>();
            services.AddScoped<IProfileMemberService, ProfileMemberManager>();
            services.AddScoped<IUserSettingsService, UserSettingsManager>();

            services.AddResponseCompression(options =>
            {
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { MediaTypeNames.Application.Octet });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseResponseCompression();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseClientSideBlazorFiles<Client.Startup>();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");
            });
        }
    }
}
