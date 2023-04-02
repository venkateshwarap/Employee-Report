using Employee_Report.Model.Models;

namespace employee_report.api.iservice
{
    public interface IProjectService
    {
        Task<List<Project>> GetProjectDetails();

        Task<List<EmployeeProjectEntity>> GetEmployeeProjectDetails();

        Task<Response> GetByProjectId(string EmpId);

        Task<int> PostProject(Project project);
        Task<int> PostEmployeeProject(EmployeeProject employeeproject);
        List<EmployeeProjectEntity> GetById(string empId);
    }
}
