using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.REST.EndPoint
{
    public abstract class ApiTreeNodeBase
    {
        object Tag { get; set; }

        public string Value { get; set; }

        public HttpMethod Method { get; set; }

        public List<string> QueryParameters { get; set; } = new List<string>();

        public List<ApiTreeNodeBase> Children { get; set; } = new List<ApiTreeNodeBase>();

        public ApiTreeNodeBase() { }

        public ApiTreeNodeBase(string value)
        {
            Value = value;
        }

        public virtual bool MatchesValue(string value)
        {
            return value == Value;
        }

        public void Add(string[] splitPath, HttpMethod method, object tag, int startAt = 0)
        {
            if (splitPath.Length - 1 == startAt)
            {
                var leaf = CreateNode(splitPath[startAt], tag, method);
                Children.Add(leaf);
            }
            else
            {
                var found = Children.FirstOrDefault(n => Value == splitPath[startAt]);
                if (found == null)
                {
                    found = CreateNode(splitPath[startAt], tag);
                    Children.Add(found);
                }
                found.Add(splitPath, method, tag, startAt + 1);
            }
        }

        public void Remove(string[] splitPath, HttpMethod method, int startAt = 0)
        {
            if (splitPath.Length - 1 == startAt)
            {
                var leaf = Children.FirstOrDefault(n => n.Value == splitPath[startAt] && n.Method == method);
                if (leaf != null) Children.Remove(leaf);
                return;
            }
            var found = Children.FirstOrDefault(n => n.Value == splitPath[startAt]);
            if (found != null)
            {
                found.Remove(splitPath, method, startAt + 1);
                if (found.Children.Count == 0) Children.Remove(found);
            }
        }

        public bool TryMatchRequest(string[] splitPath, HttpMethod method, out object result, int startAt = 0)
        {
            if (splitPath.Length - 1 == startAt)
            {
                var leaf = Children.FirstOrDefault(n => n.MatchesValue(splitPath[startAt]) && n.Method == method);
                if (leaf != null) result = leaf.Tag;
            }
            else
            {
                var found = Children.FirstOrDefault(n => n.MatchesValue(splitPath[startAt]));
                if (found != null)
                    return TryMatchRequest(splitPath, method, out result, startAt + 1);
            }
            result = new object();
            return false;
        }

        public static ApiTreeNodeBase CreateNode(string value, object tag)
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("Value cannot be empty or null");

            if (value.StartsWith('{') && value.EndsWith('}'))
                return new ApiTreeNodeParameter(value) { Tag = tag };
            return new ApiTreeNodeConstant(value) { Tag = tag };
        }

        public static ApiTreeNodeBase CreateNode(string value, object tag, HttpMethod method)
        {
            var node = CreateNode(value, tag);
            node.Method = method;
            return node;
        }
    }

    public class ApiTreeNodeParameter : ApiTreeNodeBase
    {
        public ApiTreeNodeParameter() { }
        public ApiTreeNodeParameter(string value) : base(value)
        {
            Value = value.Substring(1, value.Length - 1);
        }
        public override bool MatchesValue(string value)
        {
            return true;
        }
    }

    public class ApiTreeNodeConstant : ApiTreeNodeBase
    {
        public ApiTreeNodeConstant() { }
        public ApiTreeNodeConstant(string value) : base(value)
        {
        }
    }
}
