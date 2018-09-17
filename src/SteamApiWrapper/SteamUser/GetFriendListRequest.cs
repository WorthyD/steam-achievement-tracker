using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SteamApiWrapper.Helpers;
using System.Threading.Tasks;

namespace SteamApiWrapper.SteamUser
{
    [APIKeyRequired]
    public class GetFriendListRequest : Request
    {

        public enum RelationShipType
        {
            all,
            friend
        }

        [QueryParameter]
        public RelationShipType Relationship { get; set; }

        [QueryParameter]
        public long SteamId { get; set; }


        public override SteamUrlBuilder.Version ApiVersion
        {
            get
            {
                return SteamUrlBuilder.Version.v1;
            }
        }

        public override SteamUrlBuilder.Interface UrlInterface
        {
            get
            {
                return SteamUrlBuilder.Interface.ISteamUser;
            }
        }

        public override string UrlPath
        {
            get
            {
                return "GetFriendList";
            }
        }
        public GetFriendListRequest(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        public async Task<GetFriendListResponse> GetResponse()
        {

            var response = new GetFriendListResponse();
            response = await base.ExecuteRequest(response as Response, this) as GetFriendListResponse;


            return response;


        }
    }
}
