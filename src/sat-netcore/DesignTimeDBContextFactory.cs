using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sat_dal;
using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace sat_netcore
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ModelContext>
    {
        public ModelContext CreateDbContext(string[] args)
        {
            //Mapper.Reset();

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var builder = new DbContextOptionsBuilder<ModelContext>();

            builder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"], b => b.MigrationsAssembly("sat_dal"));
            //builder.UseOpenIddict();

            return new ModelContext(builder.Options);
        }
    }
}
