using Runtime.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Server
{
    public class RuntimeServerBootstrap : RuntimeProcessorBase
    {
        public RuntimeServerBootstrap()
        {
            Initialize();
            Start();
        }

        public RuntimeServer RuntimeServer { get; set; }

        public override void OnInitialize()
        {
            RuntimeServer = new RuntimeServer();
        }

        public override void OnStart()
        {
        }
    }
}
