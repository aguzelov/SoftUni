﻿using AutoMapper;
using Eventures.Data;
using Eventures.Models;
using Eventures.Services;
using Eventures.Services.Contracts;
using Eventures.Web.Filters;
using Eventures.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Eventures.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"));
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
            });

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
            })
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LogoutPath = "/Users/Logout";
                options.LoginPath = "/Users/Login";
                options.AccessDeniedPath = "/Users/Login";
                options.SlidingExpiration = true;
            });

            services.AddAuthentication()
            .AddFacebook(options =>
            {
                options.AppId = this.Configuration["Authentication:Facebook:AppId"];
                options.AppSecret = this.Configuration["Authentication:Facebook:AppSecret"];
            });

            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var mappingConfig = new MapperConfiguration(mc =>
                mc.AddProfile(new MappingProfile())
            );

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddResponseCompression(options => { options.EnableForHttps = true; });

            services.AddScoped<EventsCreateLogActionFilter>();

            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IEventsService, EventsService>();
            services.AddScoped<IOrdersService, OrdersService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDatabaseMigration();

            if (env.IsDevelopment())
            {
                //app.UseExceptionHandler("/Error");
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddFile($"Logs/{this.Configuration.GetSection("ApplicationName")}-{DateTime.UtcNow:dd/MM/yyyy}.txt");

            app.UseHttpsRedirection();
            app.UseResponseCompression();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}