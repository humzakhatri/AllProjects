using DataAccess.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Readers.Database
{
    internal class DbReaderBase : ReaderBase
    {
        public override IEnumerable<Record> Read()
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {

        }
    }
}
