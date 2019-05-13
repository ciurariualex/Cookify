using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Core.Context;
using Core.Interfaces;
using Core.Services;
using Core.Models.Identity;
using Core.Models.Base;
using System;
using System.Threading.Tasks;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SchedulerContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(opt =>
            {
                opt.AddApplicationAuthorisationPolicies();
            });

            services.AddDistributedMemoryCache();
            services.AddSession();

            string dbConnection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SchedulerContext>(
                options => options.UseSqlServer(dbConnection), ServiceLifetime.Scoped);

            services.AddScoped<IMobileApplicationUserService, MobileApplicationUserService>();
            services.AddScoped<IApplicationUserService, ApplicationUserService>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "MyArea",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //CreateRoles(serviceProvider).Wait();
        }

        //private async Task CreateRoles(IServiceProvider serviceProvider)
        //{
        //    var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //    var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        //    string[] roleNames = { "Admin" };
        //    IdentityResult roleResult;

        //    foreach (var roleName in roleNames)
        //    {
        //        //creating the roles and seeding them to the database
        //        var roleExist = await RoleManager.RoleExistsAsync(roleName);
        //        if (!roleExist)
        //        {
        //            roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
        //        }
        //    }

        //    //creating a super user who could maintain the web app
        //    var poweruser = new ApplicationUser
        //    {
        //        UserName = Configuration.GetSection("UserSettings")["UserEmail"],
        //        Email = Configuration.GetSection("UserSettings")["UserEmail"]
        //    };

        //    string UserPassword = Configuration.GetSection("UserSettings")["UserPassword"];
        //    var _user = await UserManager.FindByEmailAsync(Configuration.GetSection("UserSettings")["UserEmail"]);
        //    if (_user == null)
        //    {
        //        var createPowerUser = await UserManager.CreateAsync(poweruser, UserPassword);
        //        if (createPowerUser.Succeeded)
        //        {
        //            //here we tie the new user to the "Admin" role 
        //            await UserManager.AddToRoleAsync(poweruser, "Admin");
        //        }
        //    }
        //}
    }
}
