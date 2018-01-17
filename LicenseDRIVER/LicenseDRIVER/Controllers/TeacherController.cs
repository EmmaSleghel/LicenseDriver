using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Teacher;
using AutoMapper;
using LicenseDRIVER.Models;
using Services.Student;
using Services.Notification;

namespace LicenseDRIVER.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        private readonly INotificationService _notificationService;


        private readonly IMapper _mapper;
        public TeacherController(ITeacherService teacherService,IStudentService studentService, INotificationService notificationService, IMapper mapper)
        {
            _studentService = studentService;
            _teacherService = teacherService;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public IActionResult Index(Guid id)
        {
            if(!HttpContext.Session.Keys.Contains("User"))
            {
                return RedirectToAction("Unauthorized");
            }
            var teacher = _teacherService.GetTeacherById(id);
            var teacherviewmodel = Mapper.Map<TeacherViewModel>(teacher);
            return View(teacherviewmodel);
        }
        public IActionResult Profile(Guid id)
        {
            var teacher = _teacherService.GetTeacherById(id);
            var teacherviewmodel = Mapper.Map<TeacherViewModel>(teacher);
            return View(teacherviewmodel);
        }
        [HttpPost]
        public IActionResult Profile(TeacherViewModel teacher)
        {
                return View(teacher);

        }
        public IActionResult StudentList(Guid? id)
        {
            var guidi = Guid.NewGuid();
            var students = _studentService.GetStudentsByTeacherId(guidi);
            return View(Mapper.Map<List<StudentViewModel>>(students));
        }
        public IActionResult Notifications()
        {
            var notif = _notificationService.GetAll();
            return View(Mapper.Map<List<NotificationViewModel>>(notif));
        }
    }
}