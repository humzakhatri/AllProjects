using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Framework.Authentication;
using Framework.Global;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Runtime.Flow_Processors;
using Runtime.Runtime.Pipeline;
using WebSite.Services;

namespace WebSite.Controllers
{
    public class RestDeploymentSettingController : Controller
    {
        private string FileDeployment => nameof(FileDeployment);
        private FileDeploymentManager _FileDeploymentManager;
        private UserManager<KUser> _UserManager;
        public RestDeploymentSettingController(FileDeploymentManager deploymentFileHandler, UserManager<KUser> userManager)
        {
            _UserManager = userManager;
            _FileDeploymentManager = deploymentFileHandler;
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
                var id = await _FileDeploymentManager.AddFile(file, User.Identity.Name);
                HttpContext.Session.Set(FileDeployment, id.ToByteArray());
            }
            else
                RedirectToAction();
            return RedirectToAction(nameof(FileDataPreview), "RestDeploymentSetting");
        }

        public IActionResult FileDataPreview()
        {
            var id = new Guid(HttpContext.Session.Get(FileDeployment));
            var preview = _FileDeploymentManager.GetPreview(id);
            return View(preview);
        }

        public IActionResult ProcessFile()
        {
            var id = new Guid(HttpContext.Session.Get(FileDeployment));
            var user = _UserManager.FindByNameAsync(User.Identity.Name).Result;
            _FileDeploymentManager.CreateDeployment(id, user.Id);
            return View();
        }

        public IActionResult DeploymentName()
        {
            return View();
        }
    }
}
