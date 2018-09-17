using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamApiWrapper.SteamUserStats
{
    public class GetUserStatsForGameResponse :Response
    {
        public Models.StatsForGame.Playerstats PlayerStats { get; set; }

        public override void Convert()
        {
            var app = JsonConvert.DeserializeObject<Models.StatsForGame>(base.RawResponse);
            if (app != null && app.playerstats != null)
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
