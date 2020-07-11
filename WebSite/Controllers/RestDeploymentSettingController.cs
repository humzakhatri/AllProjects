using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Framework.Global;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSite.Services;

namespace WebSite.Controllers
{
    public class RestDeploymentSettingController : Controller
    {
        private string FileDeployment => nameof(FileDeployment);
        private FileDeploymentManager _DeploymentFileHandler;
        public RestDeploymentSettingController(FileDeploymentManager deploymentFileHandler)
        {
            _DeploymentFileHandler = deploymentFileHandler;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Rest Deployment Settings";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(List<IFormFile> files)
        {
            var file = files[0];
            if (file != null)
            {
                var id = await _DeploymentFileHandler.AddFile(file, User.Identity.Name);
                HttpContext.Session.Set(FileDeployment, id.ToByteArray());
            }
            else
                RedirectToAction();
            return RedirectToAction(nameof(FileDataPreview), "RestDeploymentSetting");
        }

        public IActionResult FileDataPreview()
        {
            var id = new Guid(HttpContext.Session.Get(FileDeployment));
            var preview = _DeploymentFileHandler.GetPreview(id);
            return View(preview);
        }

        public IActionResult ProcessFile()
        {
            var id = new Guid(HttpContext.Session.Get(FileDeployment));
            _DeploymentFileHandler.
        }
    }
}
