using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sat_dal.Repositories
{
    public interface IGameSchemaRepo
    {
        Task<Models.GameSchema> Load(object appId);
        Task<Models.GameSchema> SaveSchema(long AppId, sat_contracts.models.ServiceModels.IGame game, sat_contracts.models.ServiceModels.IAchievementPercentages serviceAch);
    }
}
