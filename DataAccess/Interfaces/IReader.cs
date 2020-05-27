using DataAccess.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IReader : IDisposable
    {
        int RecordsReadCount { get; }
        IEnumerable<Record> Read();
    }
}
