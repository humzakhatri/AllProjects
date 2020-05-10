using System;
using System.Collections.Generic;
using System.Text;
using Framework.Data;

namespace Runtime.Data
{
    internal class DataObjectCollection : DataCollection
    {
        public List<DataObject> Objects { get; protected set; } = new List<DataObject>();
        protected override void SetMeta(MetaBase meta)
        {
            if (meta.IsObjectCollection == false)
                throw new Exception("Meta object is not compatible.");
            Meta = meta;
        }

    }
}
