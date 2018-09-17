using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamApiWrapper.Models
{
    public class SchemaForGame
    {

        public Game game { get; set; }

        public class Game
        {
            public string gameName { get; set; }
            public string gameVersion { get; set; }
            public Availablegamestats availableGameStats { get; set; }
        }

        public class Availablegamestats
        {
            public Achievement[] achievements { get; set; }
            public Stat[] stats { get; set; }
        }

        public class Achievement
        {
            public string name { get; set; }
            public long defaultvalue { get; set; }
            public string displayName { get; set; }
            public int hidden { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
            public string icongray { get; set; }
        }

        public class Stat
        {
            public string name { get; set; }
            public long defaultvalue { get; set; }
            public string displayName { get; set; }
        }

    }
}
