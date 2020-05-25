using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Runtime.Runtime
{
    public abstract class RuntimeProcessorBase : IProcessor
    {
        public RuntimeProcessorBase()
        {
        }
        protected abstract void OnInitialize();

        protected abstract void OnStart();

        public void Initialize()
        {
            OnInitialize();
        }

        public void Start()
        {
            OnStart();
        }

        public virtual void Close()
        {

        }

        public virtual void Terminate()
        {
        }

        public virtual void Dispose()
        {

        }
    }
}
