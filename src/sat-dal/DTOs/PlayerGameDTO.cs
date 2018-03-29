using sat_contracts.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace sat_dal.DTOs
{
    public class PlayerGameDTO : IPlayerGame
    {
        public long SteamId { get; set; }
        public long AppID { get; set; }
        public decimal PlaytimeForever { get; set; }
        public decimal Playtime2weeks { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime AchievementRefresh { get; set; }
        public bool RefreshAchievements { get; set; }
        public int AchievementsEarned { get; set; }
        public int AchievementsLocked { get; set; }
        public int TotalAchievements { get; set; }
        //public virtual PlayerProfile PlayerProfile { get; set; }

        //public virtual List<PlayerGameAchievement> PlayerGameAchievements { get; set; }

        //public virtual GameSchema GameSchema { get; set; }
    }
}
