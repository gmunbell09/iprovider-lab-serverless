using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;
using Infraestructure.Dapper.PostgreSQL.Context;
using Infraestructure.Dapper.PostgreSQL.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace serverless_apirest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddAplicacionServices(Configuration);
            services.AddCustomHealthCheck(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
                });
            });
        }
    }

    public static class StartupCustomMethod
    {
        public static IServiceCollection AddAplicacionServices (this IServiceCollection service, IConfiguration configuration) 
        {
            var connectionStrings = new ConnectionStrings();
            configuration.Bind($"ConnectionStrings", connectionStrings);

            var settings = new Settings
            {
                ConnectionStrings = connectionStrings
            };

            service.AddSingleton(settings);
            
            service.AddTransient<IDapperConnection, DapperConnection>();
            service.AddTransient<ICrudRepository, CrudRepository>();

            return service;
        }

        public static IServiceCollection AddCustomHealthCheck(this IServiceCollection service, IConfiguration configuration)
        {
            var healthCheckBuilder = service.AddHealthChecks();

            healthCheckBuilder
                .AddCheck("self", () => HealthCheckResult.Healthy())
                .AddNpgSql(
                    configuration["ConnectionStrings:DefaultConnection"],
                    name: "LocalHostDBCheck",
                    tags: new string[] { "localHostdb" });


            return service;
        }
    }
}
