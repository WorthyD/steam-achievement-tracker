using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using sat_business.Providers;

namespace sat_netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private PlayerProfileProvider PlayerProvider;
        public ProfileController(PlayerProfileProvider pr)
        {
            PlayerProvider = pr;
        }

        public async Task<ActionResult> Get()
        {
            //Get SteamID from logged in user.
            long steamId = 76561198025095151;

            var p = await PlayerProvider.GetPlayerProfile(steamId); 

            return Ok(p);
        }

    }
}