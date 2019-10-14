using System;
using System.Net;

namespace AppService.Services.LogHandlers
{
    public class LogMetadata
    {
        public string RequestContentType { get; set; }
        public string RequestUri { get; set; }
        public string RequestMethod { get; set; }
        public DateTime? RequestTimestamp { get; set; }
        public string ResponseContentType { get; set; }
        public HttpStatusCode ResponseStatusCode { get; set; }
        public DateTime? ResponseTimestamp { get; set; }

        public override string ToString()
        {
            string message = $"RequestContent Type - {RequestContentType}; RequestMethod - {RequestMethod}; RequestUrl - {RequestUri};";
            message += $"RequestTimeStamp - {RequestTimestamp?.ToShortDateString()}{RequestTimestamp?.ToShortTimeString()};";
            message += $"Response TimeStamp - {ResponseTimestamp?.ToShortDateString()}{ResponseTimestamp?.ToShortTimeString()};";
            message += $"ResponseContentType -  {ResponseContentType} ReponseStatusCode - {ResponseStatusCode.ToString()}";

            return message;
        }
    }
}