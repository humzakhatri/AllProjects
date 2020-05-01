using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.REST
{
    public class RestConnection
    {
        public int TimeoutInSeconds { get; set; } = 15;

        public RestScheme Scheme { get; set; } = RestScheme.Http;

        public string ServerName { get; set; }

        public int Port { get; set; }

        public string FullUrl { get => BuildFullUrl(); }

        public string BaseUrlWihtoutPort { get; set; }

        public HttpMethod HttpMethod { get; set; }

        public RestConnection(string serverName, string baseUrlWithoutPort, int port, RestScheme scheme)
        {
            BaseUrlWihtoutPort = baseUrlWithoutPort;
            Port = port;
            Scheme = scheme;
            ServerName = serverName;
        }
        private string BuildFullUrl()
        {
            return $"{RestSchemeHelper.GetPrefix(Scheme)}{ServerName}:{Port}{BaseUrlWihtoutPort}";
        }
    }
}
