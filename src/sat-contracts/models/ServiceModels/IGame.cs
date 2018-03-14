using System;
using System.Collections.Generic;
using System.Text;

namespace sat_contracts.models.ServiceModels
{
    public interface IGame
    {
        string GameName { get; set; }
        string GameVersion { get; set; }
        IAvailableGameStats AvailableGameStats { get; set; }
    }
}
