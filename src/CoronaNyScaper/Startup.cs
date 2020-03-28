using CoronaNyScaper.Context;
using CoronaNyScaper.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
