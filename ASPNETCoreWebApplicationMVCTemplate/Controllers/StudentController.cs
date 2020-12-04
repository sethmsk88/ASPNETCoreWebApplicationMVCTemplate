using ASPNETCoreWebApplicationMVCTemplate.Models;
using ASPNETCoreWebApplicationMVCTemplate.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreWebApplicationMVCTemplate.Controllers
{
    [Route("[controller]")]
    public class StudentController : Controller
    {
        [Route("")]
        [Route("[action]")]
        public string Index()
        {
            return "Student/Index";
        }

        [Route("[action]/{id?}")]
        public ViewResult Details(int id)
        {
            //Student Basic Details
            Student student = new Student()
            {
                StudentId = 101,
                Name = "Dillip",
                Branch = "CSE",
                Section = "A",
                Gender = "Male"
            };
            //Student Address
            Address address = new Address()
            {
                StudentId = 101,
                City = "Mumbai",
                State = "Maharashtra",
                Country = "India",
                Pin = "400097"
            };
            //Creating the View model
            StudentDetailsViewModel studentDetailsViewModel = new StudentDetailsViewModel()
            {
                Student = student,
                Address = address,
                Title = "Student Details Page",
                Header = "Student Details",
            };
            //Pass the studentDetailsViewModel to the view
            return View(studentDetailsViewModel);
        }

    }
}
