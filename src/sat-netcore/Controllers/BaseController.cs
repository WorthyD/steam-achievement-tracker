using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace sat_netcore.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private long GetSteamId()
        {
            return 123456789;
        }
    }
}