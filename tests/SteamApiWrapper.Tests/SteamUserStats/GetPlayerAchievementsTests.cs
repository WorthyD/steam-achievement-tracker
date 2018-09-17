using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xunit;

namespace SteamApiWrapper.Tests.SteamUserStats
{
    public class GetPlayerAchievementsTests : BaseTest
    {
        public SteamApiWrapper.SteamUserStats.GetPlayerAchievementsRequest req;

        public GetPlayerAchievementsTests()
        {
            req = new SteamApiWrapper.SteamUserStats.GetPlayerAchievementsRequest(base.APIKey);
            req.SteamId = 76561198025095151;
        }

        [Fact]
        public async Task GetAchievementTest()
        {
            //req.appid = 284850;
            req.appid = 240;
            var response = await req.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.OK);
        }

        [Fact]
        public async Task GetAchievementFailNoAppIdTest()
        {

            //var response = await req.GetResponse();
        }
    }
}
