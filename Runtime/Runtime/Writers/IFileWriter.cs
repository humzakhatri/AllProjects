using Framework.Interfaces;
using Runtime.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Runtime.Writers
{
    internal interface IFileWriter : INamed, IDisposable
    {
        void Write(IDataObject obj);

        void Write(Record record);
    }
}
