using DataAccess.Interfaces;
using DataAccess.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Readers
{
    public abstract class ReaderBase : IReader
    {
        public int RecordsReadCount { get; protected set; }
        public abstract IEnumerable<Record> Read();
        public abstract void Dispose();
    }
}
