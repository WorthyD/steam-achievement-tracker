using System;
using System.Collections.Generic;
using System.Text;

namespace sat_contracts.models.ServiceModels
{
    public interface IAvailableGameStats
    {
        IAchievement[] Achievements { get; set; }
        IStat[] Stats { get; set; }


    }
}
