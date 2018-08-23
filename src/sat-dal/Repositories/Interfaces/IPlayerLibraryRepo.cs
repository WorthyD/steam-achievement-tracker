using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sat_dal.Repositories
{
    public interface IPlayerLibraryRepo
    {
        Task<IList<Models.PlayerGame>> GetLibrary(long steamId);
    }
}
