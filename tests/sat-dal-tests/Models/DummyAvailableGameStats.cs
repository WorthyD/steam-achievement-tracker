using sat_contracts.models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace sat_dal_tests.Models
{
    public class DummyAvailableGameStats : IAvailableGameStats
    {
        public IAchievement[] Achievements { get; set; }
        public IStat[] Stats { get; set; }
    }
}
