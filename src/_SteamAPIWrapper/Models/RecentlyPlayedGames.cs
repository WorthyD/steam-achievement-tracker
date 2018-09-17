using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamApiWrapper.Models
{
    public class RecentlyPlayedGames
    {

        public Response response { get; set; }

        public class Response
        {
            public int total_count { get; set; }
            public Game[] games { get; set; }
        }

        public class Game
        {
            public int appid { get; set; }
            public string name { get; set; }
            public int playtime_2weeks { get; set; }
            public int playtime_forever { get; set; }
            public string img_icon_url { get; set; }
            public string img_logo_url { get; set; }
        }

    }
}
