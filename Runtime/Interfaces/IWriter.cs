using Framework.Interfaces;
using Runtime.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Interfaces
{
    public interface IWriter : INamed, IDisposable
    {
        void Write(IDataObject obj);
        void Write(Record record);
    }
}
