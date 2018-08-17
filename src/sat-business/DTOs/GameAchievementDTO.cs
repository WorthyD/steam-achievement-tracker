using sat_contracts.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace sat_business.DTOs
{
    public class GameAchievementDTO : IGameAchievement
    {
        public long AppId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public string DisplayName { get; set; }

        public bool Hidden { get; set; }

        public string Icon { get; set; }

        public string IconGray { get; set; }

        public double Percent { get; set; }



    }
}
