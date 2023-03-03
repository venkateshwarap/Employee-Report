namespace Employee_Report.API.Entities
{
    public class EmployeePOCEntity
    {
        public string? Name { get; set; }

        public int BnechId { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ReportingTo { get; set; }

    }
}
