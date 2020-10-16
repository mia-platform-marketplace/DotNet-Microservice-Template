using System;
using MiaServiceDotNetLibrary;
using MiaServiceDotNetLibrary.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace App
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
            services.AddControllers();
            StartupUtils.ConfigureMiaLibraryServices(services, Configuration);
            StartupUtils.ConfigureDocs(services, new OpenApiInfo
            {
                Version = "v1",
                Title = AppDomain.CurrentDomain.FriendlyName, 
                Description = "Template microservice."
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.Use(StartupUtils.RouteInjections(app));

            StartupUtils.UseSwagger(app);

            app.UseRequestResponseLoggingMiddleware();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
