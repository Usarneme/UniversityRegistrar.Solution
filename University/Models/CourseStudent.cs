using System.ComponentModel.DataAnnotations;

namespace University.Models
{
  public class CourseStudent
  {
    public int CourseStudentId { get; set; }
    public int CourseId { get; set; }
    public int StudentId { get; set; }
    [Required]
    public virtual Course Course { get; set; }
    public virtual Student Student { get; set; }
  }
}