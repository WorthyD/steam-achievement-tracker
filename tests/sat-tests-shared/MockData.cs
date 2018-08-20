using System;
using System.Collections.Generic;
using System.Text;

namespace sat_tests_shared
{
    public static class MockData
    {
        public static sat_dal.Models.PlayerProfile getMockProfile()
        {
            return new sat_dal.Models.PlayerProfile
            {
                AvatarFull = "lorem",
                LastUpdate = DateTime.Now,
                LibraryLastUpdate = DateTime.Now,
                PersonaName = "Testing",
                ProfileUrl = "Testing 1",
                RealName = "testing 2",
                SteamId = 123456
            };
        }
    }
}
