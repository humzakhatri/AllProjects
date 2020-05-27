using Framework.Data;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Layouts
{
    internal abstract class DataCollection : IDataCollectionObject
    {
        protected MetaBase _Meta;
        public virtual MetaBase Meta { get => _Meta; }
        public string Name { get => Meta.Name; set => throw new Exception("Should Not set the name from here."); }

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

        public abstract void SetMeta(MetaBase meta);

        public abstract void AddValue(int index, string fieldName, string value);
    }
}
