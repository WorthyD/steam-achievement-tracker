using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamApiWrapper.SteamUserStats
{
    public class GetSchemaForGameResponse : Response
    {
        public Models.SchemaForGame.Game GameSchema { get; set; }

        public override void Convert()
        {
            var app = JsonConvert.DeserializeObject<Models.SchemaForGame>(base.RawResponse);
            if (app != null && app.game != null)
            {
                this.GameSchema = app.game;
            }
            else
            {
                this.Status = ResponseStatus.ResponseStatusCode.NotFound;
                this.StatusMessage = "Game Not Found";
            }
        }
    }
}
