using Framework.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Data
{
    internal abstract class DataCollection
    {
        private MetaBase _Meta;
        public virtual MetaBase Meta { get => _Meta; protected set { _Meta = value; } }
        protected DataCollection() { }
        public static DataCollection Create(MetaBase meta)
        {
            DataCollection instance;
            if (meta.IsFieldCollection)
                instance = new DataFieldCollection();
            else if (meta.IsObjectCollection)
                instance = new DataObjectCollection();
            else
                throw new Exception("Meta is not compatible.");
            instance.SetMeta(meta);
            return instance;
        }

        protected abstract void SetMeta(MetaBase meta);
    }
}
