using Microsoft.AspNetCore.Http;
using Runtime.REST;
using Runtime.Runtime;
using Runtime.Server.ServerComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Server
{
    public class RuntimeServer : RuntimeProcessorBase
    {
        private ServerComponentApiEndpoint ServerComponentApiEndpoint { get; set; }
        protected override void OnInitialize()
        {
            ServerComponentApiEndpoint = new ServerComponentApiEndpoint();
        }

        protected override void OnStart()
        {
        }

        public void ProcessRestRequest(RestRequestContext context)
        {

        }
    }
}
