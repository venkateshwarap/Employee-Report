using System;
using System.Collections.Generic;

namespace Employee.DataModel.Models
{
    public partial class EacouncilEntryExit
    {
        public int Id { get; set; }

        public string? EmpId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Role { get; set; }

        public string? ReportingTo { get; set; }
    }
}