﻿
namespace Employee_Report.Model.Models
{
    public partial class EmployeeProject
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string? EmpId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? ReportingTo { get; set; }

        public int RoleId { get; set; }

        public string? Achivements { get; set; }
    }
}