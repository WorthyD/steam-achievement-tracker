using sat_contracts.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace sat_business.DTOs
{
    public class PlayerGameAchievementDTO : IPlayerGameAchievement
    {
        public long SteamId { get; set; }

        public long AppID { get; set; }

        public string ApiName { get; set; }

        public bool Achieved { get; set; }

        public DateTime? UnlockTimestamp { get; set; }

    }
}
