using Employee.DataModel.Models;

namespace Employee_Report.API.Entities
{
    public partial class EmployeeSkills_Skills_Entity
    {
        public string? EmpID { get; set; }
        public string? SkillName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
