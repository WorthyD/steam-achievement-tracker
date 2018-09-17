using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamApiWrapper.SteamUserStats
{
    public class GetPlayerAchievementsResponse: Response
    {
        public Models.PlayerAchievements.Playerstats PlayerStats { get; set; }

        public override void Convert()
        {
            var app = JsonConvert.DeserializeObject<Models.PlayerAchievements>(base.RawResponse);
            if (app != null && app.playerstats != null && app.playerstats.success  == true)
            {
                this.PlayerStats = app.playerstats;
            }
            else
            {
                this.Status = ResponseStatus.ResponseStatusCode.NotFound;
                this.StatusMessage = "No Stats Found";
            }
        }

    }
}
