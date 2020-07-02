using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Common
{
    public static class ExtensionMethods
    {
        public static string ToDelimited(this IEnumerable<string> values, string delimiter)
        {
            bool first = true;
            var builder = new StringBuilder();
            foreach (var val in values)
            {
                if (first == false)
                    builder.Append(delimiter);
                builder.Append(val);
                first = false;
            }
            return builder.ToString();
        }
    }
}
