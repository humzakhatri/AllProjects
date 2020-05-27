using System;
using System.Collections.Generic;
using System.Text;
using Framework.Data;

namespace DataAccess.Layouts
{
    internal class DataObjectCollection : DataCollection
    {
        public List<DataObjectRecord> Objects { get; protected set; } = new List<DataObjectRecord>();

        public override void SetMeta(MetaBase meta)
        {
            if (meta.IsObjectCollection == false)
                throw new Exception("Meta object is not compatible.");
            _Meta = meta;
        }

        public override void AddValue(int index, string fieldName, string value)
        {
            throw new Exception("Cannot set value in a Object collection.");
        }

    }
}
