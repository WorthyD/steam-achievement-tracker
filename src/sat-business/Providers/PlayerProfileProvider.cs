using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using sat_dal.Models;
using sat_contracts.repositories;
using sat_contracts.models;
using sat_dal.Repositories;
using System.Linq;
using AutoMapper;
using sat_business.DTOs;

namespace sat_business.Providers
{
    public class PlayerProfileProvider : BaseProvider
    {

        private readonly IPlayerProfileRepo _profileRepo;

        private readonly IMapper _mapper;

        public PlayerProfileProvider(IPlayerProfileRepo _repo, IMapper mapper)
           : base("AE24AB02B6610D51BA9C8EA4128D11F3")
        {
            this._profileRepo = _repo;
            this._mapper = mapper;

        }



        public async Task<IPlayerProfile> GetPlayerProfile(long steamID)
        {

            var profile = await this._profileRepo.Load(steamID);

            if (profile == null)
            {

            }
            else if (ExperationService.isProfileExpired(profile.LastUpdate))
            {

            }



            return null;
        }
        private async Task<IPlayerProfile> AddUserProfile(long steamId)
        {
            var steamProfile = this.GetExternalProfile(steamId);
            PlayerProfileDTO playerProfile = this._mapper.Map<PlayerProfileDTO>(steamProfile);
            playerProfile.LastUpdate = DateTime.Now;
            playerProfile.LibraryLastUpdate = new DateTime(2000, 1, 1);

            await this._profileRepo.Save(steamId, playerProfile);
            return playerProfile;
        }

        private async Task<IPlayerProfile> UpdateUserProfile(PlayerProfile profile)
        {

            return null;
        }



        private async Task<SteamApiWrapper.Models.PlayerSummaries.Player> GetExternalProfile(long steamId)
        {

            var request = new SteamApiWrapper.SteamUser.GetPlayerSummariesRequest(base.APIKey);
            request.ProfileIds = new List<long>();
            request.ProfileIds.Add(steamId);

            var response = await request.GetResponse();

            if (response == null || response.Players == null)
            {
                //Throw new exception
            }
            return response.Players.FirstOrDefault();

        }

    }
}
