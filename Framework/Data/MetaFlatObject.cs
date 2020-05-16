using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Data
{
    public class MetaFlatObject : MetaFieldCollection
    {
        public override bool IsHierarchical => false;
    }
}
