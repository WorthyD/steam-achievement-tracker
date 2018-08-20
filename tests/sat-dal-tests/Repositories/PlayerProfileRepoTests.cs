using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace sat_dal_tests.Repositories
{
    public class PlayerProfileRepoTests : DalTestFixture
    {
        ///sat_dal.ModelContext db;
        sat_dal.Repositories.PlayerProfileRepo _repo;

        public PlayerProfileRepoTests()
        {
            //   var builder = new DbContextOptionsBuilder()
            //.UseInMemoryDatabase();


            //AutoMapper.Mapper.Reset();
            //sat_dal.Startup.RegisterMaps();

            //this.db = new sat_dal.ModelContext(builder.Options);
            this._repo = new sat_dal.Repositories.PlayerProfileRepo(this.db);


        }

        [Fact]
        public async void SaveProfile()
        {
            Models.DummyProfile dp = Utilities.getDummyProfile();

            var p = await this._repo.SaveProfile(dp.SteamId, dp);
            Assert.Null(p);
        }

        [Fact]
        public async void RetrieveProfile()
        {
            var mockProfile = sat_tests_shared.MockData.getMockProfile();
            var p = await this._repo.LoadProfile(mockProfile.SteamId);
            Assert.Equal(mockProfile.RealName, p.RealName);
        }

        [Fact]
        public async void HandlesNoProfile()
        {

        }

        [Fact]
        public async void HandlesUpdate()
        {

        }





    }
}
