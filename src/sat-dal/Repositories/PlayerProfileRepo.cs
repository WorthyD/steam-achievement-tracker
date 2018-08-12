
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using sat_contracts.models;
using sat_contracts.repositories;
using sat_contracts.models.ServiceModels;
using sat_dal.DTOs;


namespace sat_dal.Repositories
{
    public class PlayerProfileRepo : EFRepo<ModelContext, Models.PlayerProfile>, IPlayerProfileRepo
    {
        public PlayerProfileRepo(ModelContext context): base(context)
        {

        }

        public override async Task<Models.PlayerProfile> Load(object profileId)
        {
            Models.PlayerProfile pp = null;
            long id = (long)profileId;

            pp = await Context.PlayerProfiles.FirstOrDefaultAsync(x => x.SteamId == id);


            return pp;
        }

        public async Task<IPlayerProfile> LoadProfile(object profileId)
        {
            var x = await this.Load(profileId);
            return AutoMapper.Mapper.Map<GameSchemaDTO>(x) as IPlayerProfile;
        }

        public async Task<IPlayerProfile> SaveProfile(long profileId, sat_contracts.models.IPlayerProfile profile) {
            return await this.Save(profileId, profile) as IPlayerProfile;
           
        }

        private async Task<PlayerProfileDTO> Save(long profileId, sat_contracts.models.IPlayerProfile profile)
        {
            Models.PlayerProfile p;

            p = await this.Load(profileId);
            if (p == null)
            {
                p = Create() as Models.PlayerProfile;
            }

            p = profile as Models.PlayerProfile;

            if (!await SaveAsync(p))
            {
                return null;
            }

            return AutoMapper.Mapper.Map<PlayerProfileDTO>(p);

        }


    }
}
