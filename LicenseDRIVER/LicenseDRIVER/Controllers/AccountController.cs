using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LicenseDRIVER.Models;
using Data.Entities;
using Services.Student;
using Services.Dtos;
using System.Security.Cryptography;
using Services.Teacher;
using Microsoft.AspNetCore.Http;

namespace LicenseDRIVER.Controllers
{
    public class AccountController : Controller
    {

        private IStudentService _studentService;
        private ITeacherService _teacherService;
        private PasswordHasher<UserDto> passwordHasher;

        public AccountController(IStudentService studentService, ITeacherService teacherService)
        {
            _studentService = studentService;
            _teacherService = teacherService;
            this.passwordHasher = new PasswordHasher<UserDto>();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsTeacher)
                {
                    var teacher = new TeacherDto()
                    {
                        TeacherId = Guid.NewGuid(),
                        Username = model.Username,
                    };
                    teacher.Password = passwordHasher.HashPassword(teacher, model.Password);
                    _teacherService.CreateTeacher(teacher);

                }
                else
                {
                    var student = new StudentDto()
                    {
                        StudentId = Guid.NewGuid(),
                        Username = model.Username,
                    };
                    student.Password = passwordHasher.HashPassword(student, model.Password);
                    _studentService.CreateStudent(student);
                }

            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsTeacher)
                {
                    var teacher = _teacherService.GetTeacherByUsername(model.Username);
                    if (teacher != null)
                    {
                        var result = passwordHasher.VerifyHashedPassword(teacher, teacher.Password, model.Password);
                        if (result == PasswordVerificationResult.Success)
                        {
                            HttpContext.Session.SetString("User", teacher.Username);
                            return RedirectToAction("Index", "Home");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid login attempt");
                    }

                }
                else
                {
                    var student = _studentService.GetStudentByUsername(model.Username);
                    if (student != null)
                    {
                        var result = passwordHasher.VerifyHashedPassword(student, student.Password, model.Password);
                        if (result == PasswordVerificationResult.Success)
                        {
                            HttpContext.Session.SetString("User", student.Username);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    { ModelState.AddModelError("", "Invalid login attempt"); }
                }
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}