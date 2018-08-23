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
        sat_dal.Repositories.PlayerProfileRepo _repo;

        public PlayerProfileRepoTests()
        {
            this._repo = new sat_dal.Repositories.PlayerProfileRepo(this.db);
        }

        [Fact]
        public async void AddProfile()
        {
            Models.DummyProfile dp = new Models.DummyProfile
            {
                AvatarFull = "lorem",
                LastUpdate = DateTime.Now,
                LibraryLastUpdate = DateTime.Now,
                PersonaName = "Testing",
                ProfileUrl = "Testing 1",
                RealName = "testing 2",
                SteamId = 1
            };

            var p = await this._repo.Save(dp.SteamId, dp);
            Assert.NotNull(p);
        }

        [Fact]
        public async void RetrieveProfile()
        {
            var mockProfile = sat_tests_shared.MockData.getMockProfile();
            var p = await this._repo.Load(mockProfile.SteamId);
            Assert.Equal(mockProfile.RealName, p.RealName);
        }

        [Fact]
        public async void HandlesNoProfile()
        {
            var p = await this._repo.Load((long)111111);
            Assert.Null(p);
        }

        [Fact]
        public async void HandlesUpdate()
        {
            string newName = DateTime.Now.Ticks.ToString();
            var mockProfile = sat_tests_shared.MockData.getMockProfile();
            var p = await this._repo.Load(mockProfile.SteamId);
            p.RealName = newName;

            var saved = this._repo.Save(p);
            Assert.True(saved);

        }





    }
}
