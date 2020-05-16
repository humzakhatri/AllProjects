using Framework.Interfaces;
using Runtime.Data;
using Runtime.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Runtime.Writers
{
    public abstract class WriterBase : IWriter
    {
        public string Name { get; set; }

        public virtual void Dispose()
        {
        }

        public abstract void Write(IDataObject obj);

        public abstract void Write(Record record);
    }
}
