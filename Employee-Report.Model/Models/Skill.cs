namespace Employee_Report.Model.Models
{
    public class Skill
    {
        public int Id { get; set; }

        public string SkillName { get; set; } = null!;

        public virtual ICollection<EmployeeSkills> EmployeeSkills { get; } = new List<EmployeeSkills>();
    }
}
