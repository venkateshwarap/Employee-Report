using Employee.DataModel.Models;
using Employee_Report.API.Entities;
using Employee_Report.Model.Models;

namespace Employee_Report.Repository.IServices
{
    public interface IEmployeeProjectService
    {
        Task<IEnumerable<EmployeeProjectEntity>> GetEmployeeProjectDetails();
        Task<HttpResponseMessage> AddEmployeeProject(EmployeeProject project);

        Task<IEnumerable<Project>> GetProjectDetails();
        Task<HttpResponseMessage> AddProject(Project project);


    }
}
