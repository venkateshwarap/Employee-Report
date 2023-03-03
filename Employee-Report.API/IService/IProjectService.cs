using Employee_Report.API.Entities;
using Employee_Report.Model.Models;
using System.Threading.Tasks;

namespace employee_report.api.iservice
{
    public interface IProjectService
    {
        Task<List<Project>> GetProjectDetails();

        Task<List<EmployeeProjectEntity>> GetEmployeeProjectDetails();

        Task<int> PostProject(Project project);
        Task<int> PostEmployeeProject(EmployeeProject employeeproject);
    }
}
