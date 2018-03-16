using sat_contracts.models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace sat_dal_tests.Models
{
    public class DummyAchievement : IAchievement
    {
        public string Name { get; set; }
        public long DefaultValue { get; set; }
        public string DisplayName { get; set; }
        public int Hidden { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Icongray { get; set; }
    }
}
