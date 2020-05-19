using Framework.Interfaces;
using Runtime.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Interfaces
{
    interface IReader : IDisposable
    {
        IAsyncEnumerable<Record> Read();
    }
}
