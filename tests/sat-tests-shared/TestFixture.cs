using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using sat_dal;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace sat_tests_shared
{
    public class TestFixture
    {
        protected readonly IMapper Mapper;
        protected readonly HttpClient Client;
        protected readonly ModelContext db;


        public TestFixture()
        {
            Mapper = new Mapper(
              new MapperConfiguration(
                  configure => { configure.AddProfile<DalMappingProfile>(); }
              )
          );
            Client = GetTestServer();

            db = GetInitializedDbContext();


        }

        private static HttpClient GetTestServer()
        {
            var server = new TestServer(
                new WebHostBuilder()
                     .UseStartup<sat_netcore.Startup>()
                    .ConfigureAppConfiguration(config =>
                    {
                        //    config.SetBasePath(Path.Combine(Path.GetFullPath(@"../../../.."), "Kodkod.Tests.Shared"));
                        // config.AddJsonFile("appsettings.json", false);
                    })
            );

            return server.CreateClient();
        }
        public static sat_dal.ModelContext GetInitializedDbContext()
        {
            var inMemoryContext = GetEmptyDbContext();

            //Seed Data
            /*
            inMemoryContext.AddRange(PermissionConsts.AllPermissions());
            inMemoryContext.AddRange(RoleConsts.AdminRole, RoleConsts.ApiUserRole);
            inMemoryContext.AddRange(AllTestUsers);
            inMemoryContext.AddRange(AdminUserRole, TestUserRole);
            inMemoryContext.AddRange(AdminRolePermission, ApiUserRolePermission);
            */
            inMemoryContext.Add(MockData.getMockProfile());
            inMemoryContext.AddRange(MockData.getMockLibrary());

            inMemoryContext.SaveChanges();

            return inMemoryContext;
        }
        public static sat_dal.ModelContext GetEmptyDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<sat_dal.ModelContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            //optionsBuilder.UseLazyLoadingProxies();
            //optionsBuilder.EnableSensitiveDataLogging();

            var inMemoryContext = new ModelContext(optionsBuilder.Options);

            return inMemoryContext;
        }
    }
}
