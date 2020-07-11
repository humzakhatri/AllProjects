using DataAccess.Interfaces;
using DataAccess.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Readers
{
    public abstract class ReaderBase : IReader
    {
        protected int RecordsReadCount;
        public abstract IEnumerable<Record> Read();
        public abstract void Dispose();
    }
}
