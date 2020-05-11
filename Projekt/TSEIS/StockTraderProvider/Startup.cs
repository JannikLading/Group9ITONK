using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StockTraderBroker.Database;
using StockTraderBroker.Repositories;
using StockTraderBroker.Services;

namespace StockTraderProvider
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
            services.AddDbContext<AppDbContext>(options =>
            {
                //options.UseMySql($"Server={host};Uid=user;Pwd={paasword};Port={port};Database=haandvaerkers");
                options.UseSqlServer("Server=192.168.176.129;Database=Stocks;User ID=SA;Password=Group9database;MultipleActiveResultSets=true", providerOptions => providerOptions.EnableRetryOnFailure());
                //options.UseInMemoryDatabase("StockTrades");
            });
            services.AddControllers();
            services.AddScoped<IStockTraderBrokerService, StockTraderBrokerService>();
            services.AddScoped<IStockTraderBrokerRepository, StockTraderBrokerRepository>(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            context.Database.Migrate();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
