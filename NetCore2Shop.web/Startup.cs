using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore2Shop.Data;
using NetCore2Shop.Data.Interface;
using NetCore2Shop.Models;
using NetCore2Shop.Data.Repositories;

namespace NetCore2Shop.web
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
            services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    p => p.MigrationsAssembly("NetCore2Shop.web")));
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ShopDbContext>()
                .AddDefaultTokenProviders();
            AddDependencies(services);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "admin",
                    template: "{admin:exists}/{controller=Home}/{action=Index}/{id?}");
            });
        }

        public IServiceCollection AddDependencies(IServiceCollection service)
        {
            service.AddScoped<ShopDbContext>();
            service.AddScoped<IProductRepo, ProductRepo>();
            service.AddScoped<IAddressRepo, AddressRepo>();
            service.AddScoped<IBrandRepo, BrandRepo>();
            service.AddScoped<ICatagoryRepo, CatagotyRepo>();
            service.AddScoped<ICityRepo, CityRepo>();
            service.AddScoped<ICommentRepo, CommentRepo>();
            service.AddScoped<IImageRepo, ImageRepo>();
            service.AddScoped<IOrderDetailRepo, OrderDetailRepo>();
            service.AddScoped<IOrderRepo, OrderRepo>();
            service.AddScoped<IProvinceRepo, ProvinceRepo>();
            return service;
        }
    }
}
