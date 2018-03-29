using sat_contracts.models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace sat_dal_tests.Models
{
    public class DummyAchievementPercentages : IAchievementPercentages
    {
        public List<IAchievementPercentage> AchievementPercentages { get; set; }
    }
}
