using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Data
{
    public class MetaFlatObject : MetaBase
    {
        public override bool IsCollection => true;
        public override bool IsHierarchical => false;
        public List<MetaElement> Elements { get; set; }
    }
}
