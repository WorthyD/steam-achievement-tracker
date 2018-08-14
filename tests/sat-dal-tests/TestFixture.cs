using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Net.Http.Headers;
using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading;
using sat_dal.Models;
using sat_dal.DTOs;

namespace sat_dal_tests
{
    public class TestFixture :IDisposable
    {
        public sat_dal.ModelContext db;
        protected readonly TestServer _server;
        //private static Mutex mutex = new Mutex();
        public static bool isInitialized = false;


        public TestFixture() 
        {
           // ServiceCollectionExtensions.UseStaticRegistration = false; // <-- HERE

           // var hostBuilder = new WebHostBuilder()
           //     .UseEnvironment("Testing")
           //     .UseStartup<Startup>();

           //var  Server = new TestServer(hostBuilder);
           // var Client = Server.CreateClient();


            // // disable automapper static registration
            // ServiceCollectionExtensions.UseStaticRegistration = false;


            var builder = new DbContextOptionsBuilder()
              .UseInMemoryDatabase();

            //AutoMapper.Mapper.Reset();
            // sat_dal.Startup.ResetMaps();
            AutoMapper.ServiceCollectionExtensions.UseStaticRegistration = false;
            if (isInitialized == false) {
                sat_dal.Startup.RegisterMaps();
                isInitialized = true;
            }
            //// Microsoft.AspNetCore.WebHost

            this.db = new sat_dal.ModelContext(builder.Options);
        }

        public void Dispose()
        {
           // AutoMapper.Mapper.Reset();
            this.db.Dispose();
            AutoMapper.Mapper.Reset();
            //this._server.Dispose();
        }

    }
}
