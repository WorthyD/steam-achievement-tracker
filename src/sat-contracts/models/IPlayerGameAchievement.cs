using System;
using System.Collections.Generic;
using System.Text;

namespace sat_contracts.models
{
    public interface IPlayerGameAchievement
    {
        long SteamId { get; set; }
        long AppID { get; set; }
        string ApiName { get; set; }
        bool Achieved { get; set; }
        DateTime? UnlockTimestamp { get; set; }
    }
}
