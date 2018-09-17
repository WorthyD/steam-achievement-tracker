using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using SteamApiWrapper.Helpers;

namespace SteamApiWrapper.SteamNews
{
    public class GetNewsForAppRequest : ListRequest
    {
        /// <summary>
        /// Game ID
        /// </summary>
        [QueryParameter]
        public int AppId { get; set; }

        /// <summary>
        /// Result count Returned
        /// </summary>
        [QueryParameter]
        public int Count { get; set; }

        /// <summary>
        /// Length of the contents field
        /// </summary>
        [QueryParameter]
        public int MaxLength { get; set; }

        public override SteamUrlBuilder.Interface UrlInterface
        {
            get
            {
                return Helpers.SteamUrlBuilder.Interface.ISteamNews;
            }
        }

        public override SteamUrlBuilder.Version ApiVersion
        {
            get
            {
                return Helpers.SteamUrlBuilder.Version.v2;
            }
        }

        public override string UrlPath
        {
            get
            {
                return "GetNewsForApp";
            }
        }

        public async Task<GetNewsForAppResponse> GetResponse()
        {

            var response = new GetNewsForAppResponse();
            response = await base.ExecuteRequest(response as Response, this) as GetNewsForAppResponse;
            return response;

        }


    }
}
