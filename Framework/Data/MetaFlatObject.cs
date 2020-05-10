using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Data
{
    public class MetaFlatObject : MetaBase
    {
        public override bool IsHierarchical => false;
        public override List<MetaCollection> Collection { get => throw new Exception("Can't house collections."); set => throw new Exception("Can't house collections."); }
        public override List<MetaObject> Children { get => throw new Exception("Can't house objects."); set => throw new Exception("Can't house objects."); }
    }
}
