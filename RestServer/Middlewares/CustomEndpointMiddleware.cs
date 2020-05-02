using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestServer.Middlewares
{
    public class CustomEndpointMiddleware
    {
        private readonly RequestDelegate _Next;
        public ARouterMiddleware(RequestDelegate next)
        {
            _Next = next;
            //RouterMiddleware
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
            var task = new Task<bool>(() => false);
            return task;
        }
    }
}
