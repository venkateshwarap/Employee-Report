using System;
using System.Collections.Generic;

namespace Employee_Report.Model.Models
{
    public partial class Project
    {
        public int Id { get; set; }

        public string? ProjectName { get; set; }

        public virtual ICollection<EmployeeProject> EmployeeProjects { get; } = new List<EmployeeProject>();
    }
}
