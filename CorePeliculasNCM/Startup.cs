using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePeliculasNCM.Data;
using CorePeliculasNCM.Helpers;
using CorePeliculasNCM.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MvcCore
{
    public class Startup
    {
        IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            String cadenasql = this.config.GetConnectionString("casasqlhospital");
            services.AddSingleton<PathProvider>();
            services.AddSingleton<UploadService>();
            services.AddTransient<IRepository, RepositorySQL>();
            services.AddDbContext<HospitalContext>(options => options.UseSqlServer(cadenasql));
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(15);
            });
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
