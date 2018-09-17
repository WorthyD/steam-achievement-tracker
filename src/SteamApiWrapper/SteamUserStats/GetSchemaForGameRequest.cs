using SteamApiWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamApiWrapper.SteamUserStats
{
    [APIKeyRequired]
    public class GetSchemaForGameRequest : Request
    {
        [QueryParameter]
        public int appid { get; set; }

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
                return "GetSchemaForGame";
            }
        }
        public GetSchemaForGameRequest(string apiKey)
        {
            this.ApiKey = apiKey;
        }
        public async Task<GetSchemaForGameResponse> GetResponse()
        {

            var response = new GetSchemaForGameResponse();
            response = await base.ExecuteRequest(response as Response, this) as GetSchemaForGameResponse;

            return response;


        }

    }
}
