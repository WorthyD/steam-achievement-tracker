using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamApiWrapper.PlayerService
{
    public class GetRecentlyPlayedGamesResponse : Response
    {
        public Models.RecentlyPlayedGames.Response RecentlyPlayedGames { get; set; }

        public override void Convert()
        {
            var app = JsonConvert.DeserializeObject<Models.RecentlyPlayedGames>(base.RawResponse);
            if (app != null && app.response != null)
            {
                this.RecentlyPlayedGames = app.response;
            }
            else
            {
                this.Status = ResponseStatus.ResponseStatusCode.NotFound;
                this.StatusMessage = "Games Not Found";
            }
        }
    }
}
