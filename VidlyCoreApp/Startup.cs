using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using VidlyCoreApp.Areas.Identity.Data;
using VidlyCoreApp.Models;

namespace VidlyCoreApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<VidlyDbContext>(options =>
                    options.UseSqlite("Data Source=vidly.db"));

            services.AddDefaultIdentity<ApplicationUser>()
                     .AddEntityFrameworkStores<VidlyDbContext>()
                     .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    "CanManageCustomers",
                    policyBuilder => policyBuilder
                        .RequireClaim("CanManageCustomers"));
                options.AddPolicy(
                    "CanManageVideos",
                    policyBuilder => policyBuilder
                        .RequireClaim("CanManageVideos"));
                options.AddPolicy(
                    "CanManageInventory",
                    policyBuilder => policyBuilder
                        .RequireClaim("CanManageInventory"));
                options.AddPolicy(
                    "CanManageContentProviders",
                    policyBuilder => policyBuilder
                        .RequireClaim("CanManageContentProviders"));
            });

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            var logger = loggerFactory.CreateLogger<ConsoleLogger>();
            logger.LogInformation("Executing Configure()");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
