using System;
using System.Collections.Generic;
using System.Text;

namespace sat_tests_shared
{
    public static class MockData
    {
        public static long WORTHYD_STEAMID = 76561198025095151;
        public static long STARDEW_APPID = 413150;
        public static long BORDERLAND_APPID = 49520;
        public static long FF6_APPID = 382900;

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

        public static sat_dal.Models.PlayerGame getMockGame(long appId)
        {
            sat_dal.Models.PlayerGame game = new sat_dal.Models.PlayerGame();
            game.AppID = appId;
            game.LastUpdated = DateTime.MinValue;
            game.SteamId = STARDEW_APPID;
            game.TotalAchievements = 1;
            game.Playtime2weeks = 0;
            game.PlaytimeForever = 0;

            return game;
        }

        public static List<sat_dal.Models.PlayerGame> getMockLibrary()
        {
            var lib = new List<sat_dal.Models.PlayerGame>();
            lib.Add(getMockGame(STARDEW_APPID));
            lib.Add(getMockGame(BORDERLAND_APPID));
            lib.Add(getMockGame(FF6_APPID));

            return lib;
        }
    }
}
