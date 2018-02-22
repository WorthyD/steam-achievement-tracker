using System;
using System.Collections.Generic;
using System.Text;

namespace sat_contracts.models
{
    public interface IProfileRecentGame
    {
        long SteamId { get; set; }
        long AppId { get; set; }
    }
}
