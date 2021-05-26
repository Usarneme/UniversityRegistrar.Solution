using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
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

    [HttpGet("/courses/details/{id}")]
    public ActionResult Details(int id)
    {
      var thisCourse = _db.Courses
        .Include(course => course.JoinEntities)
        .ThenInclude(join => join.Student)
        .FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }

    [HttpGet("/courses/edit/{id}")]
    public ActionResult Edit(int id)
    {
      var thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }

    [HttpPost("/courses/edit/{id}"), ActionName("Edit")]
    public ActionResult Edit(Course course)
    {
      _db.Entry(course).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("/courses/delete/{id}")]
    public ActionResult Delete(int id)
    {
      var thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCourse = _db.Courses.First(course => course.CourseId ==id);
      _db.Courses.Remove(thisCourse);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    ////API
    [HttpPost("/courses/remove_student/{courseStudentId}")]
    public ActionResult DeleteStudentFromCourse(int courseStudentId)
    {
      var thisCourseStudent = _db.CourseStudents.FirstOrDefault(cs => cs.CourseStudentId == courseStudentId);
      _db.CourseStudents.Remove(thisCourseStudent);
      _db.SaveChanges();
      return Content("ok", "application/json");
    }
  }
}
