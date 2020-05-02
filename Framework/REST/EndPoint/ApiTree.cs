using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.REST.EndPoint
{
    public class ApiTree
    {
        public ApiTreeNodeBase Top { get; set; } = new ApiTreeNodeConstant();
        public void Add(string path)
        {
            Top.Add(path);
        }

        public void Remove(string path)
        {

        }
    }
}
