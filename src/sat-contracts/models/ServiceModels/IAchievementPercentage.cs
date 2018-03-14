using System;
using System.Collections.Generic;
using System.Text;

namespace sat_contracts.models.ServiceModels
{
    public interface IAchievementPercentage
    {

        string Name { get; set; }
        float Percent { get; set; }
    }
}
