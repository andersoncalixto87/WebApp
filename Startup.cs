using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApp.Data;
using Microsoft.EntityFrameworkCore;
using WebApp.Interfaces;
using WebApp.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using WebApp.Interfaces.Services;
using WebApp.Services;


namespace WebApp
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
            services.AddScoped<IRepositoryCliente, RepositoryCliente>();
            services.AddScoped<IRepositoryProduto, RepositoryProduto>();
            services.AddScoped<IRepositoryUsuario, RepositoryUsuario>();
            services.AddScoped<IServiceEmail, ServiceEmail>();
            //services.AddScoped<IRepositoryVenda, RepositoryVenda>();
            //services.AddScoped<IRepositoryVendaItem, RepositoryVendaItem>();
            //UseSqlServer(connection)
            var connection = Configuration["SqlConnection:SqlConnectionString"];
            services.AddDbContext<WebAppContext>(options => options.UseSqlServer(connection));
            services.AddControllersWithViews();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = "/Usuario/Login"; 
                    options.Cookie.Name = "eSalesCookie"; 
                    options.ExpireTimeSpan = TimeSpan.FromHours(3);
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
