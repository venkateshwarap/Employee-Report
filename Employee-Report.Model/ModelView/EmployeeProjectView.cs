
namespace Employee_Report.Model.ModelView
{
    public class EmployeeProjectView
    {

        public string? RoleName { get; set; }
        public string? ProjectName { get; set; }
        public string? EmpId { get; set; }
        public int ProjectId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ReportingTo { get; set; }

    }
}
