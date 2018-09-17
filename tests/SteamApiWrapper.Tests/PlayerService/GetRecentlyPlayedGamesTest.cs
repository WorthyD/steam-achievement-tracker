using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SteamApiWrapper.Tests.PlayerService
{
    public class GetRecentlyPlayedGamesTests : BaseTest
    {
        public SteamApiWrapper.PlayerService.GetRecentlyPlayedGamesRequest req;
        public GetRecentlyPlayedGamesTests()
        {
            req = new SteamApiWrapper.PlayerService.GetRecentlyPlayedGamesRequest(base.APIKey);
            req.SteamId = 76561198025095151;
        }

        [Fact]
        public async Task GetRecentlyPlayedGamesTest()
        {
            var response = await req.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.OK);
        }

        [Fact]
        public async Task GetRecentlyPlayedGamesTestCount()
        {
            var response = await req.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.OK);
            Assert.True(response.RecentlyPlayedGames.total_count > 0);
            Assert.True(response.RecentlyPlayedGames.games.Count() > 0);
        }

       




    }
}
