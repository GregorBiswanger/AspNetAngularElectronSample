using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronNET.API;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Server", Version = "v1" });
            });

            // Hinzufügen für Cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularDevClient", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Server v1"));
                
                // Hinzufügen für Cors zur Entwicklungszeit
                app.UseCors("AllowAngularDevClient");
            }
            
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            // Hinzufügen für wwwroot-Support
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                
                // Hinzufügen für direkten Angular Routing support
                endpoints.MapFallbackToFile("/index.html");
            });

            // Öffne Fenster, wenn es als Electron.NET App läuft
            if (HybridSupport.IsElectronActive)
            {
                Task.Run(async () => await Electron.WindowManager.CreateWindowAsync());
            }
        }
    }
}
