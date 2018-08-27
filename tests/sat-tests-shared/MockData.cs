using System;
using System.Collections.Generic;
using System.Text;

namespace sat_tests_shared
{
    public static class MockData
    {
        private static long WORTHYD_STEAMID = 76561198025095151;
        private static long STARDEW_APPID = 413150;

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
                SteamId = WORTHYD_STEAMID
            };
        }

        public static sat_dal.Models.PlayerGame getMockGame()
        {
            sat_dal.Models.PlayerGame game = new sat_dal.Models.PlayerGame();
            game.AppID = STARDEW_APPID;
            game.LastUpdated = DateTime.MinValue;
            game.SteamId = 76561198025095151;
            game.TotalAchievements = 1;
            game.Playtime2weeks = 0;
            game.PlaytimeForever = 0;

            return game;
        }
    }
}
