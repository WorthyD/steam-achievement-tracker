using System;
using System.Collections.Generic;
using System.Text;

namespace sat_contracts.models.ServiceModels
{
    public interface IStat
    {
        string Name { get; set; }
        long Defaultvalue { get; set; }
        string DisplayName { get; set; }
    }
}
