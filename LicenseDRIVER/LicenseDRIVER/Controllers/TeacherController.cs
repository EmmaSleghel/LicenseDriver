using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Teacher;
using AutoMapper;
using LicenseDRIVER.Models;

namespace LicenseDRIVER.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;
        public TeacherController(ITeacherService teacherService, IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }
        public IActionResult Index(Guid id)
        {
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
    }
}