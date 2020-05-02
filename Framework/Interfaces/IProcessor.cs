using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Interfaces
{
    public interface IProcessor
    {
        void Process();
        void Initialize();
        void Start();
        void Terminate();
    }
}
