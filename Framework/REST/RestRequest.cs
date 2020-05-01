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
        public string bodyContent { get; set; }
        public RestRequest(HttpMethod method, string path)
        {
            Method = method;
            Path = path;
        }

        public HttpContent GetContent()
        {
            return BuildContent();
        }

        private HttpContent BuildContent()
        {
            //TODO: Build the content with a content builder
            return new StringContent(bodyContent);
        }
    }
}
