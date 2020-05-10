using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Data
{
    public abstract class MetaCollection : MetaBase
    {
        public override bool IsHierarchical => true;
    }

    public class MetaFieldCollection : MetaCollection
    {
        public override bool IsFieldCollection => true;
        public override List<MetaObject> Children { get => throw new Exception("Can't house objects."); set => throw new Exception("Can't house objects."); }
    }

    public class MetaObjectCollection : MetaCollection
    {
        public override bool IsObjectCollection => true;
        public override List<MetaElement> Elements { get => throw new Exception("Can't  house elements."); set => throw new Exception("Can't house elements."); }
    }
}
