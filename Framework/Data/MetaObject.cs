using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Data
{
    public class MetaObject : MetaBase
    {
        public List<MetaCollection> Collection { get; set; } = new List<MetaCollection>();
        public List<MetaElement> Elements { get; set; } = new List<MetaElement>();
        public List<MetaObject> Children { get; set; } = new List<MetaObject>();
        public override bool IsCollection => false;
        public override bool IsHierarchical => true;
    }
}
