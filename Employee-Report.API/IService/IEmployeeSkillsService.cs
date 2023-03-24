using Employee.DataModel.Models;

namespace Employee_Report.API.IService
{
    public interface IEmployeeSkillsService
    {
        Task<List<EmployeeSkills_Skills_Entity>> GetEmployeeSkills();
        Task<List<EmployeeSkills_Skills_Entity>> GetEmployeeSkillsByID(int id);
        Task<Response> AddEmployeeSkill(EmployeeSkills employeeSkills);
        Response GetEmployeeSkillsByEmpId(string id);
    }
}
