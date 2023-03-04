using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Report.Model.Models;
    public class EACouncilEntryExit
    {
        public int Id { get; set; }
        public string? EmpId { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public string? Role { get; set; }
        public string? ReportingTo { get; set; }
    }
