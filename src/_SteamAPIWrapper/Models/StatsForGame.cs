﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamApiWrapper.Models
{
    public class StatsForGame
    {

        public Playerstats playerstats { get; set; }

        public class Playerstats
        {
            public string steamID { get; set; }
            public string gameName { get; set; }
            public Stat[] stats { get; set; }
            public Achievement[] achievements { get; set; }
        }

        public class Stat
        {
            public string name { get; set; }
            public int value { get; set; }
        }

        public class Achievement
        {
            public string name { get; set; }
            public int achieved { get; set; }
        }

    }
}
