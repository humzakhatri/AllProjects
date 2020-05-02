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
                if (tokens[i].StartsWith('/')) tokens[i] = tokens[i].Substring(1);
                if (tokens[i].EndsWith('/')) tokens[i] = tokens[i].Substring(0, tokens[i].Length - 1);
                if (first)
                    final = $"{final}/{tokens[i]}";
                else
                    final = $"{final}/{tokens[i]}";
                first = false;
            }
            return final;
        }
    }
}
