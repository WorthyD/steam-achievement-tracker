using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace sat_dal_tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // sat_dal.ModelContext db = new sat_dal.ModelContext( { })
            //sat_dal.Repositories.GameSchemaRepo repo = new sat_dal.Repositories.GameSchemaRepo();
            var builder = new DbContextOptionsBuilder()
              .UseInMemoryDatabase();

            sat_dal.ModelContext db = new sat_dal.ModelContext(builder.Options);

        }
    }
}
