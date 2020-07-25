using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebSite.Services;

namespace WebSite.Controllers
{
    [Route("UserApi")]
    public class CustomApiController : Controller
    {
        private readonly FileDeploymentManager _DeploymentManager;
        public CustomApiController(FileDeploymentManager deploymentManager)
        {
            _DeploymentManager = deploymentManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("{guid}/{deploymentName}")]
        public IActionResult Get(Guid guid, string deploymentName)
        {
            var response = _DeploymentManager.GetResponse(guid, deploymentName);
            return Json(response);
        }
    }
}
