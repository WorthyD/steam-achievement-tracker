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
            : base("AE24AB02B6610D51BA9C8EA4128D11F3")
        {
            this._gameSchemaRepo = _gsr;
        }


        public async Task<IGameSchema> GetGameAchievements(long appId)
        {
            var game = await this._gameSchemaRepo.Load(appId);
            if (game == null || ExperationService.isSchemaExpired(game.LastSchemaUpdate))
            {
                var gameSchemaRequest = new SteamApiWrapper.SteamUserStats.GetSchemaForGameRequest(base.APIKey);
                var gameStatRequest = new SteamApiWrapper.SteamUserStats.GetGlobalAchievementPercentagesForAppRequest();
                gameSchemaRequest.appid = (int)appId;
                gameStatRequest.GameId = (int)appId;

                var gameSchema = gameSchemaRequest.GetResponse();
                var gameStats = gameStatRequest.GetResponse();

                //await Task.WhenAll(gameSchema, gameStats);
                var gameSchemaResult = await gameSchema;
                var gameStatsResult = await gameStats;

                var g = new sat_service_converter.DTOs.Game(gameSchemaResult.GameSchema);
                var ach = new sat_service_converter.DTOs.AchievementPercentages(gameStatsResult.GlobalAchievementPercentages.achievements);

                game = await this._gameSchemaRepo.SaveSchema(appId, g, ach); 
            }

            return game;
        }

    }
}
