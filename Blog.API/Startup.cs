using Autofac.Extensions.DependencyInjection;
using Blog.API.Middlewares;
using Business.Mapping;
using Business.ServiceExtension;
using Core.CrossCuttingConcerns;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using DataAccess.IdentityContext;

namespace Blog.API
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
            services.AddAutofac();
            services.AddAutoMapper(Assembly.GetAssembly(typeof(ObjectMapper)));

            services.AddDbContext<BlogContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"), opt =>
                {
                    opt.MigrationsAssembly("DataAccess");
                });
            });
            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"), opt =>
                {
                    opt.MigrationsAssembly("DataAccess");
                });
            });
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();

            services.ConfigureService();
            ServiceTool.Create(services);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<CustomErrorMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
