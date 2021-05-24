using System;
using System.Collections.Generic;

namespace University.Models
{
  public class Student
  {
    public Student()
    {
      this.JoinEntities = new HashSet<CourseStudent>();
    }
    public int StudentId { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public bool VaccinationStatus { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public virtual ICollection<CourseStudent> JoinEntities { get; set; }
  }

}