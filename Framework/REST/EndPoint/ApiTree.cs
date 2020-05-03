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

        public object Find(string path, HttpMethod method)
        {
            var tokens = RestHelper.CleanResource(path).Split('/');
            return Top.MatchRequest(tokens, method);
        }
    }
}
