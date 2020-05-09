using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.REST.EndPoint;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static Framework.REST.UrlTemplates;

namespace RestServer.Controllers
{
    [ApiController]
    [Route(TServerController)]
    public class ServerController : ControllerBase
    {
        public ServerController()
        {

        }
        [HttpGet]
        public string Get()
        {
            return "The Server is Active.";
        }

        
    }
}
