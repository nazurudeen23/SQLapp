﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sqlapp.Models;
using Sqlapp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sqlapp.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _course_service;
        private readonly IConfiguration _configuration;

        public CourseController(CourseService _svc, IConfiguration _config)
        {
            _course_service = _svc;
            _configuration = _config;
        }

        // The Index method is used to get a list of courses and return it to the view
        public IActionResult Index()
        {
            IEnumerable<Course> _course_list = _course_service.GetCourses(_configuration.GetConnectionString("SQLConnection"));
            return View(_course_list);
        }
    }
}
