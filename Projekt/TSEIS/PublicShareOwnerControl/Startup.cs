using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PublicShareOwnerControl.Database;
using PublicShareOwnerControl.Repositories;
using PublicShareOwnerControl.Services;

namespace PublicShareOwnerControl
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
                options.UseSqlServer("Server=mysql-service-g9;Database=haandvaerkers;User ID=SA;Password=Group9database;MultipleActiveResultSets=true");
                //options.UseInMemoryDatabase("haandvaerkers");
            }
            );

            services.AddControllers();
            services.AddScoped<IPublicShareOwnerService, PublicShareOwnerService>();
            services.AddScoped<IPublicShareOwnerRepository, PublicShareOwnerRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            });
        }
    }
}
