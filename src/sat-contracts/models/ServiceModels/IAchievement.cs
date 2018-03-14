using System;
using System.Collections.Generic;
using System.Text;

namespace sat_contracts.models.ServiceModels
{
    public interface IAchievement
    {
        string Name { get; set; }
        long DefaultValue { get; set; }
        string DisplayName { get; set; }
        int Hidden { get; set; }
        string Description { get; set; }
        string Icon { get; set; }
        string Icongray { get; set; }
    }
}
