using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace SteamApiWrapper
{
    public abstract class Response
    {

        //public T Request { get; set; }
        public string StatusMessage { get; set; }
        public string RawResponse { get; set; }
        public ResponseStatus.ResponseStatusCode Status { get; set; }



        public Response()
        {
            //Request = new T();
        }

        //public Response(T request)
        //{
        //    //Request = request;
        //    Status = HttpStatusCode.OK;
        //    StatusMessage = string.Empty;
        //}

        //public Response(T request, HttpStatusCode status, string statusMessage)
        //{
        //    //Request = request;
        //    Status = status;
        //    StatusMessage = statusMessage;
        //}
        public Response(HttpStatusCode status, string statusMessage)
        {
            Status = ResponseStatus.Convert(status.ToString());
            StatusMessage = statusMessage;
        }



        public abstract void Convert();

    }
}
