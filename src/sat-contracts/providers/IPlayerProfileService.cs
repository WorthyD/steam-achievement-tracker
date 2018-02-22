using sat_contracts.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sat_contracts.providers
{
    public interface IPlayerProfileService
    {
        //Task<IPlayerProfile> GetFreshPlayerDetails(string SteamID, bool update);
        Task<IPlayerProfile> GetProfileFromLogin(long steamId);
        //Task<IPlayerProfile> GetProfileCached(long steam64ID, string steamID);
    }
}
