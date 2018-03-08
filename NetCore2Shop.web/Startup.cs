using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
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
using NetCore2Shop.Ioc;
using NetCore2Shop.Service.Impl;
using NetCore2Shop.Service.Interface;

namespace NetCore2Shop.web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
//        public IServiceProvider ConfigureServices(IServiceCollection services)
//        {
//            services.AddDbContext<ShopDbContext>(options =>
//                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
//                    p => p.MigrationsAssembly("NetCore2Shop.web")));
//            //AddDependencies(services);
//            services.AddMvc();
//            return RegisterAutofac(services);
//        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    p => p.MigrationsAssembly("NetCore2Shop.web")));
            AddDependencies(services);
            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(10);
                option.Cookie.HttpOnly = true;
            });
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();
        }

        private IServiceProvider  RegisterAutofac(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.Populate(services);
            var assembly = this.GetType().GetTypeInfo().Assembly;
            builder.RegisterType<AppUserRepo>().InstancePerLifetimeScope().PropertiesAutowired();;
//            builder.RegisterAssemblyTypes(assembly)
//                .Where(type =>
//                    typeof(IDependency).IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract)
//                .AsImplementedInterfaces()
//                .InstancePerLifetimeScope().EnableInterfaceInterceptors().InterceptedBy(typeof(AopInterceptor));
            builder.RegisterAssemblyTypes(assembly)
                .Where(type =>
                    typeof(IDependency).IsAssignableFrom(type) && !type.GetTypeInfo().IsAbstract)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            this.ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(this.ApplicationContainer);
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

            app.UseSession();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
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
            service.AddScoped<IAppUserRepo, AppUserRepo>();
            service.AddScoped<IAppUserService, AppUserServiceImpl>();
            return service;
        }
    }
}
