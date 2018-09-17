//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamApiWrapper.Tests.PlayerService
{
    public class GetOwnedGamesTests :BaseTest
    {
        public SteamApiWrapper.PlayerService.GetOwnedGamesRequest req;
        public GetOwnedGamesTests()
        {
            req = new SteamApiWrapper.PlayerService.GetOwnedGamesRequest(base.APIKey);
            req.SteamId = 76561198025095151;
        }

        [Fact]
        public async Task GetOwnedGamesTest()
        {
            var response = await req.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.OK);
        }

        [Fact]
        public async Task GetOwnedGamesTestCount()
        {
            var response = await req.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.OK);
            Assert.True(response.OwnedGames.game_count > 0);
            Assert.True(response.OwnedGames.games.Count() > 0);
        }

        [Fact]
        public async Task GetOwnedGamesNoDetailsTest()
        {
            var response = await req.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.OK);
            Assert.True(response.OwnedGames.game_count > 0);
            Assert.True(response.OwnedGames.games.Count() > 0);
            var firstGame = response.OwnedGames.games.FirstOrDefault();

            Assert.True(firstGame.name == null);
        }

        [Fact]
        public async Task GetOwnedGamesDetailsTest()
        {
            req.include_appinfo = "1";
            var response = await req.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.OK);
            Assert.True(response.OwnedGames.game_count > 0);
            Assert.True(response.OwnedGames.games.Count() > 0);
            var firstGame = response.OwnedGames.games.FirstOrDefault();

            Assert.True(firstGame.name != null);
        }


        [Fact]
        public async Task GetOwnedNoFreeToPlayTest()
        {
            var response = await req.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.OK);
            Assert.True(response.OwnedGames.game_count > 0);
            Assert.True(response.OwnedGames.games.Count() > 0);

            var freeToPlayGame = response.OwnedGames.games.Where(x => x.appid == AppID_TeamFortressTwo).FirstOrDefault();
            Assert.True(freeToPlayGame == null);
        }

        [Fact]
        public async Task GetOwnedFreeToPlayTest()
        {
            req.include_played_free_games = "1";
            var response = await req.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.OK);
            Assert.True(response.OwnedGames.game_count > 0);
            Assert.True(response.OwnedGames.games.Count() > 0);

            var freeToPlayGame = response.OwnedGames.games.Where(x => x.appid == AppID_TeamFortressTwo).FirstOrDefault();
            Assert.True(freeToPlayGame != null);
        }




    }
}
