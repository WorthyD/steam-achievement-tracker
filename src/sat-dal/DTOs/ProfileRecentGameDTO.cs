using sat_contracts.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace sat_dal.DTOs
{
    public class ProfileRecentGameDTO : IProfileRecentGame
    {
        public long SteamId { get; set; }

        public long AppId { get; set; }
    }
}
