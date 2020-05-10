using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Data
{
    public abstract class MetaBase : INamed
    {
        public abstract bool IsHierarchical { get; }
        public virtual bool IsFieldCollection { get => false; }
        public virtual bool IsObjectCollection { get => false; }
        public string Name { get; set; }
        public virtual List<MetaCollection> Collection { get; set; } = new List<MetaCollection>();
        public virtual List<MetaElement> Elements { get; set; } = new List<MetaElement>();
        public virtual List<MetaObject> Children { get; set; } = new List<MetaObject>();
    }
}
