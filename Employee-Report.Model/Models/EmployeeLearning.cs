using System;
using System.Collections.Generic;

namespace Employee_Report.Model.Models
{
public partial class EmployeeLearning
{
    public int Id { get; set; }

    public int? LearningId { get; set; }

    public string? EmpId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
    
    }
}
