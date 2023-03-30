using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Report.Model.ModelView
{
    public class EmployeeLearningView
    {
            public string? EmpId { get; set; }
            public DateTime? EndDate { get; set; }
            public DateTime? StartDate { get; set; }
            public string? Duration { get; set; }
            public string? LearningName { get; set; }
            public string? LearningPath { get; set; }
            public int HoursOfLearning { get; set; }
    }
}
