using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_contracts.models
{
    public interface ILogin
    {
        long SteamId { get; set; }
        bool Success { get; set; }
        string Message { get; set; }
    }

}
