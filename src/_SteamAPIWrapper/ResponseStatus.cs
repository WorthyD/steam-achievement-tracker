using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SteamApiWrapper
{
    public class ResponseStatus
    {
        public enum ResponseStatusCode
        {
            OK = 200,
            Moved = 301,
            MovedPermanently = 301,
            Found = 302,
            Redirect = 302,
            NotModified = 304,
            BadRequest = 400,
            Unauthorized = 401,
            Forbidden = 403,
            NotFound = 404,
            MethodNotAllowed = 405,
            ExpectationFailed = 417,
            InternalServerError = 500,
            NotImplemented = 501,
            BadGateway = 502,
            ServiceUnavailable = 503,
            GatewayTimeout = 504,
            HttpVersionNotSupported = 505
        }
        public static ResponseStatusCode Convert(string status)
        {
            return (ResponseStatusCode)Enum.Parse(typeof(ResponseStatusCode), status, true); ;
        }
    }
}
