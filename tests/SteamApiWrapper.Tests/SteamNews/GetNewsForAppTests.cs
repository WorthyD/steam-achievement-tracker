using System;
using System.Threading.Tasks;
using Xunit;

namespace SteamApiWrapper.Tests.SteamNews
{
    public class GetNewsForAppTests
    {
        public SteamApiWrapper.SteamNews.GetNewsForAppRequest req;

        public GetNewsForAppTests()
        {
            req = new SteamApiWrapper.SteamNews.GetNewsForAppRequest();
            req.AppId = 440;
            req.Count = 3;
            req.MaxLength = 3;


        }

        [Fact]
        public async Task GetNewsAppTest()
        {
            var response = await req.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.OK);
            Assert.True(response.AppNews.NewsItems.Count > 0);
        }

        [Fact]
        public async Task GetNewsAppTestCount()
        {
            var response = await req.GetResponse();
            Assert.True(response.AppNews.NewsItems.Count == 3);
        }


        [Fact]
        public async Task GetNewsAppTestMaxLength()
        {
            var response = await req.GetResponse();
            bool indexFixed = false;
            foreach (var n in response.AppNews.NewsItems)
            {
                int i = n.contents.IndexOf('.');
                if (n.contents.IndexOf('.') >= 3 && n.contents.Length < 7)
                {
                    indexFixed = true;
                }
            }

            Assert.True(indexFixed);
        }



        [Fact]
        public async Task GetNewsAppTestFailure()
        {
            req.AppId = 0;
            var response = await req.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.NotFound);
        }
    }
}
