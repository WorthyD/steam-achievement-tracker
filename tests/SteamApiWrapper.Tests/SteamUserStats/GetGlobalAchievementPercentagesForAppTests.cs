using System;
using System.Threading.Tasks;
using Xunit;

namespace SteamApiWrapper.Tests.SteamUserStats
{
    public class GetGlobalAchievementPercentagesForAppTests 
    {

        public  SteamApiWrapper.SteamUserStats.GetGlobalAchievementPercentagesForAppRequest r;
        public GetGlobalAchievementPercentagesForAppTests()
        {
            r = new SteamApiWrapper.SteamUserStats.GetGlobalAchievementPercentagesForAppRequest();
        }


        [Fact]
        public async Task GetAchievementPercentages()
        {

            r.GameId = 440;
            var response = await r.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.OK);
            Assert.True(response.GlobalAchievementPercentages.achievements.Count > 0);
        }

        [Fact]
        public async Task GetAchievementPercentagesNoStats()
        {
            r.GameId = 0;
            var response = await r.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.Forbidden);
        }

    }
}
