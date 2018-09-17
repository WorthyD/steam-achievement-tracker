using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using sat_tests_shared;
using sat_business.Exceptions;

namespace sat_business_tests.Providers
{
    public class PlayerProfileProviderTests : BusinessTestFixture
    {

        private readonly sat_business.Providers.PlayerProfileProvider _provider;
        public PlayerProfileProviderTests()
        {
            var profile = new sat_dal.Repositories.PlayerProfileRepo(this.db);
            this._provider = new sat_business.Providers.PlayerProfileProvider(profile, this.Mapper);

        }
        //76561198025095151
        [Fact]
        public async void RetrieveProfile()
        {

            var x = await this._provider.GetPlayerProfile(sat_tests_shared.MockData.WORTHYD_STEAMID);
            Assert.NotNull(x);
            //long appId = 12345;
            //var dummyGame = Utilities.getDummyGame();
            //var dummyAchievements = Utilities.getDummyAchievementPercentages();

            //var t = await this._repo.Load(appId);


            //var testVar = await this._repo.SaveSchema(appId, dummyGame, dummyAchievements);

            //Assert.Equal(appId, testVar.AppId);
            //Assert.Equal(dummyGame.AvailableGameStats.Achievements.Count(), testVar.GameAchievements.Count());


        }
        [Fact]
        public async void RetrieveInvalidProfile()
        {

            Exception ex = await  Assert.ThrowsAsync<PlayerNotFoundException>(async () =>  await this._provider.GetPlayerProfile(123456));

        }
    }
}
