using System;
using System.Collections.Generic;

namespace Employee_Report.Model.Models;

public partial class EmployeePoc
{
    public int Id { get; set; }

    public int Pocid { get; set; }

    public string EmpId { get; set; } = null!;

    public int BenchId { get; set; }

    public DateTime? StartDate { get; set; } = DateTime.Now;

    public DateTime? EndDate { get; set; } = DateTime.Now;

    public string? ReportingTo { get; set; }

    public int RoleId { get; set; }

    //public virtual Poc Poc { get; set; } = null!;
    //public virtual Role Role { get; set; } = null!;
}
