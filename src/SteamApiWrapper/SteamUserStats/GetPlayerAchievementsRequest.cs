using SteamApiWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamApiWrapper.SteamUserStats
{
    [APIKeyRequired]
    public class GetPlayerAchievementsRequest : Request
    {
        [Required]
        [QueryParameter]
        public long SteamId { get; set; }

        [Required]
        [QueryParameter]
        public int appid { get; set; }


        [QueryParameter]
        public string l { get; set; }



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
                return SteamUrlBuilder.Interface.ISteamUserStats;
            }
        }

        public override string UrlPath
        {
            get
            {
                return "GetPlayerAchievements";
            }
        }
        public GetPlayerAchievementsRequest(string apiKey)
        {
            this.ApiKey = apiKey;
            this.l = "en";
        }


        public async Task<GetPlayerAchievementsResponse> GetResponse()
        {

            var response = new GetPlayerAchievementsResponse();
            response = await base.ExecuteRequest(response as Response, this) as GetPlayerAchievementsResponse;


            return response;


        }
    }
}
