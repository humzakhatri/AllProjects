using Runtime.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Server
{
    public class RuntimeServerBootstrap : RuntimeProcessorBase
    {
        public RuntimeServer RuntimeServer { get; set; }
        public RuntimeServerBootstrap()
        {
            Initialize();
            Start();
        }


        protected override void OnInitialize()
        {
            RuntimeServer = new RuntimeServer();
        }

        protected override void OnStart()
        {
        }
    }
}
