using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using University.Models;

namespace University.Controllers
{
    public class HomeController : Controller
    {
        private readonly UniversityContext _db;
        public HomeController(UniversityContext db)
        {
            _db = db;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            IQueryable<Course> courses = _db.Courses;
            IQueryable<Student> students = _db.Students;
            IQueryable<Professor> professors = _db.Professors;
            Dictionary<string, int> model = new Dictionary<string, int>() {};
            model.Add("courses", courses.Count());
            model.Add("students", students.Count());
            model.Add("professors", professors.Count());
            return View(model);
        }

    }
}
