using sat_contracts.models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace sat_dal_tests.Models
{
    public class DummyAvailableGameStats : IAvailableGameStats
    {
        public IAchievement[] Achievements { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IStat[] Stats { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
