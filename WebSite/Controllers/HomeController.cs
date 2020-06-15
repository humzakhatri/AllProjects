using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult RestDeploymentSetting()
        {
            ViewData["Title"] = "Rest Deployment Settings";
            return View();
        }

        public IActionResult LoginRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PerformLogin(LoginModel loginModel)
        {
            //TODO: here you will add the logic to login the user
            return View();
        }

        [HttpPost]
        public IActionResult PerformRegister(RegisterModel registerModel)
        {
            //TODO: here you will add the logic to register the user
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
