using System;
using GroupFTennisWebApp.Areas.Identity.Data;
using GroupFTennisWebApp.Models;
using GroupFTennisWebApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(GroupFTennisWebApp.Areas.Identity.IdentityHostingStartup))]
namespace GroupFTennisWebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDefaultIdentity<GroupFTennisWebAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<GroupFTennisWebAppContext>();
            });
        }
    }
}