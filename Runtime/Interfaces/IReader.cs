using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Interfaces
{
    interface IReader : IProcessor
    {
        void Read();
        void ReadNext();
    }
}
