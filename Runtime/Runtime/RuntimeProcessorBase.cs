using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Runtime
{
    public abstract class RuntimeProcessorBase : IProcessor
    {
        public abstract void OnInitialize();

        public abstract void OnStart();

        public void Initialize()
        {
            OnInitialize();
        }

        public virtual void Process()
        {
        }

        public void Start()
        {
            OnStart();
        }

        public void Terminate()
        {
        }
    }
}
