using Framework.REST;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.REST
{
    public class RestRequestContext
    {
        public string Url { get; set; }
        public HttpMethod Method { get; set; }
        public Dictionary<string, string> QueryParameters { get; set; } = new Dictionary<string, string>();
        public readonly HttpContext HttpContext;
        public RestRequestContext(HttpContext httpcontext)
        {
            HttpContext = httpcontext;
            Initialize();
        }

        private void Initialize()
        {
            Url = HttpContext.Request.Path;
            Method = RestHelper.ParseMethod(HttpContext.Request.Method);
            ParseQueryParameters();
        }

        private void ParseQueryParameters()
        {
            foreach (var param in HttpContext.Request.Query)
            {
                QueryParameters.Add(param.Key, param.Value);
            }
        }
    }
}
