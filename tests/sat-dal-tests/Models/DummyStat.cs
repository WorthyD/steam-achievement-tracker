﻿using sat_contracts.models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace sat_dal_tests.Models
{
    public class DummyStat : IStat
    {
        public string Name { get; set; }
        public long Defaultvalue { get; set; }
        public string DisplayName { get; set; }
    }
}
