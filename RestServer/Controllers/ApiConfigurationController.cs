using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.REST.EndPoint;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Runtime.Persisters;
using static Framework.REST.UrlTemplates;

namespace RestServer.Controllers
{
    [ApiController]
    [Route(TApiConfigurationController)]
    public class ApiConfigurationController : ObjectControllerBase<ApiConfiguration, ApiConfigurationPersister>
    {
        public ApiConfigurationController(ApiConfigurationPersister persister) : base(persister)
        {
        }
    }
}