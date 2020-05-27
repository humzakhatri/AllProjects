using Framework.Data;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Layouts
{
    internal class DataObject : IDataObject
    {
        private MetaBase _Meta;
        public DataField[] Fields { get; set; }
        public DataObject[] Children { get; set; }
        public DataCollection[] Collection { get; set; }
        public MetaBase Meta
        {
            get => _Meta;
        }
        public bool IsHierarchical => Meta.IsHierarchical;

        public string Name { get => Meta.Name; set => throw new Exception("Should not set meta name from data object."); }

        private DataObject() { }
        public static IDataObject Create(MetaBase meta)
        {
            IDataObject obj;
            if (meta.IsFieldCollection)
                obj = new DataFieldCollection();
            else if (meta.IsObjectCollection)
                obj = new DataObjectCollection();
            else
                obj = new DataObject();
            obj.SetMeta(meta);
            return obj;
        }

        public void SetMeta(MetaBase meta)
        {
            if (meta.Elements.Count > 0)
            {
                Fields = new DataField[meta.Elements.Count];
                for (int i = 0; i < Fields.Length; i++)
                    Fields[i].Meta = meta.Elements[i];
            }
            if (meta.Children.Count > 0)
            {
                Children = new DataObject[meta.Children.Count];
                for (int i = 0; i < Children.Length; i++)
                    Children[i].SetMeta(meta.Children[i]);
            }
            if (meta.Collection.Count > 0)
            {
                Collection = new DataCollection[meta.Collection.Count];
                for (int i = 0; i < Collection.Length; i++)
                    Collection[i] = DataCollection.Create(meta.Collection[i]);
            }
            _Meta = meta;
        }

        public void SetValue(string name, string value)
        {
            foreach (var field in Fields)
            {
                if (field.Name == name)
                {
                    field.Value = value;
                    return;
                }
            }
            throw new Exception(string.Format("Field {0} does not exist in {1}.", name, Name));
        }

        public void SetReferenced(IDataObject value)
        {
            throw new NotImplementedException();
        }
    }

    internal class DataObjectRecord : List<DataObject>
    {

    }
}
