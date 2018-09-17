using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamApiWrapper.Models
{
    public class FriendsList
    {
        public Response friendslist { get; set; }

        public class Response
        {
            public Friend[] friends { get; set; }
        }

        public class Friend
        {
            public string steamid { get; set; }
            public string relationship { get; set; }
            public int friend_since { get; set; }
        }

    }
}
