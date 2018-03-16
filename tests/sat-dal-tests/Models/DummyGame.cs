using System;
using System.Collections.Generic;
using System.Text;
using sat_contracts.models.ServiceModels;

namespace sat_dal_tests.Models
{
    public class DummyGame : sat_contracts.models.ServiceModels.IGame
    {
        public string GameName { get; set; }
        public string GameVersion { get; set; }
        public IAvailableGameStats AvailableGameStats { get; set; }
    }
}
