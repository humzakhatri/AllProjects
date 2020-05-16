using Framework.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Interfaces
{
    public interface IDataObject : INamed
    {
        MetaBase Meta { get; }
        void SetMeta(MetaBase meta);
    }

    public interface IDataSingleObject : IDataObject
    {
        void SetValue(string name, string value);
    }

    public interface IDataCollectionObject : IDataObject
    {
        void AddValue(int index, string fieldName, string value);
    }
}
