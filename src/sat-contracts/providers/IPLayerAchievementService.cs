using sat_contracts.models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace sat_contracts.providers
{
    public interface IPLayerAchievementService
    {
        List<IPlayerGameAchievement> GetGameAchievementsCached(string statURL);
        IPlayerGameAchievement GetGameAchievementCached(string statURL, string apiName);
        Task<List<IPlayerGameAchievement>> GetFreshStats(string statURL);
        //Task UpdateStatsByList(List<IGame> statUrls, IProgress<int> progress, CancellationToken ct);
        Task<List<IPlayerGameAchievement>> GetGameStatistics(IPlayerGame game, bool delay = false);
    }
}
