namespace Employee.DataModel.Models
{
    public class EmployeeLearningEntity
    {
        public string? Name { get; set; }
        public string? EmpId { get; set; }
        public string Path { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int HoursOfLearning { get; set; }
    }
}
