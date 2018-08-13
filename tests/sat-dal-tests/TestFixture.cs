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

namespace sat_dal_tests
{
    public class TestFixture 
    {
        public sat_dal.ModelContext db;
        protected readonly TestServer _server;


        public TestFixture()
        {
           // // disable automapper static registration
           // ServiceCollectionExtensions.UseStaticRegistration = false;


           // var builder = new DbContextOptionsBuilder()
           //   .UseInMemoryDatabase();

           // //AutoMapper.Mapper.Reset();
           // //sat_dal.Startup.RegisterMaps();
           //// Microsoft.AspNetCore.WebHost

           // this.db = new sat_dal.ModelContext(builder.Options);
           // //_server = new TestServer(WebHost.CreateDefaultBuilder().UseStartup<TestStartup>())
           // //var host = new HostBuilder()
           // _server = new TestServer(new HostBuilder());

        }

        public void Dispose()
        {
            this.db.Dispose();
            this._server.Dispose();
        }

    }
}
