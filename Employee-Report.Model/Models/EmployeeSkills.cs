using System;
using System.Collections.Generic;

namespace Employee.DataModel.Models
{
    public partial class EmployeeSkills
    {
        public int Id { get; set; }

        public string EmpId { get; set; } = null!;

        public int SkillId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; } = null!;

        public DateTime ModifiedOn { get; set; }

        public virtual Skill Skill { get; set; } = null!;
    }
}