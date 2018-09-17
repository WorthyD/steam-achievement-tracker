﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamApiWrapper.Models
{
    public class GlobalAchievementPercentages
    {

        public Achievementpercentages achievementpercentages { get; set; }

        public class Achievementpercentages
        {
            public List<Achievement> achievements { get; set; }
        }

        public class Achievement
        {
            public string name { get; set; }
            public float percent { get; set; }
        }

    }
}
