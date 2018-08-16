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

        public TestFixture()
        {
            Mapper = new Mapper(
              new MapperConfiguration(
                  configure => { configure.AddProfile<DalMappingProfile>(); }
              )
          );
        }

        private static HttpClient GetTestServer()
        {
            var server = new TestServer(
                new WebHostBuilder()
                     .UseStartup<sat_netcore.Startup>()
                    .ConfigureAppConfiguration(config =>
                    {
                        config.SetBasePath(Path.Combine(Path.GetFullPath(@"../../../.."), "Kodkod.Tests.Shared"));
                        config.AddJsonFile("appsettings.json", false);
                    })
            );

            return server.CreateClient();
        }
    }
}
