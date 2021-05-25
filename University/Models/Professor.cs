using System.Collections.Generic;

namespace University.Models
{
  public class Professor
  {
    public int ProfessorId { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public bool VaccinationStatus { get; set; }
    public virtual ICollection<CourseProfessor> JoinEntities { get; set; }
  }
}
