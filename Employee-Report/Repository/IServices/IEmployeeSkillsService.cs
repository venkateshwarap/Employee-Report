using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IEmployeeSkillService
    {
        Task<Response> CreateEmployeeSkill(EmployeeSkills employeeSkills);
        Task<Response> GetEmployeeSkillsById(string empid);
        Task<Response> GetEmployeeSkills();
    }
}
