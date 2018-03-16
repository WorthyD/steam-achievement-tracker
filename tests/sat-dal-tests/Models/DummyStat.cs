using sat_contracts.models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace sat_dal_tests.Models
{
    public class DummyStat : IStat
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public long Defaultvalue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DisplayName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
