using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BlogUI
{
    public class Startup
    {
        public readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutofac();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/Account/Login";
                    option.LogoutPath = "/Account/Index";
                    option.Cookie.Name = "UserCookie";
                    option.SlidingExpiration = true;
                });
            services.AddAuthorization();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error", "?code={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                #region Auth route
                endpoints.MapControllerRoute(
                    name: "register",
                    pattern: "kaydol",
                    defaults: new { controller = "Register", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "login",
                    pattern: "giris-yap",
                    defaults: new { controller = "Account", action = "Login" });

                endpoints.MapControllerRoute(
                    name: "login",
                    pattern: "cikis-yap",
                    defaults: new { controller = "Account", action = "Logout" });
                #endregion

                #region Blog route
                endpoints.MapControllerRoute(
                    name: "blogDetail",
                    pattern: "blog/{id:int}",
                    defaults: new { controller = "Blog", action = "BlogDetails" });

                endpoints.MapControllerRoute(
                    name: "blogHome",
                    pattern: "blog",
                    defaults: new { controller = "Blog", action = "Index" });

                #endregion

                #region About route
                endpoints.MapControllerRoute(
                    name: "about",
                    pattern: "hakkimizda",
                    defaults: new { controller = "About", action = "Index" }
                );
                #endregion

                #region Contact route

                endpoints.MapControllerRoute(
                    name: "contact",
                    pattern: "iletisim",
                    defaults: new { controller = "Contact", action = "Index" }
                );

                #endregion

                #region Writer admin panel area route

                endpoints.MapAreaControllerRoute(
                    areaName: "Writer",
                    name: "Writer",
                    pattern: "yazar/bloglar",
                    defaults: new { area = "Writer", controller = "Blog", action = "GetBlogListByWriter" }
                );
                endpoints.MapAreaControllerRoute(
                    areaName: "Writer",
                    name: "Writer",
                    pattern: "yazar",
                    defaults: new { area = "Writer", controller = "Writer", action = "Index" }
                );
                endpoints.MapAreaControllerRoute(
                    areaName: "Writer",
                    name: "Writer",
                    pattern: "yazar/anasayfa",
                    defaults: new { area = "Writer", controller = "Writer", action = "Index" }
                );

                endpoints.MapAreaControllerRoute(
                    areaName: "Writer",
                    name: "writerBlogAdd",
                    pattern: "yazar/blog-ekle",
                    defaults: new { area = "Writer", controller = "Blog", action = "BlogAdd" }
                );
                endpoints.MapAreaControllerRoute(
                    name: "WriterArea",
                    areaName: "Writer",
                    pattern: "Writer/{controller=Writer}/{action=Index}/{id?}"
                );
                #endregion


                endpoints.MapControllerRoute(
                    name: "home1",
                    pattern: "anasayfa",
                    defaults: new { controller = "Blog", action = "Index" }
                );
                endpoints.MapControllerRoute(
                    name: "home",
                    pattern: "",
                    defaults: new { controller = "Blog", action = "Index" }
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Blog}/{action=Index}/{id?}"
                );


            });
        }
    }
}
