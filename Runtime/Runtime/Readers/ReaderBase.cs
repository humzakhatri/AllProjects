using Runtime.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Runtime.Readers
{
    internal abstract class ReaderBase : IReader
    {
        public string[] Header;
        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {

        }
    }
}
