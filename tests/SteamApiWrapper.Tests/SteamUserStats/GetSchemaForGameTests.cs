using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xunit;

namespace SteamApiWrapper.Tests.SteamUserStats
{
    public class GetSchemaForGameTests : BaseTest
    {
        public SteamApiWrapper.SteamUserStats.GetSchemaForGameRequest req;

        public GetSchemaForGameTests()
        {
            req = new SteamApiWrapper.SteamUserStats.GetSchemaForGameRequest(base.APIKey);
        }
        [Fact]
        public async Task GetSchemaForGameTest()
        {
            //req.appid = 440;
            req.appid = 240;
            var response = await req.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.OK);
        }
    }
}
