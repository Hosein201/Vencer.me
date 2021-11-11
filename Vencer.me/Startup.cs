using AutoMapper;
using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Serilog;
using Services;
using Services.Middlewares;
using Services.SignalR;
using Services.Swagger;
using System;
using WebFramework;


namespace Vencer.me
{
    public class Startup
    {

        private readonly SiteSettings _siteSettings;
        public IConfiguration Configuration { get; }

        [Obsolete]
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _siteSettings = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddEnvironmentVariables().Build();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddContextVerncer(_siteSettings.ConnectionStrings);// db Context
            services.AddCustomIdentity(_siteSettings.IdentitySettings);// identity
            services.AddCustomeMvc();// Minimal Mvc
            services.AddJwtAuthentication(_siteSettings.JwtSettings);// Jwt
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews(options => options.Filters.Add(typeof(FilterApiAction)))
                .AddRazorRuntimeCompilation()
                .AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddCustomeSignalR();
            services.AddSingleton(Log.Logger);
            services.AddMemoryCache();
            services.AddElasticsearch(_siteSettings.ElasticConfiguration);

            services.AddCustomSwagger(_siteSettings.Swagger);
            //services.AddServiceParbad(siteSettings.ParbadConfiguration);
            services.AddAuthentication(IISServerDefaults.AuthenticationScheme);
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
           // services.AddQuartz();
            return services.BuildAutofacServiceProvider();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.IntializeDatabase();
            app.UseSerilogRequestMiddleware();
            app.UseCustomExceptionHandler();
            app.UseHsts(env);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();
            app.CustomUseEndpoints();
            app.UseCustomSwagger();
        }
    }
}
