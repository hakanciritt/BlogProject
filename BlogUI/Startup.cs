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
                    defaults: new { controller = "Login", action = "Index" });
                #endregion

                #region Blog route
                endpoints.MapControllerRoute(
                    name: "blogDetail",
                    pattern: "blog/detay/{id:int}",
                    defaults: new { controller = "Blog", action = "BlogDetails" });


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

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );

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
            });
        }
    }
}
