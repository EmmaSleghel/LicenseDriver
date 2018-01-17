using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Student;
using AutoMapper;
using LicenseDRIVER.Models;

namespace LicenseDRIVER.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public IActionResult Index(Guid id)
        {
            if (!HttpContext.Session.Keys.Contains("User"))
            {
                return RedirectToAction("Unauthorized");
            }
            var student = _studentService.GetStudentById(id);
            var studentviewmodel = Mapper.Map<StudentViewModel>(student);

            return View(studentviewmodel);
        }
    }
}