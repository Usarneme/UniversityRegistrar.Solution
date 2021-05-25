using System.ComponentModel.DataAnnotations;

namespace University.Models
{
  public class CourseProfessor
  {
    public int CourseProfessorId { get; set; }
    public int CourseId { get; set; }
    public int StudentId { get; set; }
    public virtual Course Course { get; set; }
    public virtual Professor Professor { get; set; }
  }
}
