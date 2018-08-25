using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using sat_dal.Models;
using sat_contracts.repositories;
using sat_contracts.models;
using sat_dal.Repositories;

namespace sat_business.Providers
{
    public class PlayerProfileProvider : BaseProvider
    {

        private readonly IPlayerProfileRepo _profileRepo;

        public PlayerProfileProvider(IPlayerProfileRepo _repo)
           : base("AE24AB02B6610D51BA9C8EA4128D11F3")
        {
            this._profileRepo = _repo;

        }



        public async Task<IPlayerProfile> GetPlayerProfile(long steamID)
        {

            var profile = await this._profileRepo.Load(steamID);

            if (profile == null || ExperationService.isProfileExpired(profile.LastUpdate))
            {

            }



            return null;
        }

    }
}
