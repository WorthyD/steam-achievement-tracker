using System;
using System.Collections.Generic;
using System.Text;

namespace sat_contracts.models
{
    public interface IPlayerProfile
    {
        long SteamId { get; set; }

        string PersonaName { get; set; }

        string RealName { get; set; }

        string AvatarFull { get; set; }
        string ProfileUrl { get; set; }

        DateTime LastUpdate { get; set; }

        DateTime LibraryLastUpdate { get; set; }



        //virtual IList<IPlayerGame> PlayerGames { get; set; }
        //virtual IList<IProfileRecentGame> PlayerRecentGames { get; set; }
        //virtual IList<IPlayerGameAchievement> PlayerGameAchievements { get; set; }
    }
}
