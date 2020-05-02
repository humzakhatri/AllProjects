using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.REST
{
    public static class RestHelper
    {
        public static string MergeUrl(params string[] tokens)
        {
            string final = string.Empty;
            bool first = false;
            for (int i = 0; i < tokens.Length; i++)
            {
                tokens[i] = CleanResource(tokens[i]);
                if (first)
                    final = $"{final}/{tokens[i]}";
                else
                    final = $"{final}/{tokens[i]}";
                first = false;
            }
            return final;
        }

        public static string CleanResource(string resource)
        {
            if (resource.StartsWith('/')) resource = resource.Substring(1);
            if (resource.EndsWith('/')) resource = resource.Substring(0, resource.Length - 1);
            return resource;
        }
    }
}
