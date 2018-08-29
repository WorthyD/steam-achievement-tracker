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
            IPlayerProfile ipp;

            if (profile == null)
            {
                ipp = await this.AddUserProfile(steamID);
            }
            else if (ExperationService.isProfileExpired(profile.LastUpdate))
            {
                ipp = await this.UpdateUserProfile(profile);
            }
            else
            {
                ipp = this._mapper.Map<PlayerProfileDTO>(profile);
            }



            return ipp;
        }
        private async Task<IPlayerProfile> AddUserProfile(long steamId)
        {
            var steamProfile = this.GetExternalProfile(steamId);
            PlayerProfileDTO playerProfile = this._mapper.Map<PlayerProfileDTO>(steamProfile);
            playerProfile.LastUpdate = DateTime.Now;
            playerProfile.LibraryLastUpdate = new DateTime(2000, 1, 1);

            //Async save
            this._profileRepo.Save(steamId, playerProfile);

            return playerProfile;
        }

        private async Task<IPlayerProfile> UpdateUserProfile(PlayerProfile profile)
        {
            var steamProfile = this.GetExternalProfile(profile.SteamId);
            PlayerProfileDTO playerProfile = this._mapper.Map<PlayerProfileDTO>(steamProfile);
            playerProfile.LastUpdate = DateTime.Now;

            this._profileRepo.Save(profile.SteamId, playerProfile);

            return playerProfile;
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
                throw new Exceptions.PlayerNotFoundException();
            }
            return response.Players.FirstOrDefault();

        }

    }
}
