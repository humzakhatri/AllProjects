using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.REST
{
    public enum RestScheme
    {
        Http,
        Https
    }
    public static class RestSchemeHelper
    {
        public static string GetPrefix(RestScheme scheme)
        {
            switch (scheme)
            {
                case RestScheme.Http:
                    return "http://";
                case RestScheme.Https:
                    return "https://";
                default:
                    return "http://";
            }
        }
    }
    public enum HttpMethod
    {
        Get,
        Post,
        Put,
        Delete
    }
}
