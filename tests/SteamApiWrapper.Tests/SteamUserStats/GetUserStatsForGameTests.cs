using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xunit;

namespace SteamApiWrapper.Tests.SteamUserStats
{
    public class GetUserStatsForGameTests : BaseTest
    {
        public SteamApiWrapper.SteamUserStats.GetUserStatsForGameRequest req;

        public GetUserStatsForGameTests()
        {
            req = new SteamApiWrapper.SteamUserStats.GetUserStatsForGameRequest(base.APIKey);
            req.SteamId = 76561198025095151;
        }
        [Fact]
        public async Task GetUserStatsTest()
        {
            req.appid = 440;
            var response = await req.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.OK);
        }
    }
}
