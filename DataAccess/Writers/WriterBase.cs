using DataAccess.Interfaces;
using DataAccess.Layouts;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Writer
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
