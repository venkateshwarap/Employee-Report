using Employee_Report.Model.Models;
using Employee_Report.Repository.IServices;
using Employee_Report.Utilities;

namespace Employee_Report.Repository.Services
{
    public class EmployeeProjectService : IEmployeeProjectService
    {
       
        HttpClient _httpClient = new HttpClient();
        public EmployeeProjectService()
        {
            _httpClient.BaseAddress = new Uri(AppSettings.Config.API_ROUTE!);
        }
        public async Task<Response> GetEmployeeProjectDetails()
        {
            var empProject = await Utility.HttpClientGetAsync(AppSettings.Config.GetEmployeeProject,_httpClient);
            return empProject;
        }
        public async Task<Response> AddEmployeeProject(EmployeeProject project)
        {
            var response = await Utility.HttpClientPostAsync(AppSettings.Config.AddEmployeeProject,_httpClient, project);
            return response;
        }

        public async Task<Response> GetProjectDetails()
        {
            var empProject =  await Utility.HttpClientGetAsync(AppSettings.Config.GetProject,_httpClient);
            return empProject;
        }

        public async Task<Response> AddProject(Project project)
        {
            var response = await Utility.HttpClientPostAsync(AppSettings.Config.AddProject, _httpClient, project);
            return response;
        }
        public async Task<Response> GetEmployeeProjectDetailsById(string Id)
        {
            var empProject = await Utility.HttpClientGetAsync(AppSettings.Config.GET_EMPLOYEE_PROJECT_BY_ID, Id, _httpClient);
            return empProject;
        }
    }
}



