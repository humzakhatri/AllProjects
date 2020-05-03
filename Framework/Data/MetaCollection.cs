using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Data
{
    public abstract class MetaCollection : MetaBase
    {
        public override bool IsCollection => true;
        public override bool IsHierarchical => true;
    }

    public class MetaFieldCollection : MetaCollection
    {
        public List<MetaElement> Elements { get; set; } = new List<MetaElement>();
    }

    public class MetaObjectCollection : MetaCollection
    {
        public List<MetaObject> Children { get; set; } = new List<MetaObject>();
    }
}
