using System;
using System.Collections.Generic;

namespace Employee.DataModel.Models
{
    public partial class Employee
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public virtual ICollection<EmployeePoc> EmployeePocs { get; } = new List<EmployeePoc>();

        public virtual ICollection<EmployeeProject> EmployeeProjects { get; } = new List<EmployeeProject>();
    }
}