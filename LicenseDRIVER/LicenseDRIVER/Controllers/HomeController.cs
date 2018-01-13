using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LicenseDRIVER.Models;
using System;
using Services.Student;
using Services.Teacher;
using AutoMapper;

namespace LicenseDRIVER.Controllers
{
    public class HomeController : Controller
    {
        private IStudentService _studentService;
        private ITeacherService _teacherService;
        private IMapper _mapper;

        public HomeController(IStudentService studentService, ITeacherService teacherService, IMapper mapper)
        {
            _studentService = studentService;
            _teacherService = teacherService;
            _mapper = mapper;
        }
    
        [HttpGet]
        public IActionResult Index(Guid id)
        {
        

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
