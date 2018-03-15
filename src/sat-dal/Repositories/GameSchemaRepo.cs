


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

namespace sat_dal.Repositories
{
    public class GameSchemaRepo : EFRepo<ModelContext, Models.GameSchema>, IGameSchemaRepo
    {
        public GameSchemaRepo(ModelContext context) : base(context)
        {
        }

        public async Task<IGameSchema> LoadGame(object appId)
        {
            return await this.Load(appId) as IGameSchema;
        }


        public override async Task<Models.GameSchema> Load(object appId)
        {
            Models.GameSchema gs = null;

            long id = (long)appId;

            gs = await Context.GameSchemas
                .Include(x => x.GameAchievements)
                .FirstOrDefaultAsync(x => x.AppId == id);

            return gs;

        }

        public async Task<IGameSchema> SaveGameSchema(long AppId, sat_contracts.models.ServiceModels.IGame game, sat_contracts.models.ServiceModels.IAchievementPercentages serviceAch)
        {
            return await this.SaveSchema(AppId, game, serviceAch) as IGameSchema;
        }

        public async Task<Models.GameSchema> SaveSchema(long AppId, sat_contracts.models.ServiceModels.IGame game, sat_contracts.models.ServiceModels.IAchievementPercentages serviceAch)
        {
            long appId = AppId;

            Models.GameSchema gameSchema;

            if (appId < 1)
            {
                gameSchema = Create() as Models.GameSchema;
            }
            else
            {
                gameSchema = await this.Load(appId) as Models.GameSchema;
            }

            if (game.AvailableGameStats != null && game.AvailableGameStats.Achievements != null)
            {
                var gameAchievements = gameSchema.GameAchievements;

                if (gameAchievements == null)
                {
                    gameSchema.GameAchievements = null;
                }

                var actualPercentages = new List<IAchievementPercentage>();

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


                }
                gameSchema.LastSchemaUpdate = DateTime.Now;
                gameSchema.HasAchievements = true;
                gameSchema.AvgUnlock = (int)(actualPercentages.Average(x => x.Percent));

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

            return gameSchema;

        }


    }
}
