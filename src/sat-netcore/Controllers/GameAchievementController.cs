using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sat_business.Providers;

namespace sat_netcore.Controllers
{
    [Produces("application/json")]
    [Route("api/GameAchievement")]
    public class GameAchievementController : Controller
    {

        private GameAchievementProvider AchievementProvider;

        public GameAchievementController(GameAchievementProvider gap)
        {
            AchievementProvider = gap;
        }



        public async Task<ActionResult> Get()
        {
            //return Ok(sat_business.Providers.GameAchievementProvider())
            var x = await AchievementProvider.GetGameAchievements(49520);

            return Ok(x);
        }
    }
}