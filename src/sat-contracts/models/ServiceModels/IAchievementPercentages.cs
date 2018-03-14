using System;
using System.Collections.Generic;
using System.Text;

namespace sat_contracts.models.ServiceModels
{
    public interface IAchievementPercentages
    {
        List<IAchievementPercentage> AchievementPercentages { get; set; }
    }
}
