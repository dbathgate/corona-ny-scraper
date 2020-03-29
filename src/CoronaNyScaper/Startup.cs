using CoronaNyScaper.Context;
using CoronaNyScaper.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Steeltoe.CloudFoundry.Connector.EFCore;
using Steeltoe.CloudFoundry.Connector.PostgreSql.EFCore;
using Steeltoe.Management.TaskCore;

namespace CoronaNyScaper
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<INyDataRepository, NyDataRepository>();
            
            services.AddDbContext<MetricDatabaseContext>(o => o.UseNpgsql(Configuration));
            
            services.AddTask<MigrateDbContextTask<MetricDatabaseContext>>(ServiceLifetime.Scoped);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "COVID-19 NY API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Quadrants API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
