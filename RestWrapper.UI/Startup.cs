using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestWrapper.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RestWrapper.Business.DependencyResolvers;
using RestWrapper.Core.CrossCuttingConcerns.Logging.DatabaseLoggers;
using RestWrapper.Core.DependencyResolvers;
using RestWrapper.Core.Extensions;
using RestWrapper.Core.Utilities.IoC;

namespace RestWrapper.UI
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

            var connectionString = Configuration.GetConnectionString("ConnectionStringOracle");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseOracle(connectionString);
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My Awesome API",
                    Version = "v1"
                });
            });

            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule(),
                new BusinessModule(), 
            });
        }

        //private void AddDependencies(IServiceCollection services)
        //{
        //    services.AddScoped<ICalculator, Calculator>();
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Awesome API V1");
                });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
