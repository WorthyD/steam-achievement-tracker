using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamApiWrapper.SteamUserStats
{
    //http://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=440&count=3&maxlength=300&format=json
    public class GetGlobalAchievementPercentagesForAppResponse : Response
    {
        public Models.GlobalAchievementPercentages.Achievementpercentages GlobalAchievementPercentages { get; set; }
        public GetGlobalAchievementPercentagesForAppResponse()
        { }
        public override void Convert()
        {


            var app = JsonConvert.DeserializeObject<Models.GlobalAchievementPercentages>(base.RawResponse);
            if (app != null && app.achievementpercentages != null)
            {
                GlobalAchievementPercentages = app.achievementpercentages;
            }
            else
            {
                this.Status = ResponseStatus.ResponseStatusCode.NotFound;
                this.StatusMessage = "Stats not found";
            }
            
        }

        public GetGlobalAchievementPercentagesForAppResponse(GetGlobalAchievementPercentagesForAppRequest request) :base() { }

    }
}
