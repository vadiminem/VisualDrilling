using BackendAPI.Interfaces;
using BackendAPI.Mapping;
using BackendAPI.Migrations;
using BackendAPI.Repositories;
using BackendAPI.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace BackendAPI
{
    public class Startup
    {
        private PostgresSettings postgresSettings;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            postgresSettings = Configuration.GetSection("DatabaseSettings:PostgresSettings")
                .Get<PostgresSettings>();

            if (postgresSettings != null && postgresSettings.ConnectionString != null)
            {
                services.AddSingleton(postgresSettings);
            }
            services.AddScoped<IDataRepository, DataRepository>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("https://localhost:44343");
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            applicationLifetime.ApplicationStarted.Register(OnApplicationStarted);

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller}/{action}");
            });
        }

        protected void OnApplicationStarted()
        {
            try
            {
                var migrator = new DbMigrator(postgresSettings);
                var mapping = new InitializeMapping();

                migrator.StartMigration();
                mapping.Initialize();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Возникла ошибка при инициализации миграций или маппинга.\nОшибка: {0}", ex.Message);
            }
        }
    }
}
