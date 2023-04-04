using Employee_Report.Model.Models;

namespace Employee_Report.API.IService
{
    public interface IEmployeeSkillsService
    {
        Task<Response> GetEmployeeSkills();
        Task<Response> GetEmployeeSkillsByID(int id);
        Task<Response> AddEmployeeSkill(EmployeeSkills employeeSkills);
        Task<Response> GetEmployeeSkillsByEmpId(string id);
    }
}
