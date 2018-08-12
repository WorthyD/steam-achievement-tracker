using System;
using System.Collections.Generic;
using System.Text;
using sat_contracts.models;

namespace sat_dal_tests.Models
{
    public class DummyProfile : IPlayerProfile
    {
        public long SteamId { get; set; }

        public string PersonaName { get; set; }

        public string RealName { get; set; }

        public string AvatarFull { get; set; }
        public string ProfileUrl { get; set; }

        public DateTime LastUpdate { get; set; }

        public DateTime LibraryLastUpdate { get; set; }

        public IList<IPlayerGame> PlayerGames { get; set; }
        public IList<IProfileRecentGame> PlayerRecentGames { get; set; }
        public IList<IPlayerGameAchievement> PlayerGameAchievements { get; set; }

    }
}
