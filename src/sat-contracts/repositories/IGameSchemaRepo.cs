using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sat_contracts.repositories
{
    public interface IGameSchemaRepo
    {

        Task<models.IGameSchema> LoadGame(object appId);
        Task<models.IGameSchema> SaveGameSchema(long AppId, sat_contracts.models.ServiceModels.IGame game, sat_contracts.models.ServiceModels.IAchievementPercentages serviceAch);
    }
}
