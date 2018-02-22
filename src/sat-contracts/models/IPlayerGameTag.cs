using System;
using System.Collections.Generic;
using System.Text;

namespace sat_contracts.models
{
    public interface IPlayerGameTag
    {
        long PlayerID64 { get; set; }
        int AppID { get; set; }
        string Tag { get; set; }
    }
}
