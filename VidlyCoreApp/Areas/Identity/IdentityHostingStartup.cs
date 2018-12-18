using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VidlyCoreApp.Areas.Identity.Data;
using VidlyCoreApp.Models;

[assembly: HostingStartup(typeof(VidlyCoreApp.Areas.Identity.IdentityHostingStartup))]
namespace VidlyCoreApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {   // Moved to Startup.cs
            /*
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<VidlyDbContext>(options =>
                    options.UseSqlite("Data Source=vidly.db"));

                 services.AddDefaultIdentity<ApplicationUser>()
                     .AddEntityFrameworkStores<VidlyDbContext>()
                //services.AddIdentity<IdentityUser, IdentityRole>()
                 // services.AddDefaultIdentity<IdentityUser>()
                 //.AddEntityFrameworkStores<VidlyDbContext>()
                 .AddDefaultTokenProviders();            
            });
            */
        }
    }
}