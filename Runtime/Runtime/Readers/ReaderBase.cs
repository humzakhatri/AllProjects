using Runtime.Data;
using Runtime.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Runtime.Readers
{
    internal abstract class ReaderBase : IReader
    {
        public int RecordsReadCount { get; protected set; }
        public abstract IEnumerable<Record> Read();
        public abstract void Dispose();
    }
}
