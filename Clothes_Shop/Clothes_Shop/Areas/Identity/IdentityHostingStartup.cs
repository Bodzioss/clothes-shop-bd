using System;
using Clothes_Shop.Areas.Identity.Data;
using Clothes_Shop.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Clothes_Shop.Areas.Identity.IdentityHostingStartup))]
namespace Clothes_Shop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BD2SklepAuthContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BD2SklepAuthContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(
                        options =>
                        {
                            options.SignIn.RequireConfirmedAccount = false;
                            options.Password.RequireNonAlphanumeric = false;
                        })
                    .AddEntityFrameworkStores<BD2SklepAuthContext>();
            });
        }
    }
}