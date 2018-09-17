using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamApiWrapper.SteamUser
{
    public class GetFriendListResponse: Response
    {
        public Models.FriendsList.Friend[] Friends { get; set; }

        public override void Convert()
        {
            var app = JsonConvert.DeserializeObject<Models.FriendsList>(base.RawResponse);
            if (app != null && app.friendslist != null && app.friendslist.friends != null)
            {
                this.Friends = app.friendslist.friends;
            }
            else
            {
                this.Status = ResponseStatus.ResponseStatusCode.NotFound;
                this.StatusMessage = "No Friends Found";
            }
        }
    }
}
