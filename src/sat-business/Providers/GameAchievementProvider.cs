using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using sat_dal.Models;
using sat_contracts.repositories;
using sat_contracts.models;

namespace sat_business.Providers
{
    public class GameAchievementProvider : BaseProvider
    {


        private readonly IGameSchemaRepo _gameSchemaRepo;


        public GameAchievementProvider(IGameSchemaRepo _gsr)
            : base("")
        {
            this._gameSchemaRepo = _gsr;
        }


        //public async Task<Contracts.Models.IGameSchema> GetGameAchievements(long appId)
        public async Task<IGameSchema> GetGameAchievements(long appId)
        {
            //var db = new sat_dal.ModelContext();

            var game = await this._gameSchemaRepo.LoadGame(appId);

            if (game == null || ExperationService.isSchemaExpired(game.LastSchemaUpdate))
            {
                var gameSchemaRequest = new SteamApiWrapper.SteamUserStats.GetSchemaForGameRequest(base.APIKey);
                var gameStatRequest = new SteamApiWrapper.SteamUserStats.GetGlobalAchievementPercentagesForAppRequest();
                gameSchemaRequest.appid = (int)appId;
                gameStatRequest.GameId = (int)appId;

                var gameSchema = gameSchemaRequest.GetResponse();
                var gameStats = gameStatRequest.GetResponse();

                await Task.WhenAll(gameSchema, gameStats);
                var gameSchemaResult = await gameSchema;
                var gameStatsResult = await gameStats;

                var g = new sat_service_converter.DTOs.Game(gameSchemaResult.GameSchema);
                var ach = new sat_service_converter.DTOs.AchievementPercentages(gameStatsResult.GlobalAchievementPercentages.achievements);

                game = await this._gameSchemaRepo.SaveGameSchema(appId, g, ach); //ProcessSchema(db, appId, game, gameSchemaResult.GameSchema, gameStatsResult.GlobalAchievementPercentages.achievements);
            }

            //db.Dispose();
            return game;
        }

        /*
        public DataAccess.Models.GameSchema ProcessSchema(DataAccess.ModelContext db, long appId, DataAccess.Models.GameSchema game, SchemaForGame.Game gameSchema, List<GlobalAchievementPercentages.Achievement> achievementPercentages)
        {
            if (game == null)
            {
                game = new DataAccess.Models.GameSchema();
                db.GameSchemas.Add(game);
                game.AppId = appId;
            }

            //game.Name = (string.IsNullOrEmpty(gameSchema.gameName)) ? "Name title found" : gameSchema.gameName;

            if (gameSchema.availableGameStats != null && gameSchema.availableGameStats.achievements != null)
            {
                var gameAchievements = game.GameAchievements;


                if (gameAchievements == null)
                {
                    //var ga = new List<DataAccess.Models.GameAchievement>();
                    //game.GameAchievements = ga.ToList<IGameAchievement>();// as List<IGameAchievement>;
                    game.GameAchievements = new List<DataAccess.Models.GameAchievement>();
                }

                var actualPercentages = new List<GlobalAchievementPercentages.Achievement>();
                //Update data
                foreach (var ach in gameSchema.availableGameStats.achievements)
                {
                    var gameAch = game.GameAchievements.Where(x => x.Name == ach.name).FirstOrDefault();
                    if (gameAch == null)
                    {
                        gameAch = new DataAccess.Models.GameAchievement();
                        game.GameAchievements.Add(gameAch);
                    }
                    var percentage = achievementPercentages.Where(x => x.name == ach.name).FirstOrDefault();
                    gameAch.ConvertService(appId, ach, percentage);
                    actualPercentages.Add(percentage);
                }
                game.LastSchemaUpdate = DateTime.Now;
                game.HasAchievements = true;

                //TODO: VALIDATE EMPTY DATA
                game.AvgUnlock = (int)(actualPercentages.Average(x => x.percent));
            }
            else
            {
                game.LastSchemaUpdate = DateTime.Now;
                game.HasAchievements = false;
            }

            db.SaveChanges();

            return game;
        }
        */
    }
}
