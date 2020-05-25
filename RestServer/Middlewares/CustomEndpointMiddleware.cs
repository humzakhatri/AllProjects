using Microsoft.AspNetCore.Http;
using Runtime.REST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestServer.Middlewares
{
    public class CustomEndpointMiddleware
    {
        private readonly RequestDelegate _Next;
        public CustomEndpointMiddleware(RequestDelegate next)
        {
            _Next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (await Handle(context)) { }
                else
                {
                    await _Next(context);
                }
            }
            catch (Exception) { throw; }
        }

        private Task<bool> Handle(HttpContext context)
        {
            //var result = Startup.Bootstrap.RuntimeServer.ProcessRestRequest(new RestRequestContext(context));
            //var task = new Task<bool>(() => result);
            //task.Start();
            //return task;
            return Task.Run(() => false);
        }
    }
}
