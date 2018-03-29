using sat_contracts.models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace sat_dal_tests.Models
{
    public class DummyAchievementPercentage : IAchievementPercentage
    {
        public string Name { get; set; }
        public float Percent { get; set; }
    }
}
