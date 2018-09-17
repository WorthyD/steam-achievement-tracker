using SteamApiWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamApiWrapper.PlayerService
{
    [APIKeyRequired]
    public class GetOwnedGamesRequest: Request
    {

        [QueryParameter]
        public long SteamId { get; set; }


        [QueryParameter]
        public string include_appinfo { get; set; }

        [QueryParameter]
        public string include_played_free_games { get; set; }



        public override SteamUrlBuilder.Version ApiVersion
        {
            get
            {
                return SteamUrlBuilder.Version.v1;
            }
        }

        public override SteamUrlBuilder.Interface UrlInterface
        {
            get
            {
                return SteamUrlBuilder.Interface.IPlayerService;
            }
        }

        public override string UrlPath
        {
            get
            {
                return "GetOwnedGames";
            }
        }

        public GetOwnedGamesRequest(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        public async Task<GetOwnedGamesResponse> GetResponse()
        {

            var response = new GetOwnedGamesResponse();
            response = await base.ExecuteRequest(response as Response, this) as GetOwnedGamesResponse;

            return response;


        }
    }
}
