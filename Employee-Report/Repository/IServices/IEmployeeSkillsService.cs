using Employee.DataModel.Models;
using Employee_Report.API.Entities;
using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IEmployeeSkillService
    {
        Task<IEnumerable<EmployeeSkills_Skills_Entity>> GetEmployeeSkills_Skills();
        Task<HttpResponseMessage> AddEmployeeSkills_Skils(EmployeeSkills_Skills_Entity employeeSkills_Skills_Entity);
    }
}
