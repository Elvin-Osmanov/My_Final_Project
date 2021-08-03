using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restabook.Data;
using Restabook.Data.Entities;
using Restabook.Services;

namespace Restabook
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
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            }).AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;

                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);


            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

            services.AddTransient<LayoutViewModelService>();
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Member_Auth";
                options.DefaultSignInScheme = "Member_Auth";
            })
            .AddCookie("Member_Auth", options =>
            {
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/login";
            })
            .AddCookie("Moderator_Auth", options =>
            {
                options.LoginPath = "/manage/account/login";
                options.AccessDeniedPath = "/manage/account/login";
            })
           .AddCookie("Admin_Auth", options =>
           {
               options.LoginPath = "/manage/account/login";
               options.AccessDeniedPath = "/manage/account/login";
           });
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5);
                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                var area = context.Request.RouteValues["area"];
                string scheme = null;

                if (area == null)
                {
                    foreach (var item in context.Request.Cookies)
                    {
                        if (item.Key.Contains("Member_Auth"))
                        {
                            scheme = "Member_Auth";
                            break;
                        }
                    }
                }
                else
                {
                    foreach (var item in context.Request.Cookies)
                    {
                        if (item.Key.Contains("Admin_Auth"))
                        {
                            scheme = "Admin_Auth";
                            break;
                        }
                    }
                }

                if (scheme != null)
                {
                    var result = await context.AuthenticateAsync(scheme);
                    if (result.Succeeded)
                    {
                        context.User = result.Principal;
                    }
                }

                await next();

              
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
