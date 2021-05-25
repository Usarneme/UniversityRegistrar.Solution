using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace University.Models
{
  public class Course
  {
    public Course()
    {
      this.JoinEntities = new HashSet<CourseStudent>();
    }

    public int CourseId { get; set; }
    [Required]
    public string CourseName { get; set; }
    [Required]
    public string CourseDescription { get; set; }
    public virtual ICollection<CourseStudent> JoinEntities { get; set; }
  }
}
