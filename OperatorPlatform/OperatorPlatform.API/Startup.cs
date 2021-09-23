using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using OperatorPlatform.Business;
using OperatorPlatform.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperatorPlatform.API
{
    public class Startup
    {
        private const string ConnectionStringName = "DefaultConnection";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OperatorPlatform.API", Version = "v1" });
            });
            services.AddDbContext<OperatorPlatformDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString(ConnectionStringName)));
            ConfigureBusiness(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OperatorPlatform.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureBusiness(IServiceCollection services)
        {
            services.AddScoped<AlertBusiness, AlertBusiness>();
            services.AddScoped<BarBusiness, BarBusiness>();
            services.AddScoped<ExchangeBusiness, ExchangeBusiness>();
            services.AddScoped<IndicatorBusiness, IndicatorBusiness>();
            services.AddScoped<OperationBusiness, OperationBusiness>();
            services.AddScoped<TickerBusiness, TickerBusiness>();
        }
    }
}
