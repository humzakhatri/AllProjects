using Runtime.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Runtime.Readers.Database
{
    internal class DbReaderBase : ReaderBase
    {
        public override IAsyncEnumerable<Record> Read()
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {

        }
    }
}
