using ASPNETCoreWebApplicationMVCTemplate.Models;
using ASPNETCoreWebApplicationMVCTemplate.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreWebApplicationMVCTemplate.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private List<Student> listStudents = new List<Student>();
        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        // We are using the constructor to inject the service IEmployeeRepository
        public HomeController(IStudentRepository studentRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _studentRepository = studentRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        [Route("")]
        [Route("/")]
        [Route("[action]")]
        public ViewResult Index()
        {
            /*return _studentRepository.GetStudent(101).Name;*/
            var model = _studentRepository.GetAllStudents();
            return View(model);
        }

        [Route("[action]/{id?}")]
        public ViewResult Details(int Id)
        {            
            var studentDetails = listStudents.FirstOrDefault(std => std.StudentId == Id);
            return View(studentDetails);
        }

        [Route("[action]/{id?}")]
        public ViewResult DetailsTest(int Id = 101)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Student = _studentRepository.GetStudent(Id),
                PageTitle = "Student Details"
            };
            return View(homeDetailsViewModel);
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

        [HttpGet]
        [Route("[action]")]
        public ViewResult Create()
        {            
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(StudentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFiles(model);

                Student newStudent = new Student
                {
                    Name = model.Name,
                    Email = model.Email,
                    Branch = model.Branch,
                    Address = model.Address,
                    PhotoPath = uniqueFileName
                };

                _studentRepository.Add(newStudent);
                return RedirectToAction("DetailsTest", new { id = newStudent.StudentId });
            }

            return View();
        }

        [HttpGet]
        [Route("[action]/{id?}")]
        public ViewResult Edit(int id)
        {
            Student student = _studentRepository.GetStudent(id);
            StudentEditViewModel studentEditViewModel = new StudentEditViewModel
            {
                StudentId = student.StudentId,
                Name = student.Name,
                Email = student.Email,
                Branch = student.Branch,
                Address = student.Address,
                ExistingPhotoPath= student.PhotoPath
            };
            return View(studentEditViewModel);
        }

        [HttpPost]
        [Route("[action]/{id?}")]
        public IActionResult Edit(StudentEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Student student = _studentRepository.GetStudent(model.StudentId);
                student.Name = model.Name;
                student.Email = model.Email;
                student.Branch = model.Branch;
                student.Address = model.Address;
                
                if (model.Photos != null && model.Photos.Count > 0)
                {
                    // If student already has a photo, delete it
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePathToDelete = Path.Combine(webHostEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePathToDelete);
                    }
                    student.PhotoPath =  ProcessUploadedFiles(model);
                }

                _studentRepository.Update(student);
                return RedirectToAction("Index");
            }

            return View();
        }

        private string ProcessUploadedFiles(StudentCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photos != null && model.Photos.Count > 0)
            {
                foreach (IFormFile photo in model.Photos)
                {
                    string uploadsDir = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadsDir, uniqueFileName);
                    
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                }
            }

            return uniqueFileName;
        }
    }
}
