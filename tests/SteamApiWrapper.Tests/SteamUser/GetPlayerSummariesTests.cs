using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xunit;

namespace SteamApiWrapper.Tests.SteamNews
{
    public class GetPlayerSummariesTests : BaseTest
    {
        public SteamApiWrapper.SteamUser.GetPlayerSummariesRequest req;

        public GetPlayerSummariesTests()
        {
            req = new SteamApiWrapper.SteamUser.GetPlayerSummariesRequest(base.APIKey);
            req.ProfileIds = new List<long>()
            {
                76561198025095151
            };

        }

        [Fact]
        public async Task GetProfileTest()
        {
            var response = await req.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.OK);
        }

        [Fact]
        public async Task GetProfilesTest()
        {
            req.ProfileIds.Add(76561198023113346);
            var response = await req.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.OK);
            Assert.True(response.Players.Length == 2);
        }

        [Fact]
        public async Task GetProfileNoResult()
        {
            req.ProfileIds = new List<long>();
            var response = await req.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.OK);
        }



    }
}
