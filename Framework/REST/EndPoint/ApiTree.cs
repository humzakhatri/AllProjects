using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.REST.EndPoint
{
    public class ApiTree
    {
        public ApiTreeNodeBase Top { get; set; } = new ApiTreeNodeConstant();
        public void Add(string path, HttpMethod method, object tag)
        {
            Top.Add(RestHelper.CleanResource(path).Split('/'), method, tag);
        }

        public void Remove(string path, HttpMethod method)
        {
            Top.Remove(RestHelper.CleanResource(path).Split('/'), method);
        }

        public bool TryMatch(string path, HttpMethod method, out object result)
        {
            var tokens = RestHelper.CleanResource(path).Split('/');
            return Top.TryMatchRequest(tokens, method, out result);
        }
    }
}
