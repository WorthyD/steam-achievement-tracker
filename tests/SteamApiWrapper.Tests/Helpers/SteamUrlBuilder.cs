using System.Threading.Tasks;
using SteamApiWrapper.Helpers;
using Xunit;

namespace SteamApiWrapper.Tests.Helpers
{

    public class SteamUrlBuilderTests
    {
        [Fact]
        public void ValidUrlBuilt()
        {
            var urlBuilder = new SteamApiWrapper.Helpers.SteamUrlBuilder();
            string expected1 = "http://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/";
            string url1 = urlBuilder.BuildRequestUrl(SteamUrlBuilder.Interface.ISteamNews, SteamUrlBuilder.Version.v2, "GetNewsForApp");
            Assert.Equal(url1, expected1);

            string expected2 = "http://api.steampowered.com/ISteamUserStats/GetGlobalStatsForGame/v0001/";
            string url2 = urlBuilder.BuildRequestUrl(SteamUrlBuilder.Interface.ISteamUserStats, SteamUrlBuilder.Version.v1, "GetGlobalStatsForGame");
            Assert.Equal(expected2, url2);
        }
    }

}
