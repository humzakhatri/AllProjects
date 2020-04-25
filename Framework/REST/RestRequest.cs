using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Framework.REST
{
    public class RestRequest
    {
        public HttpMethod Method { get; set; }
        public readonly string Path;
        public RestRequest(HttpMethod method, string path)
        {
            Method = method;
            Path = path;
        }
    }
}
