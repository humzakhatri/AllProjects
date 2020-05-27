using DataAccess.Layouts;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IWriter : INamed, IDisposable
    {
        void Write(IDataObject obj);
        void Write(Record record);
    }
}
