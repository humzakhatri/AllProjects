using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Data;

namespace Runtime.Data
{
    internal class DataFieldCollection : DataCollection
    {
        public List<Record> Records { get; private set; } = new List<Record>();

        public override void SetMeta(MetaBase meta)
        {
            if (meta.IsFieldCollection == false)
                throw new Exception("Meta Object is not compatible.");
            _Meta = meta;
        }

        public override void AddValue(int index, string fieldName, string value)
        {
            if (Records.Count > index)
            {
                var field = Records[index].FirstOrDefault(f => f.Name == fieldName);
                if (field != null)
                    field.Value = value;
                else
                    throw new Exception("Field not found");
            }
            else if (Records.Count == index)
            {
                var record = new Record();
                foreach (var metaElement in _Meta.Elements)
                {
                    var field = new DataField();
                    field.Meta = metaElement;
                    if (field.Name == fieldName) field.Value = value;
                    record.Add(field);
                }
                Records.Add(record);
            }
            else
            {
                throw new Exception("Record fields should be added in sequence");
            }
        }
    }
}
