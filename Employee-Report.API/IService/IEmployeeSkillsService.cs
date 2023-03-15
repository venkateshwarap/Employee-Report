using Employee.DataModel.Models;

namespace Employee_Report.API.IService
{
    public interface IEmployeeSkillsService
    {
        Task<List<EmployeeSkills_Skills_Entity>> GetEmployeeSkills();
        Task<Response> AddEmployeeSkill(EmployeeSkills employeeSkills);
    }
}
