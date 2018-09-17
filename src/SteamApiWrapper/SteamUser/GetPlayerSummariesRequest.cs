using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SteamApiWrapper.Helpers;
using System.Threading.Tasks;

namespace SteamApiWrapper.SteamUser
{
    [APIKeyRequired]
    public class GetPlayerSummariesRequest : Request
    {

        public List<long> ProfileIds
        {
            get; set;
        }

        [QueryParameter]
        public string SteamIds
        {
            get
            {
                return String.Join(",", this.ProfileIds);
            }
        }


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
                return SteamUrlBuilder.Interface.ISteamUser;
            }
        }

        public override string UrlPath
        {
            get
            {
                return "GetPlayerSummaries";
            }
        }

        public GetPlayerSummariesRequest(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        public async Task<GetPlayerSummariesResponse> GetResponse()
        {

            var response = new GetPlayerSummariesResponse();
            response = await base.ExecuteRequest(response as Response, this) as GetPlayerSummariesResponse;


            return response;


        }
    }
}
