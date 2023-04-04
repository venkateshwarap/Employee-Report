using Employee_Report.Model.Models;

namespace employee_report.api.iservice
{
    public interface IProjectService
    {
        Task<Response> GetProjectDetails();

        Task<Response> GetEmployeeProjectDetails();

        Task<Response> GetByProjectId(string EmpId);

        Task<Response> PostProject(Project project);
        Task<Response> CreateEmployeeProject(EmployeeProject employeeproject);
        Task<Response> GetById(string empId);
    }
}
