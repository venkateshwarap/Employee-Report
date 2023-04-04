namespace Employee.DataModel.Models
{
    public class PowerHouse_Role
    {
        public int Id { get; set; }
        public string? EmpId { get; set; }
        public string? RoleName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ReportingTo { get; set; }
    }
}
