using System;
using System.Collections.Generic;

namespace Employee_Report.Model.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<EmployeeProject> EmployeeProjects { get; } = new List<EmployeeProject>();
    public virtual ICollection<EmployeePoc> EmployeePocs { get; } = new List<EmployeePoc>();
}
