using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using sat_business.Providers;
using sat_contracts.repositories;
using sat_dal;
using sat_dal.Repositories;

using NJsonSchema;
using NSwag.AspNetCore;
using System.Reflection;

namespace sat_netcore
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
            services.AddMvc();

            //Dependancy Injection?
            services.AddScoped<GameAchievementProvider>();

            services.AddScoped<DbContext, ModelContext>();

            //services.AddAutoMapper();
            services.AddSatDal();
            //var mapConfig = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile(new sat_dal.DalMappingProfile());
            //});
            //var mapper = mapConfig.CreateMapper();
            //services.AddSingleton(mapper);


            services.AddScoped<sat_dal.Repositories.IGameSchemaRepo, GameSchemaRepo>();

            services.AddDbContext<ModelContext>(optionsAction =>
                   optionsAction.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            

            app.UseStaticFiles();
            
            // Enable the Swagger UI middleware and the Swagger generator
            //app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings =>
            //{
            //    settings.GeneratorSettings.DefaultPropertyNameHandling =
            //        PropertyNameHandling.CamelCase;
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
