using System;
using System.Collections.Generic;

namespace Employee.DataModel.Models
{
    public partial class Skill
    {
        public int Id { get; set; }

        public string SkillName { get; set; } = null!;

        public virtual ICollection<EmployeeSkills> EmployeeSkills { get; } = new List<EmployeeSkills>();
    }
}
