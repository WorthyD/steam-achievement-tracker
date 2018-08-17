using sat_contracts.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace sat_business.DTOs
{
    public class PlayerProfileDTO : IPlayerProfile
    {

        public long SteamId { get; set; }

        public string PersonaName { get; set; }

        public string RealName { get; set; }

        public string AvatarFull { get; set; }

        public string ProfileUrl { get; set; }

        public DateTime LastUpdate { get; set; }

        public DateTime LibraryLastUpdate { get; set; }


        public virtual IList<IPlayerGame> PlayerGames { get; set; }
        public virtual IList<IProfileRecentGame> PlayerRecentGames { get; set; }
        public virtual IList<IPlayerGameAchievement> PlayerGameAchievements { get; set; }

    }
}
