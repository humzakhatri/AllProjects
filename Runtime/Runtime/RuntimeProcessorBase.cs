using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Runtime
{
    public abstract class RuntimeProcessorBase : IProcessor
    {
        public RuntimeProcessorBase()
        {
            Initialize();
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

        public void Close()
        {

        }

        public void Terminate()
        {
        }

        public void Dispose()
        {

        }
    }
}
