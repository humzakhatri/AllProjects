using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Data
{
    public abstract class MetaBase : INamed
    {
        public abstract bool IsCollection { get; }
        public abstract bool IsHierarchical { get; }
        public string Name { get; set; }
    }
}
