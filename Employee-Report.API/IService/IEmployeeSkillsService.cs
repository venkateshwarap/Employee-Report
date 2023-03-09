using Employee.DataModel.Models;
using Employee_Report.Model.Models;

namespace Employee_Report.API.IService
{
    public interface IEmployeeSkillsService
    {
        Task<Response> SaveEmployeeSkills(EmployeeSkills employeeSkills);
        Task<Response> getEmployeeSkills();
    }
}
