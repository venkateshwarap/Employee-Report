using Employee.DataModel.Models;
using Employee_Report.API.Entities;
using Employee_Report.Model.Models;

namespace Employee_Report.API.IService
{
    public interface IEmployeeSkillsService
    {
        Task<List<EmployeeSkills_Skills_Entity>> GetEmployeeSkills();
        Task<Response> AddEmployeeSkill(EmployeeSkills employeeSkills);
    }
}
