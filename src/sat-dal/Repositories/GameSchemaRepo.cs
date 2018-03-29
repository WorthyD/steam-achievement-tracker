


using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using sat_contracts.models;
using sat_contracts.repositories;
using sat_contracts.models.ServiceModels;
using sat_dal.DTOs;

namespace sat_dal.Repositories
{
    public class GameSchemaRepo : EFRepo<ModelContext, Models.GameSchema>, IGameSchemaRepo
    {
        public GameSchemaRepo(ModelContext context) : base(context)
        {
        }

        public async Task<IGameSchema> LoadGame(object appId)
        {
            var x = await this.Load(appId);
            return AutoMapper.Mapper.Map<GameSchemaDTO>(x) as IGameSchema;
        }


        public override async Task<Models.GameSchema> Load(object appId)
        {
            Models.GameSchema gs = null;

            long id = (long)appId;

            gs = await Context.GameSchemas
                // .Include(x => x.GameAchievements)
                .FirstOrDefaultAsync(x => x.AppId == id);

            return gs;

        }

        public async Task<IGameSchema> SaveGameSchema(long AppId, sat_contracts.models.ServiceModels.IGame game, sat_contracts.models.ServiceModels.IAchievementPercentages serviceAch)
        {
            return await this.SaveSchema(AppId, game, serviceAch) as IGameSchema;
        }

        public async Task<GameSchemaDTO> SaveSchema(long AppId, sat_contracts.models.ServiceModels.IGame game, sat_contracts.models.ServiceModels.IAchievementPercentages serviceAch)
        {
            long appId = AppId;

            Models.GameSchema gameSchema;

            gameSchema = await this.Load(appId) as Models.GameSchema;

            if (gameSchema == null)
            {
                gameSchema = Create() as Models.GameSchema;
            }

            if (game.AvailableGameStats != null && game.AvailableGameStats.Achievements != null)
            {

                if (gameSchema.GameAchievements == null)
                {
                    gameSchema.GameAchievements = new List<Models.GameAchievement>();
                }

                var actualPercentages = new List<double>();

                foreach (var ach in game.AvailableGameStats.Achievements)
                {
                    var gameAch = gameSchema.GameAchievements.Where(x => x.Name == ach.Name).FirstOrDefault();

                    if (gameAch == null)
                    {
                        gameAch = new Models.GameAchievement();
                        gameSchema.GameAchievements.Add(gameAch);
                    }
                    var percentage = serviceAch.AchievementPercentages.Where(x => x.Name == ach.Name).FirstOrDefault();
                    gameAch.AppId = appId;
                    gameAch.DisplayName = ach.DisplayName;
                    gameAch.Description = (string.IsNullOrEmpty(ach.Description)) ? string.Empty : ach.Description;
                    gameAch.Hidden = ach.Hidden == 1 ? true : false;
                    gameAch.Icon = ach.Icon;
                    gameAch.IconGray = ach.Icongray;
                    gameAch.Name = ach.Name;
                    gameAch.Percent = (percentage != null) ? percentage.Percent : 0;

                    actualPercentages.Add(gameAch.Percent);

                }
                gameSchema.LastSchemaUpdate = DateTime.Now;
                gameSchema.HasAchievements = true;
                gameSchema.AvgUnlock = (actualPercentages.Count > 0) ? (int)(actualPercentages.Average(x => x)) : 0;
            }
            else
            {
                gameSchema.LastSchemaUpdate = DateTime.Now;
                gameSchema.HasAchievements = false;
            }

            if (!await SaveAsync())
            {
                return null;
            }

            return AutoMapper.Mapper.Map<GameSchemaDTO>(gameSchema);

        }


    }
}
