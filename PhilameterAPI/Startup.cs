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
using Microsoft.AspNetCore.Identity;

namespace PhilameterAPI
{
    public class Startup
    {

        public IConfigurationRoot Configuration;
        public string ConnectionString;

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
            StatisticContext.ConnectionString = Configuration.GetConnectionString("PhilameterDB");


            //services.AddDbContext<StatisticContext>(opt => opt.UseInMemoryDatabase());
            services.AddDbContext<StatisticContext>();

            services.AddIdentity<UserEntity, UserRoleEntity>()
                .AddEntityFrameworkStores<StatisticContext, Guid>()
                .AddDefaultTokenProviders();

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
                //var context = app.ApplicationServices.GetRequiredService<StatisticContext>();
                //AddTestData(context);

                var roleManager = app.ApplicationServices.GetRequiredService<RoleManager<UserRoleEntity>>();
                var userManager = app.ApplicationServices.GetRequiredService<UserManager<UserEntity>>();

                AddTestUsers(roleManager, userManager).Wait();
            }

            //Turn on details errors
            app.UseDeveloperExceptionPage();

            //Add some test data in memory
            //var context = app.ApplicationServices.GetRequiredService<StatisticContext>();
            //AddTestData(context);

            app.UseMvc();
        }

        private static async Task AddTestUsers(
            RoleManager<UserRoleEntity> roleManager,
            UserManager<UserEntity> userManager)
        {
            await roleManager.CreateAsync(new UserRoleEntity("Admin"));

            var user = new UserEntity
            {
                Email = "admin@philameter.com",
                UserName = "admin",
                FirstName = "Ad",
                LastName = "Min",
                Created = DateTime.UtcNow
            };

            await userManager.CreateAsync(user, "@GEO1234");
            await userManager.AddToRoleAsync(user, "Admin");
            await userManager.UpdateAsync(user);

        }

        private static void AddTestData(StatisticContext context)
        {
            context.Stats.Add(new StatEntity
            {
                Id = 1,
                Name = "Births",
                Stat = 23086,
                Category_Id = 1
            });

            context.Stats.Add(new StatEntity
            {
                Id = 2,
                Name = "Pretzels Eaten",
                Stat = 63821,
                Category_Id = 2
            });

            context.Stats.Add(new StatEntity
            {
                Id = 3,
                Name = "SEPTA Ridership",
                Stat = 333600,
                Category_Id = 3
            });

            context.SaveChanges();
        }
    }
}
