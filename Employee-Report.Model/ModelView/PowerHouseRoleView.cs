namespace Employee_Report.Model.ModelView
{
    public class PowerHouseRoleView
    {
        public int Id { get; set; }
        public string? EmpId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? RoleName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ReportingTo { get; set; }
    }
}
