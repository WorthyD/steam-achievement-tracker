using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.DependencyInjection;


namespace sat_dal_business_integration_tests
{
    public class BaseTest
    {
        sat_dal.ModelContext db;
        sat_dal.Repositories.GameSchemaRepo _repo;

        public BaseTest()
        {
            var builder = new DbContextOptionsBuilder()
              .UseInMemoryDatabase();

            sat_dal.Startup.RegisterMaps();

            this.db = new sat_dal.ModelContext(builder.Options);
            this._repo = new sat_dal.Repositories.GameSchemaRepo(this.db);
        }


    }
}
