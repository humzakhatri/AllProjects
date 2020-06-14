using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    public class RestDeploymentSettingController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Rest Deployment Settings";
            return View();
        }


        //just a test
        [HttpPost]
        public async Task<IActionResult> UploadFile(List<IFormFile> files)
        {
            //TODO: add the logic here to save the file to disk
            return Redirect(nameof(Index));//TODO this has a problem when we click upload twice.
        }
    }
}
