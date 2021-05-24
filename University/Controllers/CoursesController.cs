using Microsoft.AspNetCore.Mvc;
using System.Linq;
using University.Models;

namespace University.Controllers
{
  public class CoursesController : Controller
  {
    private readonly UniversityContext _db;
    public CoursesController(UniversityContext db)
    {
      _db = db;
    }

    [HttpGet("/courses")]
    public ActionResult Index()
    {
      return View(_db.Courses.ToList());
    }

    [HttpGet("/courses/create")]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost("/courses/create")]
    public ActionResult Create(Course course)
    {
      _db.Courses.Add(course);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
