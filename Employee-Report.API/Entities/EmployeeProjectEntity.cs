namespace Employee_Report.API.Entities
{
    public class EmployeeProjectEntity
    {
        public string? Name { get; set; }
        public string? EmpId { get; set; }
        public string? Role { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ReportingTo { get; set; }
    }
}
