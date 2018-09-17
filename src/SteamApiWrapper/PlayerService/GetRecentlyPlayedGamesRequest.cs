using SteamApiWrapper.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamApiWrapper.PlayerService
{
    [APIKeyRequired]
    public class GetRecentlyPlayedGamesRequest : Request
    {
        [QueryParameter]
        public long SteamId { get; set; }

        [QueryParameter]
        public int Count { get; set; }


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
                return "GetRecentlyPlayedGames";
            }
        }

        public GetRecentlyPlayedGamesRequest(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        public async Task<GetRecentlyPlayedGamesResponse> GetResponse()
        {

            var response = new GetRecentlyPlayedGamesResponse();
            response = await base.ExecuteRequest(response as Response, this) as GetRecentlyPlayedGamesResponse;

            return response;


        }

    }
}
