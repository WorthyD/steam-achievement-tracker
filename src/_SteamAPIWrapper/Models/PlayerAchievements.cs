using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamApiWrapper.Models
{
    public class PlayerAchievements
    {

        public Playerstats playerstats { get; set; }

        public class Playerstats
        {
            public string steamID { get; set; }
            public string gameName { get; set; }
            public Achievement[] achievements { get; set; }
            public bool success { get; set; }
        }

        public class Achievement
        {
            public string apiname { get; set; }
            public int achieved { get; set; }
            public string name { get; set; }
            public string description { get; set; }
        }

    }
}
