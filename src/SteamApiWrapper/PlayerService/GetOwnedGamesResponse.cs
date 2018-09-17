using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamApiWrapper.PlayerService
{
    public class GetOwnedGamesResponse: Response
    {
        public Models.OwnedGames.Response OwnedGames { get; set; }

        public override void Convert()
        {
            var app = JsonConvert.DeserializeObject<Models.OwnedGames>(base.RawResponse);
            if (app != null && app.response != null)
            {
                this.OwnedGames = app.response;
            }
            else
            {
                this.Status = ResponseStatus.ResponseStatusCode.NotFound;
                this.StatusMessage = "Games Not Found";
            }
        }
    }
}
