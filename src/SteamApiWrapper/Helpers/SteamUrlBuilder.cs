using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamApiWrapper.Helpers
{
    public class SteamUrlBuilder
    {
        private const string BaseUrl = "http://api.steampowered.com/";

        public enum Interface
        {
            ISteamNews,
            ISteamUserStats,
            ISteamUser,
            IPlayerService,

        }
        public enum Version
        {
            v1,
            v2
        }

        public  string BuildRequestUrl(Interface i, Version v, string path)
        {
            return string.Format("{0}{1}/{2}/{3}/", BaseUrl, GetInterfaceUrl(i),path, GetVersionUrl(v) );
        }


        private string GetInterfaceUrl(Interface i)
        {
            switch (i)
            {
                case Interface.ISteamNews:
                    return "ISteamNews";
                case Interface.ISteamUserStats:
                    return "ISteamUserStats";
                case Interface.ISteamUser:
                    return "ISteamUser";
                case Interface.IPlayerService:
                    return "IPlayerService";
                default:
                    return "";
            }
        }
        private string GetVersionUrl(Version v)
        {
            switch (v)
            {
                case Version.v1:
                    return "v0001";
                case Version.v2:
                    return "v0002";
                default:
                    return "";
            }
        }


    }
}
