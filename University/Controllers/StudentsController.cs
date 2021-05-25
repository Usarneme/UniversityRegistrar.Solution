using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using University.Models;

namespace University.Controllers{
  public class StudentsController : Controller
  {
    private readonly UniversityContext _db;

    public StudentsController(UniversityContext db)
    {
      _db = db;
    }

    [HttpGet("/students")]
    public ActionResult Index()
    {
      return View(_db.Students.ToList());
    }

    [HttpGet("/students/create")]
    public ActionResult Create()
    {
      ViewBag.CourseId = new SelectList(_db.Courses, "courseId", "Name");
      return View();
    }

    [HttpPost("/students/create")]
    public ActionResult Create(Student student, int courseId)
    {
      _db.Students.Add(student);
      _db.SaveChanges();
      if (courseId != 0)
      {
        _db.CourseStudents.Add(new CourseStudent() { CourseId = courseId, StudentId = student.StudentId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("/students/details/{id}")]
    public ActionResult Details(int id)
    {
      var thisStudent = _db.Students
        .Include(student => student.JoinEntities)
        .ThenInclude(join => join.Course)
        .FirstOrDefault(student => student.StudentId == id);
      return View(thisStudent);
    }

    [HttpGet("/student/edit/{id}")]
    public ActionResult Edit(int id)
    {
      // var CoursesCount = _db.Courses.Count();
      var thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
      return View(thisStudent);
    }

    [HttpPost("/student/edit/{id}"), ActionName("Edit")]
    public ActionResult Edit(Student student, int CourseId)
    {
      if (CourseId != 0)
      {
        _db.CourseStudents.Add(new CourseStudent() { CourseId = CourseId, StudentId = student.StudentId});
      }
      _db.Entry(student).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("/students/delete/{id}")]
    public ActionResult Delete(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      return View(thisStudent);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisStudent = _db.Students.First(student => student.StudentId ==id);
      _db.Students.Remove(thisStudent);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}