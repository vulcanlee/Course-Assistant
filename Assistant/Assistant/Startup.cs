using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Assistant.Data;
using Assistant.Models;
using Microsoft.EntityFrameworkCore;
using Assistant.Extensions;
using Blazored.Modal;
using Blazored.Toast;
using Microsoft.AspNetCore.Authentication.Cookies;
using Assistant.Helpers;

namespace Assistant
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            // 加入使用 EF Core 來存取 SQLite 資料庫
            services.AddDbContext<MyDbContext>(options =>
            {
                //options.UseSqlite("Data Source=CourseAssistant.db");
                options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CourseAssistant; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            });

            services.AddCourseAssistantService();

            services.AddBlazoredModal();
            services.AddBlazoredToast();

            #region 加入使用 Cookie 認證需要的宣告
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            MyDbContext myDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            myDbContext.Database.Migrate();

            #region Seed
            var foo = myDbContext.CourseUsers.FirstOrDefault(x => x.Account == "vulcan");
            if (foo == null)
            {
                Guid fooGuid = Guid.NewGuid();
                myDbContext.CourseUsers.Add(new CourseUser()
                {
                    Account = "vulcan",
                    IsAdmin = true,
                    Name = "Vulcan Lee",
                    PasswordHash = PasswordHelper.GetPassowrdHash(fooGuid, "123"),
                    Salt = fooGuid,
                    Roles = "",
                    Created = DateTime.Now,
                    OrderCode = 9999
                });
                myDbContext.SaveChanges();
            }
            #endregion

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // ******
            // BLAZOR COOKIE Auth Code (begin)
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            // BLAZOR COOKIE Auth Code (end)
            // ******

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

        }
    }
}
