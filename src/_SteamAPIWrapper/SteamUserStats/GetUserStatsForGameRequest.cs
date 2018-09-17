using SteamApiWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamApiWrapper.SteamUserStats
{

    [APIKeyRequired]
    public class GetUserStatsForGameRequest : Request
    {
        [QueryParameter]
        public long SteamId { get; set; }

        [QueryParameter]
        public int appid { get; set; }


        [QueryParameter]
        public string l { get; set; }



        public override SteamUrlBuilder.Version ApiVersion
        {
            get
            {
                return SteamUrlBuilder.Version.v2;
            }
        }

        public override SteamUrlBuilder.Interface UrlInterface
        {
            get
            {
                return SteamUrlBuilder.Interface.ISteamUserStats;
            }
        }

        public override string UrlPath
        {
            get
            {
                return "GetUserStatsForGame";
            }
        }
        public GetUserStatsForGameRequest(string apiKey)
        {
            this.ApiKey = apiKey;
            this.l = "en";
        }


        public async Task<GetUserStatsForGameResponse> GetResponse()
        {

            var response = new GetUserStatsForGameResponse();
            response = await base.ExecuteRequest(response as Response, this) as GetUserStatsForGameResponse;

            return response;


        }
    }
}
