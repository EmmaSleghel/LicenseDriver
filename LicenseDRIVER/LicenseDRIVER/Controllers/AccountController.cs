using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LicenseDRIVER.Models;
using Services.Student;
using Services.Dtos;
using Services.Teacher;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace LicenseDRIVER.Controllers
{
    public class AccountController : Controller
    {

        private IStudentService _studentService;
        private ITeacherService _teacherService;
        private PasswordHasher<UserViewModel> _passwordHasher;
        private IMapper _mapper;

        public AccountController(IStudentService studentService, ITeacherService teacherService, IMapper mapper)
        {
            _studentService = studentService;
            _teacherService = teacherService;
            _passwordHasher = new PasswordHasher<UserViewModel>();
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Register()
        {
            var model = new RegisterViewModel()
            {

            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Type==TypeOfUser.Teacher)
                {
                    RegisterNewTeacher(model);
                    HttpContext.Session.SetString("User", model.Username);
                    return RedirectToAction("Index", "Teacher", new { id = model.Id });

                }
                else
                {
                    RegisterNewStudent(model);
                    HttpContext.Session.SetString("User", model.Username);
                    return RedirectToAction("Index", "Student", new { id = model.Id });
                }

            }
           
                return View(model);
            
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
                if (model.Type==TypeOfUser.Teacher)
                {
                    var teacherDto= _teacherService.GetTeacherByUsername(model.Username);
                    var teacher = _mapper.Map<TeacherViewModel>(teacherDto);
                    if (teacher != null)
                    {
                        var result = _passwordHasher.VerifyHashedPassword(teacher, teacher.Password, model.Password);
                        if (result == PasswordVerificationResult.Success)
                        {
                            HttpContext.Session.SetString("User", teacher.Username);
                            return RedirectToAction("Index", "Teacher", new { id = teacher.TeacherId });
                        }
                    }
                }
                else
                {
                    var studentDto= _studentService.GetStudentByUsername(model.Username);
                    var student = _mapper.Map<StudentViewModel>(studentDto);
                    if (student != null)
                    {
                        var result = _passwordHasher.VerifyHashedPassword(student, student.Password, model.Password);
                        if (result == PasswordVerificationResult.Success)
                        {
                            HttpContext.Session.SetString("User", student.Username);
                            return RedirectToAction("Index", "Student", new { id = student.StudentId });
                        }
                    }
                }
            }
            ModelState.AddModelError("", "Invalid login attempt");
            return View(model);
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        private void RegisterNewTeacher(RegisterViewModel model)
        {
            var teacher = new TeacherViewModel()
            {
                TeacherId = Guid.NewGuid(),
                Username = model.Username,
            };
            model.Id = teacher.TeacherId;
            teacher.Password = _passwordHasher.HashPassword(teacher, model.Password);
            var teacherDto = _mapper.Map<TeacherDto>(teacher);

            _teacherService.CreateTeacher(teacherDto);
        }
        private void RegisterNewStudent(RegisterViewModel model)
        {
            var student = new StudentViewModel()
            {
                StudentId = Guid.NewGuid(),
                Username = model.Username,
            };
            model.Id = student.StudentId;
            student.Password = _passwordHasher.HashPassword(student, model.Password);
            var studentDto = _mapper.Map<StudentDto>(student);
            _studentService.CreateStudent(studentDto);
        }
    }
}