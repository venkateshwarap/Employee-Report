
namespace Employee_Report.Model.Models
{
    public class PowerHouseRole
    {
        public int Id { get; set; }
        public string? EmpId { get; set; }
        public string? RoleName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ReportingTo { get; set; }
    }
}
