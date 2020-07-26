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
        private readonly FileDeploymentReader _DeploymentReader;
        public CustomApiController(FileDeploymentReader deploymentReader)
        {
            _DeploymentReader = deploymentReader;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("{deploymentName}")]
        public IActionResult Get(string deploymentName)
        {
            var response = _DeploymentReader.GetResponse(deploymentName);
            return Content(response);
        }

        [HttpGet("{deploymentName}/{id}")]
        public IActionResult Get(string deploymentName, string id)
        {
            var response = _DeploymentReader.GetResponse(deploymentName, id);
            return Json(response);
        }
    }
}
