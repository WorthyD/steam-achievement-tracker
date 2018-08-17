using Microsoft.EntityFrameworkCore;
using sat_tests_shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace sat_dal_tests
{

    public class DalTestFixture : TestFixture
    {

        //public sat_dal.ModelContext db;
        public DalTestFixture()
        {
            //var builder = new DbContextOptionsBuilder()
            //   .UseInMemoryDatabase();

            //this.db = new sat_dal.ModelContext(builder.Options);
        }
    }
}
