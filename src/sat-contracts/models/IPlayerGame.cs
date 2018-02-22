using System;
using System.Collections.Generic;
using System.Text;

namespace sat_contracts.models
{
    public interface IPlayerGame
    {
        long SteamId { get; set; }
        long AppID { get; set; }
        // string Name { get; set; }
        decimal Playtime_Forever { get; set; }
        decimal Playtime_2weeks { get; set; }

        DateTime LastUpdated { get; set; }
        DateTime AchievementRefresh { get; set; }
        bool RefreshAchievements { get; set; }
        int AchievementsEarned { get; set; }
        int AchievementsLocked { get; set; }
        int TotalAchievements { get; set; }

    }
}
