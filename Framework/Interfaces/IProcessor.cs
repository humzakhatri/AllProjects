using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Interfaces
{
    public interface IProcessor
    {
        void Initialize();
        void Start();
        void Close();
        void Terminate();
    }
}
