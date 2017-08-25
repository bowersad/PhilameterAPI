using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PhilameterAPI.Models;
using PhilameterAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;






namespace PhilameterAPI
{
    public class Startup
    {

        public IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json", false, true)
                .AddJsonFile($"appSettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            Configuration = configBuilder.Build();

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<StatisticContext>(opt => opt.UseInMemoryDatabase());
            services.AddAutoMapper();

            services.AddMvc();

            //Don't forget to wireup the DI items with the AddScoped
            services.AddScoped<IStatisticService, DefaultStatisticService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                //Turn on details errors
                app.UseDeveloperExceptionPage();

                //Add some test data in memory
                var context = app.ApplicationServices.GetRequiredService<StatisticContext>();
                AddTestData(context);
            }

            app.UseMvc();
        }

        private static void AddTestData(StatisticContext context)
        {
            context.Statistics.Add(new StatisticEntity
            {
                Id = 1,
                Name = "Births",
                Value = 23086,
                Category = 1,
                StatPeriod = 3
            });

            context.Statistics.Add(new StatisticEntity
            {
                Id = 2,
                Name = "Pretzels Eaten",
                Value = 63821,
                Category = 2,
                StatPeriod = 0
            });

            context.Statistics.Add(new StatisticEntity
            {
                Id = 3,
                Name = "SEPTA Ridership",
                Value = 333600,
                Category = 3,
                StatPeriod = 0
            });

            context.SaveChanges();
        }
    }
}
