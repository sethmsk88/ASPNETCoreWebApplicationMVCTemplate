using ASPNETCoreWebApplicationMVCTemplate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreWebApplicationMVCTemplate.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("/")]
        [Route("[action]")]
        public ViewResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public ViewResult Privacy()
        {
            return View();
        }

        [Route("[action]")]
        public ViewResult Contact()
        {
            return View();
        }

        [Route("/[action]")]   // Ignore the route template (i.e. Home) placed at the controller level
        public string About()
        {
            return "About() Action Method of HomeController";
        }
    }
}
