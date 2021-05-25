using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using University.Models;

namespace University.Controllers
{
  public class ProfessorsController : Controller
  {
    private readonly UniversityContext _db;
    public ProfessorsController(UniversityContext db)
    {
      _db = db;
    }

    [HttpGet("/professors")]
    public ActionResult Index()
    {
      return View(_db.Professors.ToList());
    }

    [HttpGet("/professors/create")]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost("/professors/create")]
    public ActionResult Create(Professor professor)
    {
      _db.Professors.Add(professor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("/professors/details/{id}")]
    public ActionResult Details(int id)
    {
      var thisProfessor = _db.Professors
        .Include(professor => professor.JoinEntities)
        .ThenInclude(join => join.Course)
        .FirstOrDefault(professor => professor.ProfessorId == id);
      return View(thisProfessor);
    }

    [HttpGet("/professors/edit/{id}")]
    public ActionResult Edit(int id)
    {
      var thisProfessor = _db.Professors.FirstOrDefault(professor => professor.ProfessorId == id);
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
      return View(thisProfessor);
    }

    [HttpPost("/professors/edit/{id}")]
    public ActionResult Edit(Professor professor)
    {
      _db.Entry(professor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("/professors/delete/{id}")]
    public ActionResult Delete(int id)
    {
      var thisProfessor = _db.Professors.FirstOrDefault(professor => professor.ProfessorId == id);
      return View(thisProfessor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisProfessor = _db.Professors.First(professor => professor.ProfessorId ==id);
      _db.Professors.Remove(thisProfessor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
