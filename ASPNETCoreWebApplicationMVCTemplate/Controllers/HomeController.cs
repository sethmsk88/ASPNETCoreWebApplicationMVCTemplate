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
        public string Index()
        {
            return "Index() Action Method of HomeController";
        }

        [Route("/[action]")]   // Ignore the route template (i.e. Home) placed at the controller level
        public string About()
        {
            return "About() Action Method of HomeController";
        }

        [Route("[action]")]
        public string Contact()
        {
            return "Contact() Action Method of HomeController";
        }
    }
}
