using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Interfaces
{
    interface IReader : IDisposable
    {
        void Read();
    }
}
