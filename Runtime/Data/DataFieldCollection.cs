using System;
using System.Collections.Generic;
using System.Text;
using Framework.Data;

namespace Runtime.Data
{
    internal class DataFieldCollection : DataCollection
    {
        public List<DataField> Fields { get; private set; } = new List<DataField>();
        protected override void SetMeta(MetaBase meta)
        {
            if (meta.IsFieldCollection == false)
                throw new Exception("Meta Object is not compatible.");
            Meta = meta;
        }
    }
}
