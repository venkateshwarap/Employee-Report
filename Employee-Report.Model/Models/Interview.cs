using System;
using System.Collections.Generic;

namespace Employee_Report.Model.Models;

public class Interview
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string Status { get; set; } = null!;
    public DateTime Date { get; set; } = DateTime.Now;
    public string ReportingTo { get; set; } = null!;
}
