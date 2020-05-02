using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Runtime
{
    public abstract class RuntimeProcessorBase : IProcessor
    {
        protected abstract void OnInitialize();

        protected abstract void OnStart();

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
