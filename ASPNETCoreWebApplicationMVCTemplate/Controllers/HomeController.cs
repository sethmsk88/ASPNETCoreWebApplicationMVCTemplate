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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ViewResult Details()
        {
            //String string Data
            ViewData["Title"] = "Student Details Page";
            ViewData["Header"] = "Student Details";
            Student student = new Student()
            {
                StudentId = "STD101",
                Name = "James",
                Branch = "CSE",
                Section = "A",
                Gender = "Male"
            };
            //storing Student Data
            ViewData["Student"] = student;
            return View();
        }
    }
}
