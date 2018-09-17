using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SteamApiWrapper.Helpers;

namespace SteamApiWrapper.SteamUserStats
{
    public class GetGlobalAchievementPercentagesForAppRequest : Request
    {
        [QueryParameter]
        public int GameId { get; set; }

        public override SteamUrlBuilder.Interface UrlInterface
        {
            get { return SteamUrlBuilder.Interface.ISteamUserStats; }
        }

        public override SteamUrlBuilder.Version ApiVersion
        {
            get { return SteamUrlBuilder.Version.v2; }
        }

        public override string UrlPath
        {
            get { return "GetGlobalAchievementPercentagesForApp"; }
        }

        public async Task<GetGlobalAchievementPercentagesForAppResponse> GetResponse()
        {

            var response = new GetGlobalAchievementPercentagesForAppResponse();
            response = await base.ExecuteRequest(response as Response, this) as GetGlobalAchievementPercentagesForAppResponse;


            return response;


        }
      


    }
}
