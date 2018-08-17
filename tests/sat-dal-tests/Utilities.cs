using System;
using System.Collections.Generic;
using System.Text;

namespace sat_dal_tests
{

    public class Utilities
    {
        public static Models.DummyGame getDummyGame()
        {
            Models.DummyGame game = new Models.DummyGame();
            game.GameName = "Dummy1";
            game.GameVersion = "1";

            Models.DummyAvailableGameStats gs = new Models.DummyAvailableGameStats();
            //List<Models.DummyAchievement> gaList = new List<Models.DummyAchievement>();



            List<sat_contracts.models.ServiceModels.IAchievement> list = new List<sat_contracts.models.ServiceModels.IAchievement>();
            list.Add(new Models.DummyAchievement()
            {
                DefaultValue = 1000,
                Description = "Desc 1",
                DisplayName = "Ach 1",
                Hidden = 1,
                Icon = "blue",
                Icongray = "gray",
                Name = "Ach_1"
            });
            list.Add(new Models.DummyAchievement()
            {
                DefaultValue = 2000,
                Description = "Desc 2",
                DisplayName = "Ach 2",
                Hidden = 1,
                Icon = "blue",
                Icongray = "gray",
                Name = "Ach_2"
            });

            gs.Achievements = list.ToArray();



            List<sat_contracts.models.ServiceModels.IStat> stats = new List<sat_contracts.models.ServiceModels.IStat>();
            stats.Add(new Models.DummyStat()
            {
                Defaultvalue = 1000,
                DisplayName = "Test1",
                Name = "Test1"
            });

            stats.Add(new Models.DummyStat()
            {
                Defaultvalue = 2000,
                DisplayName = "Test2",
                Name = "Test2"
            });

            Models.DummyAvailableGameStats dma = new Models.DummyAvailableGameStats()
            {
                Achievements = list.ToArray(),
                Stats = stats.ToArray()
            };

            game.AvailableGameStats = dma;

            return game;
        }
        public static Models.DummyAchievementPercentages getDummyAchievementPercentages()
        {
            var retVal = new Models.DummyAchievementPercentages();
            retVal.ListAchievementPercentages = new List<sat_contracts.models.ServiceModels.IAchievementPercentage>();

            retVal.ListAchievementPercentages.Add(new Models.DummyAchievementPercentage() {
                Name = "Ach1",
                Percent = 0
            });

            retVal.ListAchievementPercentages.Add(new Models.DummyAchievementPercentage() {
                Name = "Ach2",
                Percent = 100
            });

            return retVal;
        }

        public static Models.DummyProfile getDummyProfile()
        {
            return new Models.DummyProfile()
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
