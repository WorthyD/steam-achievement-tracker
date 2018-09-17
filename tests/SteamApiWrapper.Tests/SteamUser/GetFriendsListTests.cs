using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xunit;

namespace SteamApiWrapper.Tests.SteamNews
{
    public class GetFriendsListTests : BaseTest
    {
        public SteamApiWrapper.SteamUser.GetFriendListRequest req;

        public GetFriendsListTests()
        {
            req = new SteamApiWrapper.SteamUser.GetFriendListRequest(base.APIKey);
            req.SteamId = 76561198025095151
            ;

        }

        [Fact]
        public async Task GetFriendsTest()
        {
            var response = await req.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.OK);
        }

        [Fact]
        public async Task GetProfilesTest()
        {
            //req.ProfileIds.Add(76561198023113346);
            var response = await req.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.OK);
        }

        [Fact]
        public async Task GetFriendsNoResult()
        {
            req.SteamId = 0;
            var response = await req.GetResponse();
            Assert.True(response.Status == ResponseStatus.ResponseStatusCode.OK);
        }



    }
}
