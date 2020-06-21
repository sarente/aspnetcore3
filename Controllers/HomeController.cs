using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using hoor.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Routing;

namespace hoor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LinkGenerator _linkGenerator;

        public HomeController(ILogger<HomeController> logger,LinkGenerator link)
        {
            _logger = logger;
            _linkGenerator = link;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Link()
        {
            var link=_linkGenerator.GetPathByAction("Privacy","Home");
            return Content(link);
        }

        public string Contact()
        {
            var user= new User(){
                Username="Javad",
                Fullname="Keyvan Fathi",
                Password="12345",
            };

            var json=JsonConvert.SerializeObject(user,Formatting.Indented);
            _logger.LogInformation(json);
            //throw new Exception("This is a exception");
            return json;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
