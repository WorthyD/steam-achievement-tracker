using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sat_dal.Repositories
{
    public interface IPlayerProfileRepo
    {
        Task<Models.PlayerProfile> Load(object profileId);
        Task<Models.PlayerProfile> Save(long profileId, sat_contracts.models.IPlayerProfile profile);
    }
}
