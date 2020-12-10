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
        private List<Student> listStudents = new List<Student>();

        [Route("")]
        [Route("/")]
        [Route("[action]")]
        public ViewResult Index()
        {
            List<Student> listStudents = new List<Student>()
            {
               new Student() { StudentId = 101, Name = "James", Branch = Branch.CSE, Gender = Gender.Male, Address = "A1-2018", Email = "James@g.com" },
               new Student() { StudentId = 102, Name = "Priyanka", Branch = Branch.ETC, Gender = Gender.Female, Address = "A1-2019", Email = "Priyanka@g.com" },
               new Student() { StudentId = 103, Name = "David", Branch = Branch.CSE, Gender = Gender.Male, Address = "A1-2020", Email = "David@g.com" }
            };
            return View(listStudents);
        }

        [Route("[action]/{id?}")]
        public ViewResult Details(int Id)
        {
            var studentDetails = listStudents.FirstOrDefault(std => std.StudentId == Id);
            return View(studentDetails);
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
