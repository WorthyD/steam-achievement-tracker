using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamApiWrapper.SteamNews
{
    public class GetNewsForAppResponse : Response
    {
        public Models.ApplicationNews.AppNews AppNews { get; set; }
        public GetNewsForAppResponse()
        {
        }
        public override void Convert()
        {
            var app = JsonConvert.DeserializeObject<Models.ApplicationNews>(base.RawResponse);
            if (app != null && app.appnews != null)
            {
                AppNews = app.appnews;
            }
            else
            {
                this.Status = ResponseStatus.ResponseStatusCode.NotFound;
                this.StatusMessage = "App not found";
            }
        }

        public GetNewsForAppResponse(GetNewsForAppRequest request) { }
    }
}

