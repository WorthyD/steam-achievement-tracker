using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sat_contracts.repositories
{
    public interface IGameSchemaRepo
    {

        Task<models.IGameSchema> Load(object appId);
        Task SaveSchema(long AppId, sat_contracts.models.ServiceModels.IGame game, sat_contracts.models.ServiceModels.IAchievementPercentages serviceAch);
    }
}
