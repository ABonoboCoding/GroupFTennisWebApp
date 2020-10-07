using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using GroupFTennisWebApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;
using GroupFTennisWebApp.Areas.Identity.Data;

namespace GroupFTennisWebApp
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
            services.AddDbContext<GroupFTennisWebAppContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));





            //services.AddDbContext<GroupFTennisWebAppContext>(options =>
            //    options.UseSqlServer(
            //         Configuration.GetConnectionString("GroupFTennisWebAppContextConnection")));


            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddIdentity<GroupFTennisWebAppUser, IdentityRole>()
                .AddDefaultUI()
                .AddRoles<IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<GroupFTennisWebAppContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();




            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            CreateRoles(serviceProvider).Wait();

        }

        //creates roles in DB
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Member", "Coach", "Admin" };

            // Create new role for each item in the array
            foreach (var roleName in roleNames)
            {
                bool roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                   await RoleManager.CreateAsync(new IdentityRole(roleName));
                }

            }
        }
    }
}
