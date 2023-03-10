using System;
using System.Collections.Generic;

namespace Employee.DataModel.Models
{
    public partial class EmployeeTraining
    {
        public int Id { get; set; }

        public string? EmpId { get; set; }

        public int? TraningId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? BenchId { get; set; }
    }
}