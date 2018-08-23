using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace sat_dal.Repositories
{
   public  class PlayerLibraryRepo : EFRepo<ModelContext, Models.PlayerGame>, IPlayerLibraryRepo
    {
        public PlayerLibraryRepo(ModelContext context) : base(context)
        {

        }

        public async Task<IList<Models.PlayerGame>> GetLibrary(long steamId)
        {
            return await Context.PlayerGames.Include(x => x.GameSchema).Where(x => x.SteamId == steamId).ToListAsync();
        }
    }
}
