using System;
using System.Collections.Generic;

namespace Employee_Report.Model.Models;

public partial class EmployeeProject
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public string? EmpId { get; set; }

    public DateTime? StartDate { get; set; } = DateTime.Now;

    public DateTime? EndDate { get; set; } = DateTime.Now;

    public string? ReportingTo { get; set; }

    public int RoleId { get; set; }

    public string? Achivements { get; set; }

    //public virtual Project Project { get; set; } = null!;

    //public virtual Role Role { get; set; } = null!;
}
