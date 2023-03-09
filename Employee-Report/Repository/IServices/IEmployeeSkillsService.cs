using Employee.DataModel.Models;
using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IEmployeeSkillsService
    {
        Task<Response> GetEmployeeSkills();
        Task<Response> AddEmployeeSkill(EmployeeSkills employeeSkill);
    }
}
