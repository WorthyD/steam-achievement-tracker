using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using sat_dal;

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
    }
}
