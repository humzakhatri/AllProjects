using Runtime.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Runtime.Readers
{
    internal abstract class ReaderBase : IReader
    {
        public abstract void Read();
        public abstract void Dispose();
    }
}
