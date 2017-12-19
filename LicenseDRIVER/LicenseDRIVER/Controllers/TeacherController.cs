using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Teacher;
using AutoMapper;

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
        public IActionResult Index()
        {
            return View();
        }
    }
}