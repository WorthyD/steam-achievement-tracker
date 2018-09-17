using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamApiWrapper.SteamUser
{
    public class GetPlayerSummariesResponse : Response
    {

        public Models.PlayerSummaries.Player[] Players { get; set; }

        public override void Convert()
        {
            var app = JsonConvert.DeserializeObject<Models.PlayerSummaries>(base.RawResponse);
            if (app != null && app.response != null && app.response.players != null)
            {
                this.Players = app.response.players;
            }
            else
            {
                this.Status = ResponseStatus.ResponseStatusCode.NotFound;
                this.StatusMessage = "No Players Found";
            }
        }
    }
}
