using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KenyanCounties.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KenyanCounties
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
            services.AddDbContext<LegalContext>(opt =>
               opt.UseInMemoryDatabase("CountyList"));
            services.AddControllers();

            //var storageAccount = "DefaultEndpointsProtocol=https;AccountName=mirrbot;AccountKey=CpfL0zNkEZTqNHJFmqe5D+VvvVEbNokosNnQywLQhprCpnDLLFqRa7V9lLQb+nrM9mhTKi64IH3uHP0r11XcjQ==;EndpointSuffix=core.windows.net";
            //var storageContainer = "statecontainer";

            //services.AddSingleton<IStorage>(new AzureBlobStorage(storageAccount, storageContainer));
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
