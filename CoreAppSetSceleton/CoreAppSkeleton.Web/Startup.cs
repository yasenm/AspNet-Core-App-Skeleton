﻿using CoreAppSkeleton.Data.Infrastructure.Mapping;
using CoreAppSkeleton.Data.Models;
using CoreAppSkeleton.Data.Services.Contracts;
using CoreAppSkeleton.Data.Services.Lib;
using CoreAppSkeleton.DataConsole;
using CoreAppSkeleton.DataConsole.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace CoreAppSkeleton.Web
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            _config = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Automapper configuration initialization
            AutoMapperConfig.Init();

            services.AddSingleton(_config);

            // Custom services registretion
            services.AddScoped<ICoreAppSkeletonData, CoreAppSkeletonData>();
            services.AddScoped<ICoreAppModelService, CoreAppModelService>();
            services.AddScoped<IPostService, PostService>();

            services.AddTransient<CoreAppSkeletonSeedData>();

            services.AddDbContext<CoreAppSkeletonDbContext>();

            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Cookies.ApplicationCookie.LoginPath = "/auth/login";
            })
            .AddEntityFrameworkStores<CoreAppSkeletonDbContext>();

            services.AddMvc(config =>
            {
                if (_env.IsProduction())
                {
                    config.Filters.Add(new RequireHttpsAttribute());
                }
            })
            .AddJsonOptions(config =>
            {
                config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger, CoreAppSkeletonSeedData seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                logger.AddDebug(LogLevel.Information);
            }
            else
            {
                logger.AddDebug(LogLevel.Error);
            }

            app.Use(async (context, next) =>
            {
                // logic can go here
                await next.Invoke();
                logger.AddDebug(LogLevel.Debug);
                // and logic can go here as well
            });

            app.UseIdentity();

            app.UseStaticFiles();

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" });
            });

            seeder.SeedData().Wait();
        }
    }
}
